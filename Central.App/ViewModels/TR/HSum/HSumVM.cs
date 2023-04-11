using Central.App.Views;
using Microsoft.Maui.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Central.App.ViewModels
{
    public class HSumVM : PanelVM<HSum>, IHSum
    {
        #region Properties
        public override HSum Entity
        {
            set {
                if (value is null) return;
                var entity = value;
                base.Entity = entity;

                this.IsRun1 = this.IsRun2 = false;
                this.SubTotal = entity.SubTotal;
                this.DiskonItem = entity.DiskonItem;
                this.DiskonFaktur = entity.DiskonFaktur;
                this.DiskonFakturPersen = entity.DiskonFakturPersen;
                this.DiskonTotal = entity.DiskonTotal;
                this.PPN = entity.PPN;
                this.PPNPersen = entity.PPNPersen;
                this.Biaya = entity.Biaya;
                this.GrandTotal = entity.GrandTotal;
                this.TotalWeight = entity.TotalWeight;
                this.TotalVolume = entity.TotalVolume;
                this.IsIncludePPN = entity.IsIncludePPN;
                this.IsRun1 = this.IsRun2 = true;

                this.OnHSumChanged();
            }
            get {
                var entity = base.Entity;
                entity.SubTotal = this.SubTotal;
                entity.DiskonItem = this.DiskonItem;
                entity.DiskonFaktur = this.DiskonFaktur;
                entity.DiskonFakturPersen = this.DiskonFakturPersen;
                entity.DiskonTotal = this.DiskonTotal;
                entity.PPN = this.PPN;
                entity.PPNPersen = this.PPNPersen;
                entity.Biaya = this.Biaya;
                entity.GrandTotal = this.GrandTotal;
                entity.TotalWeight = this.TotalWeight;
                entity.TotalVolume = this.TotalVolume;
                entity.IsIncludePPN = this.IsIncludePPN;
                return entity;
            } 
        }
        public PageHSumEditV Page { get; set; }
        public PageHSumEditVM VM { get; set; }

        public InputSwitchVM InputSwitchPpnVM { get; set; }
        public InputTextVM InputSubTotalVM { get; set; }
        public InputTextVM InputDiskonFakturVM { get; set; }
        public InputTextVM InputDiskonFakturPersenVM { get; set; }
        
        private double SubTotal_;
        public double SubTotal
        {
            set {
                SubTotal_ = value;
                try { this.InputSubTotalVM.Text = SubTotal_.ToString("#,##0"); } catch { }
                this.OnPropertyChanged();
            }
            get { try { return Base.ToDouble(this.InputSubTotalVM.Text.Trim()); } catch { return SubTotal_; } }
        }

        private double DiskonItem_;
        public double DiskonItem
        {
            set { this.OnSetProperty(ref DiskonItem_, value); }
            get { return DiskonItem_; }
        }

        private double DiskonFaktur_;
        public double DiskonFaktur
        {
            set
            {
                DiskonFaktur_ = value;
                try { this.InputDiskonFakturVM.Text = DiskonFaktur_.ToString("#,##0"); } catch { }
                this.OnPropertyChanged();
            }
            get { try { return Base.ToDouble(this.InputDiskonFakturVM.Text.Trim()); } catch { return DiskonFaktur_; } }
        }

        private double DiskonFakturPersen_;
        public double DiskonFakturPersen
        {
            set {
                if (DiskonFakturPersen_ == value) return;

                DiskonFakturPersen_ = value;
                try { this.InputDiskonFakturPersenVM.Text = DiskonFakturPersen_.ToString("#,##0.###"); } catch { }
                this.OnPropertyChanged();
                this.OnHSumChanged();
            }
            get { try { return Base.ToDouble(this.InputDiskonFakturPersenVM.Text.Trim()); } catch { return DiskonFakturPersen_; } }
        }

        private double DiskonTotal_;
        public double DiskonTotal
        {
            set { this.OnSetProperty(ref DiskonTotal_, value); }
            get { return DiskonTotal_; }
        }

        private double PPN_;
        public double PPN
        {
            set { this.OnSetProperty(ref PPN_, value); }
            get { return PPN_; }
        }

        private double PPNPersen_;
        public double PPNPersen
        {
            set {
                PPNPersen_ = value;
                try { this.InputSwitchPpnVM.TextHelper = $"PPN {PPNPersen_.ToString("#,##0")}%"; } catch { }
                this.OnPropertyChanged();
            }
            get { return PPNPersen_; }
        }

        private double Biaya_;
        public double Biaya
        {
            set { this.OnSetProperty(ref Biaya_, value); }
            get { return Biaya_; }
        }

        private double GrandTotal_;
        public double GrandTotal
        {
            set { this.OnSetProperty(ref GrandTotal_, value); }
            get { return GrandTotal_; }
        }

        private double TotalWeight_;
        public double TotalWeight
        {
            set { this.OnSetProperty(ref TotalWeight_, value); }
            get { return TotalWeight_; }
        }

        private double TotalVolume_;
        public double TotalVolume
        {
            set { this.OnSetProperty(ref TotalVolume_, value); }
            get { return TotalVolume_; }
        }

        public string Icon2 { get; set; }
        private bool IsRun1 { get; set; }
        private bool IsRun2 { get; set; }

        private bool IsIncludePPN_;
        public bool IsIncludePPN
        {
            set {
                if (IsIncludePPN_ == value) return;

                IsIncludePPN_ = value;
                try { this.InputSwitchPpnVM.IsOn = IsIncludePPN_; } catch { }
                this.OnHSumChanged();
            }
            get {
                try { return this.InputSwitchPpnVM.IsOn; } catch { return IsIncludePPN_; }
            }
        }

        public override string Caption
        {
            get { return this.GrandTotal.ToString("#,##0"); }
        }
        #endregion Properties

        #region Command
        public Command LoadByDetailsCommand { get; set; }
        public Command EditDiskonCommand { get; set; }
        #endregion Command

        #region Event
        public delegate void HSumEventHandler(HSum hsum);
        public event HSumEventHandler HSumChanged;
        #endregion Event    

        public HSumVM(PanelEnum panelenum) : this(null, panelenum, 1, null) { }
        public HSumVM(HSum entity, PanelEnum panelenum, int no, ImageSource imagesource) : base(entity, panelenum, no, imagesource) { }

        protected override void OnInitInput(HSum entity,PanelEnum panelenum)
        {
            base.OnInitInput(entity, panelenum);
            if (panelenum == PanelEnum.GridList) {
                this.Icon2 = IconFont.Pen;
                this.InputSwitchPpnVM = new InputSwitchVM(new InputSwitch("Harga termasuk PPN", "PPN 11%", "", IconFont.Percent, false) { IsViewLine = false });
            }
            else if (panelenum == PanelEnum.Edit1) {
                this.InputSubTotalVM = new InputTextVM(new InputText("SubTotal (Rp)", "Rp.", "", IconFont.Calculator, TextEnum.Number)) { IsReadOnly = true };
                this.InputDiskonFakturPersenVM = new InputTextVM(new InputText("Diskon Faktur (%)", "%", "", IconFont.Calculator, TextEnum.NumberDecimal));
                this.InputDiskonFakturVM = new InputTextVM(new InputText("Diskon Faktur (Rp.)", "Rp.", "", IconFont.Calculator, TextEnum.Number));
            }
        }
        protected override void OnInitEvent(HSum entity, PanelEnum panelenum)
        {
            base.OnInitEvent(entity, panelenum);
            if (panelenum == PanelEnum.GridList) {
                this.InputSwitchPpnVM.CheckedChanged += ((ison) => this.IsIncludePPN = ison);
                this.EditDiskonCommand = new Microsoft.Maui.Controls.Command(async () => {
                    if (this.VM is null) {
                        //----------Utk proses edit diskon faktur------------//
                        this.VM = new PageHSumEditVM();
                        this.VM.Saved += ((hsum, isnew, saveenum) => {
                            this.DiskonFakturPersen = hsum.DiskonFakturPersen;
                        });
                        this.Page = new PageHSumEditV(this.VM);
                    }
                    this.VM.Entity = this.Entity;
                    await Shell.Current.Navigation.PushAsync(this.Page);
                });
                this.LoadByDetailsCommand = new Microsoft.Maui.Controls.Command<List<ITRDetail>>((List<ITRDetail> idetails) => {
                    var db = (SumService)Base.GetDb(nameof(HSum));
                    this.Entity = db.GetHSum(idetails, this.Entity);
                });
            }
            else if (panelenum == PanelEnum.Edit1) {
                this.InputDiskonFakturPersenVM.TextChanged += ((item) => {
                    if (!this.IsRun2) return;

                    this.IsRun2 = false;
                    this.DiskonFaktur = (this.DiskonFakturPersen * this.SubTotal) / 100.0;
                    this.IsRun2 = true;
                });

                this.InputDiskonFakturVM.TextChanged += ((item) => {
                    if (!this.IsRun2) return;

                    this.IsRun2 = false;
                    this.DiskonFakturPersen = (this.DiskonFaktur * 100.0) / this.SubTotal;
                    this.IsRun2 = true;
                });
            }
        }

        public void OnHSumChanged()
        {
            if (this.PanelEnum != PanelEnum.GridList) return;
            if (!this.IsRun1) return;

            if (this.HSumChanged != null) this.HSumChanged(this.Entity);
        }

    }
}
