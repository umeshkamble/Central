

using MongoDB.Driver.Core.Operations;

namespace Central.App.ViewModels
{
    public class PhoneVM : PanelVM<Phone>
    {
        #region Properties
        public override Phone Entity
        {
            set{
                if (value is null) return;
                var entity = value;
                base.Entity = entity;

                this.Deskripsi = entity.Deskripsi;
                this.NoTlp = entity.NoTlp;
            }
            get {
                var entity = base.Entity;
                entity.Deskripsi = this.Deskripsi;
                entity.NoTlp = this.NoTlp;
                return entity;
            }
        }

        public InputTextVM InputDeskripsiVM { get; set; }
        public InputTextVM InputNoTlpVM { get; set; }
        
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

        private string NoTlp_;
        public virtual string NoTlp
        {
            set {
                NoTlp_ = value;
                try { this.InputNoTlpVM.Text = NoTlp_; } catch { }
            }
            get { try { return this.InputNoTlpVM.Text; } catch { return NoTlp_; } }
        }

        public override bool IsValid 
        {
            get {
                try {
                    if (!this.InputDeskripsiVM.IsValid) throw new Exception("");
                    else if (!this.InputNoTlpVM.IsValid) throw new Exception("");
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
            get { return this.NoTlp; }
        }
        #endregion Properties

        public PhoneVM(PanelEnum panelenum) : this(null, panelenum, 1, null) { }
        public PhoneVM(Phone entity, PanelEnum panelenum, int no, ImageSource imagesource) : base(entity, panelenum, no, imagesource) { }
        protected override void OnInitInput(Phone entity, PanelEnum panelenum)
        {
            base.OnInitInput(entity, panelenum);
            if (panelenum == PanelEnum.Edit1) {
                this.InputDeskripsiVM = new InputTextVM(new InputText("Deskripsi", "Deskrispi (Home/Work/Etc)...", "") { MaxLength = 50 });
                this.InputNoTlpVM = new InputTextVM(new InputText("No. Tlp", "Input no HP/Tlp...", "", "", TextEnum.Phone) { MaxLength = 20 });
            }
        }
    }
}
