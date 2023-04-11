


using System.Net.Http.Headers;

namespace Central.App.ViewModels
{
    public class PayVM<P> : PanelVM<P> where P : Pay, IPay
    {
        #region Properties
        public override P Entity
        {
            set{
                if (value is null) return;
                var entity = value;
                base.Entity = entity;

                this.Id_Coa = entity.Id_Coa;
                this.Id_PM = entity.Id_PM;
                this.Grup = entity.Grup;
                this.Tgl = entity.Tgl;
                this.Nama = entity.Nama;
                this.NoReferensi = entity.NoReferensi;
                this.Total = entity.Total;
                this.Deskripsi = entity.Deskripsi;
            }
            get {
                var entity = base.Entity;
                entity.Id_Coa = this.Id_Coa;
                entity.Id_PM = this.Id_PM;
                entity.Grup = this.Grup;
                entity.Tgl = this.Tgl;
                entity.Nama = this.Nama;
                entity.NoReferensi = this.NoReferensi;
                entity.Total = this.Total;
                entity.Deskripsi = this.Deskripsi;
                return entity;
            }
        }

        public InputTextVM InputNoReferensiVM { get; set; }
        public InputTextVM InputTotalVM { get; set; }
        public InputTextVM InputDeskripsiVM { get; set; }

        private DateTime Tgl_;
        public DateTime Tgl
        {
            set { this.OnSetProperty(ref Tgl_, value); }
            get { return Tgl_; }
        }

        private string Nama_;
        public string Nama
        {
            set { this.OnSetProperty(ref Nama_, value); }
            get { return Nama_; }
        }

        private string NoReferensi_;
        public virtual string NoReferensi
        {
            set {
                NoReferensi_ = value;
                try { this.InputNoReferensiVM.Text = NoReferensi_; } catch { }
            }
            get { try { return this.InputNoReferensiVM.Text; } catch { return NoReferensi_; } }
        }

        private double Total_;
        public virtual double Total
        {
            set{
                Total_ = value;
                try { this.InputTotalVM.Text = Total_.ToString(); } catch { }
                this.OnTotalChanged();
            }
            get { try { return Base.ToDouble(this.InputTotalVM.Text.Trim()); } catch { return Total_; } }
        }

        private string Deskripsi_;
        public virtual string Deskripsi
        {
            set {
                Deskripsi_ = value;
                try { this.InputDeskripsiVM.Text = Deskripsi_; } catch { }
            }
            get { 
                try { return this.InputDeskripsiVM.Text; } catch { return Deskripsi_; } }
        }

        public string Id_Coa { get; set; }
        public string Id_PM { get; set; }
        public PayGrupEnum Grup { get; set; }

        public override bool IsValid 
        {
            get {
                try {
                    if (!this.InputNoReferensiVM.IsValid) throw new Exception("");
                    else if (!this.InputTotalVM.IsValid) throw new Exception("");
                }
                catch (Exception ex) {
                    if (ex.Message != "") this.OnAlert(ex);
                    return false;
                }
               
                return base.IsValid;
            }    
        }

        public override string Caption
        {
            get { return this.Nama; }
        }
        #endregion Properties

        #region Event
        public delegate void TotalEventHandler();
        public event TotalEventHandler TotalChanged;
        #endregion Event  


        public PayVM(PanelEnum panelenum) : this(null, panelenum, 1, null) { }
        public PayVM(P entity, PanelEnum panelenum, int no, ImageSource imagesource) : base(entity, panelenum, no, imagesource) { }
        protected override void OnInitInput(P entity, PanelEnum panelenum)
        {
            base.OnInitInput(entity, panelenum);
            if (panelenum == PanelEnum.Edit1) {
                this.InputNoReferensiVM = new InputTextVM(new InputText("No. Referensi", "Tuliskan No. Referensi...", "", IconFont.InfoCircle, TextEnum.Text) { IsTitleCase = false });
                this.InputTotalVM = new InputTextVM(new InputText("Total Bayar", "Rp.", "", IconFont.Calculator, TextEnum.NumberDecimal));
                this.InputDeskripsiVM = new InputTextVM(new InputText("Deskripsi", "Deskripsikan pembayaran anda...", "") { IsTitleCase = false });
            }
        }

        protected override void OnInitEvent(P entity, PanelEnum panelenum)
        {
            base.OnInitEvent(entity, panelenum);
            if (panelenum == PanelEnum.Edit1) {
                this.InputTotalVM.TextChanged += ((item) => this.Total = this.Total);
            }
        }

        private void OnTotalChanged()
        {
            if (this.TotalChanged != null) this.TotalChanged();
        }

    }
}
