using Central.App.Views;
using Microsoft.Maui.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Central.App.ViewModels
{
    public class PSumVM : PanelVM<PSum>, IPSum
    {
        #region Properties
        public override PSum Entity
        {
            set {
                if (value is null) return;
                var entity = value;
                base.Entity = entity;

                this.IsRun1 = false;
                this.Tagihan = entity.Tagihan;
                this.Point = entity.Point;
                this.Promo = entity.Promo;
                this.Bayar = entity.Bayar;
                this.Sisa = entity.Sisa;
                this.Kembalian = entity.Kembalian;
                this.PromoText = entity.PromoText;
                this.IsSplit = entity.IsSplit;
                this.IsIncludePoint = entity.IsIncludePoint;
                this.IsRun1 = true;

                this.OnPSumChanged();
            }
            get {
                return new PSum(this.Tagihan, this.Point, this.Promo, this.Bayar, this.PromoText, this.IsSplit, this.IsIncludePoint);
            } 
        }

        public InputSwitchVM InputSwitchSplitVM { get; set; }
        public InputSwitchVM InputSwitchPointVM { get; set; }
        public InputPickerVM InputPromoVM { get; set; }

        private double TotalPoint { get; set; } = 50000;
        private double TotalPromo { get; set; } = 6000;

        private double Tagihan_;
        public double Tagihan
        {
            set { this.OnSetProperty(ref Tagihan_, value); }
            get { return Tagihan_; }
        }

        private double Point_;
        public double Point
        {
            set { this.OnSetProperty(ref Point_, value); }
            get { return Point_; }
        }

        private double Promo_;
        public double Promo
        {
            set { this.OnSetProperty(ref Promo_, value); }
            get { return Promo_; }
        }

        private double Bayar_;
        public double Bayar
        {
            set { this.OnSetProperty(ref Bayar_, value); }
            get { return Bayar_; }
        }

        private double Sisa_;
        public double Sisa
        {
            set { this.OnSetProperty(ref Sisa_, value); }
            get { return Sisa_; }
        }

        private double Kembalian_;
        public double Kembalian
        {
            set { this.OnSetProperty(ref Kembalian_, value); }
            get { return Kembalian_; }
        }

        private string PromoText_;
        public string PromoText
        {
            set { this.OnSetProperty(ref PromoText_, value); }
            get { return PromoText_; }
        }

        private bool IsSplit_;
        public bool IsSplit
        {
            set {
                if (IsSplit_ == value) return;

                IsSplit_ = value;
                try { this.InputSwitchSplitVM.IsOn = IsSplit_; } catch { }
                this.OnSplitChanged();
            }
            get {
                try { return this.InputSwitchSplitVM.IsOn; } catch { return IsSplit_; }
            }
        }

        private bool IsIncludePoint_;
        public bool IsIncludePoint
        {
            set {
                if (IsIncludePoint_ == value) return;

                IsIncludePoint_ = value;
                try { this.InputSwitchPointVM.IsOn = IsIncludePoint_; } catch { }
                this.OnIncludePointChanged();
            }
            get {
                try { return this.InputSwitchPointVM.IsOn; } catch { return IsIncludePoint_; }
            }
        }

        private bool IsRun1 { get; set; }
        public override string Caption
        {
            get { return this.Sisa.ToString("#,##0"); }
        }
        #endregion Properties

        #region Command
        public Command LoadByDetailsCommand { get; set; }
        public Command EditDiskonCommand { get; set; }
        #endregion Command

        #region Event
        public delegate void PSumEventHandler(PSum psum);
        public event PSumEventHandler PSumChanged;

        public delegate void SplitEventHandler(bool issplit);
        public event SplitEventHandler SplitChanged;
        #endregion Event    

        public PSumVM(PanelEnum panelenum) : this(null, panelenum, 1, null) { }
        public PSumVM(PSum entity, PanelEnum panelenum, int no, ImageSource imagesource) : base(entity, panelenum, no, imagesource) { }

        protected override void OnInitInput(PSum entity,PanelEnum panelenum)
        {
            base.OnInitInput(entity, panelenum);
            if (panelenum == PanelEnum.GridList) {
                this.InputSwitchSplitVM = new InputSwitchVM(new InputSwitch("Split Pembayaran", "Aktifkan jika ingin multiple pembayaran", "", IconFont.MoneyBill, false));
                this.InputSwitchPointVM = new InputSwitchVM(new InputSwitch("Tukar Point", "Point anda Rp. 825,000,-", "", IconFont.Memory, false));
                this.InputPromoVM = new InputPickerVM(new InputPicker("Vouher Promo", "Pilih promo (%)", "", IconFont.Percent), nameof(Bank));
            }
        }
        protected override void OnInitEvent(PSum entity, PanelEnum panelenum)
        {
            base.OnInitEvent(entity, panelenum);
            if (panelenum == PanelEnum.GridList) {
                this.InputSwitchSplitVM.CheckedChanged += ((ison) => this.IsSplit = ison);
                this.InputSwitchPointVM.CheckedChanged += ((ison) => this.IsIncludePoint = ison);
                this.InputPromoVM.IdChanged += ((id) => this.OnPromoChanged(id));
            }
        }

        public void OnSplitChanged()
        {
            if (!this.IsRun1) return;
            if (this.SplitChanged != null) this.SplitChanged(this.IsSplit);
        }

        public void OnIncludePointChanged()
        {
            if (!this.IsRun1) return;

            //----refresh TotalPoint utk account ini--------//
            this.Point = this.IsIncludePoint ? this.TotalPoint : 0;
            this.OnRefresh();
        }

        public void OnPromoChanged(string text)
        {
            if (!this.IsRun1) return;
            
            //----------ini hanya sementara untuk test-----//
            this.PromoText = text;
            this.Promo = this.TotalPromo;
            this.OnRefresh();
        }

        public void OnPSumChanged()
        {
            if (!this.IsRun1) return;
            if (this.PSumChanged != null) this.PSumChanged(this.Entity);
        }

        public override void OnRefresh()
        {
            //-----jika nilai point,promo,atau bayar ada berubah, maka refresh ulang------//
            this.Entity = this.Entity;
            base.OnRefresh();
        }


    }
}
