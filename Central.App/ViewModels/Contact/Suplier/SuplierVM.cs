
namespace Central.App.ViewModels
{
    public class SuplierVM : ContactVM<Suplier>
    {
        #region Properties
        public override Suplier Entity 
        {
            set {
                if (value is null) return;
                var entity = value;
                base.Entity = entity;

                this.LamaJT = entity.LamaJT;
            }
            get {
                var entity = base.Entity;
                entity.LamaJT = this.LamaJT;
                return entity;
            } 
        }

        public InputTextVM InputLamaJTVM { get; set; }

        private int LamaJT_;
        public int LamaJT
        {
            set {
                LamaJT_ = value;
                try { this.InputLamaJTVM.Text = LamaJT_.ToString("#,##0"); } catch { }
                this.OnPropertyChanged();
            }
            get { try { return Base.ToInt(this.InputLamaJTVM.Text); } catch { return LamaJT_; } }
        }
        #endregion Properties

        public SuplierVM(PanelEnum panelenum) : this(null, panelenum, 1, null) { }
        public SuplierVM(Suplier entity, PanelEnum panelenum, int no, ImageSource imagesource) : base(entity, panelenum, no, imagesource) { }
        
        protected override void OnInitInput(Suplier entity, PanelEnum panelenum)
        {
            base.OnInitInput(entity, panelenum);
            if (panelenum == PanelEnum.Edit1) {
                this.InputLamaJTVM = new InputTextVM(new InputText("Lama JT", "*Lama jatuh tempo bon pelanggan", "", IconFont.Calendar, TextEnum.Number));
            }
        }
    }
}
