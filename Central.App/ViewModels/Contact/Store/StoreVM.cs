

namespace Central.App.ViewModels
{
    public class StoreVM : ContactVM<Store>
    {
        #region Properties
        public override Store Entity
        {
            set {
                if (value is null) return;

                var entity = value;
                base.Entity = entity;
                this.NoNPWP = entity.NoNPWP;
            }
            get {
                var entity = base.Entity;
                entity.NoNPWP = this.NoNPWP;
                return entity;
            }
        }

        public InputTextVM InputNoNPWPVM { get; set; }

        private string NoNPWP_;
        public virtual string NoNPWP
        {
            set {
                NoNPWP_ = value;
                try { this.InputNoNPWPVM.Text = NoNPWP_; } catch { }
                this.OnPropertyChanged();
            }
            get { try { return this.InputNoNPWPVM.Text; } catch { return NoNPWP_; } }
        }

        public override bool IsValid
        {
            get {
                var isvalid = base.IsValid;
                if (!isvalid) return isvalid;
                
                //if (!this.InputNoNPWPVM.IsValid) return false;
                return true;
            }
        }

        #endregion Properties

        public StoreVM(PanelEnum panelenum) : this(null, panelenum, 1, null) { }
        public StoreVM(Store entity, PanelEnum panelenum, int no, ImageSource imagesource) : base(entity, panelenum, no, imagesource) { }
        
        protected override void OnInitEvent(Store entity, PanelEnum panelenum)
        {
            base.OnInitEvent(entity, panelenum);
            if (panelenum == PanelEnum.Edit1) {
                this.InputNoNPWPVM = new InputTextVM(new InputText("No. NPWP", "*Nomor pokok wajib pajak pelanggan", "", IconFont.IdCard, TextEnum.NPWP));
            }
        }

    }
}
