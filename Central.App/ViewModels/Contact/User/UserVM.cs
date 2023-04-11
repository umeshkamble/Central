

namespace Central.App.ViewModels
{
    public class UserVM : ContactVM<User>
    {
        #region Properties
        public override User Entity 
        {
            set {
                if (value is null) return;
                var entity = value;
                base.Entity = entity;
                
                this.Username = Base.ToString(entity.Username);
                this.PasswordCurrent = Base.ToString(entity.Password);
                this.Password = this.PasswordNew = this.PasswordNewRetype = "";
                this.IsViewPassword = this.Username.Trim() == "" ? true : false;
            }
            get {
                var entity = base.Entity;
                entity.Username = this.Username;
                entity.Password = this.PasswordNew.Trim() == "" ? this.PasswordCurrent : this.PasswordNew;
                return entity;
            } 
        }

        public InputTextVM InputUsernameVM { get; set; }
        public InputTextVM InputPasswordVM { get; set; }
        public InputTextVM InputPasswordNewVM { get; set; }
        public InputTextVM InputPasswordNewRetypeVM { get; set; }

        private string Username_;
        public string Username
        {
            set {
                Username_ = value;
                try { this.InputUsernameVM.Text = Username_; } catch { }
                this.OnPropertyChanged();
            }
            get { try { return this.InputUsernameVM.Text; } catch { return Username_; } }
        }

        private string PasswordCurrent { get; set; }

        private string Password_;
        public string Password
        {
            set
            {
                Password_ = value;
                try { this.InputPasswordVM.Text = Password_; } catch { }
                this.OnPropertyChanged();
            }
            get { try { return this.InputPasswordVM.Text; } catch { return Password_; } }
        }

        private string PasswordNew_;
        public string PasswordNew
        {
            set {
                PasswordNew_ = value;
                try { this.InputPasswordNewVM.Text = PasswordNew_; } catch { }
                this.OnPropertyChanged();
            }
            get { try { return this.InputPasswordNewVM.Text; } catch { return PasswordNew_; } }
        }

        private string PasswordNewRetype_;
        public string PasswordNewRetype
        {
            set {
                PasswordNewRetype_ = value;
                try { this.InputPasswordNewRetypeVM.Text = PasswordNewRetype_; } catch { }
                this.OnPropertyChanged();
            }
            get { try { return this.InputPasswordNewRetypeVM.Text; } catch { return PasswordNewRetype_; } }
        }

        private bool IsViewPassword_;
        public bool IsViewPassword
        {
            set { this.OnSetProperty(ref IsViewPassword_, value); }
            get { return IsViewPassword_; }
        }

        public override bool IsValid {
            get
            {
                var isvalid = true;
                var info = "";
                if (this.PasswordNew != "") {
                    if (this.PasswordNew != this.PasswordNewRetype) {
                        info = "Password Ulang (Baru) tidak valid !";
                        isvalid = false;
                    }
                }

                if (isvalid) {
                    if (this.Password != this.PasswordCurrent) {
                        info = "Password (Sekarang) tidak valid !";
                        isvalid = false;
                    }
                }

                if (!isvalid) {
                    this.OnAlert(info);
                    return false;
                }

                return base.IsValid;
            }
        }
        #endregion Properties

        public UserVM(PanelEnum panelenum) : this(null, panelenum, 1, null) { }
        public UserVM(User entity, PanelEnum panelenum, int no, ImageSource imagesource) : base(entity, panelenum, no, imagesource) { }
        
        protected override void OnInitInput(User entity, PanelEnum panelenum)
        {
            base.OnInitInput(entity, panelenum);
            if (panelenum == PanelEnum.Edit1) {
                this.InputUsernameVM = new InputTextVM(new InputText("Username") { IsTitleCase = false });
                this.InputPasswordVM = new InputTextVM(new InputText("Password (Sekarang)") { IsTitleCase = false, IsPassword = true });
                this.InputPasswordNewVM = new InputTextVM(new InputText("Password (Baru)") { IsTitleCase = false, IsPassword = true });
                this.InputPasswordNewRetypeVM = new InputTextVM(new InputText("Ulang Password (Baru)") { IsTitleCase = false, IsPassword = true });
            }
        }

    }
}
