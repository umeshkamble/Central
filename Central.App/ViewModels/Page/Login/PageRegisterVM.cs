using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Central.App.ViewModels
{
    public class PageRegisterVM : PageVM<Account>, IAccount
    {
        #region Properties
        public InputTextVM InputNamaVM { get; set; }
        public InputTextVM InputEmailVM { get; set; }
        public InputTextVM InputNoTlpVM { get; set; }
        public InputTextVM InputPasswordVM { get; set; }
        public InputTextVM InputPasswordRetypeVM { get; set; }
        public PINVM PINVM { get; set; }
        public PINVM OTPVM { get; set; }

        public override Account Entity
        {
            set {
                if (value is null) return;

                var entity = value;
                base.Entity = entity;

                this.Nama = entity.Nama;
                this.Email = entity.Email;
                this.NoTlp = entity.NoTlp;
                this.Password = entity.Password;
                this.PasswordRetype = "";
                this.PIN = entity.PIN;
                this.Deskripsi = entity.Deskripsi;
            }
            get {
                var entity = base.Entity;
                entity.Nama = this.Nama;
                entity.Email = this.Email;
                entity.NoTlp = this.NoTlp;
                entity.Password = this.Password;
                entity.PIN = this.PIN;
                entity.Deskripsi = this.Deskripsi;
                return entity;
            }
        }

        private string Nama_ = "";
        public string Nama
        {
            set {
                Nama_ = value;
                this.InputNamaVM.Text = Nama_;
            }
            get { return this.InputNamaVM.Text.Trim(); }
        }

        private string Email_ = "";
        public string Email
        {
            set {
                Email_ = value;
                this.InputEmailVM.Text = Email_;
            }
            get { return this.InputEmailVM.Text.ToLower().Trim(); }
        }

        private string NoTlp_ = "";
        public string NoTlp
        {
            set {
                NoTlp_ = value;
                this.InputNoTlpVM.Text = NoTlp_;
            }
            get { return this.InputNoTlpVM.Text.Trim(); }
        }

        private string Password_ = "";
        public string Password
        {
            set {
                Password_ = value;
                this.InputPasswordVM.Text = Password_;
            }
            get { return this.InputPasswordVM.Text.Trim(); }
        }

        private string PasswordRetype_ = "";
        public string PasswordRetype
        {
            set {
                PasswordRetype_ = value;
                this.InputPasswordRetypeVM.Text = PasswordRetype_;
            }
            get { return this.InputPasswordRetypeVM.Text.Trim(); }
        }

        private PIN PIN_ = null;
        public PIN PIN
        {
            set {
                if (value is null) return;

                PIN_ = value;
                this.PINVM.Entity = PIN_;
            }
            get { return this.PINVM.Entity; }
        }

        public string Deskripsi { get; set; } = "";
        public override bool IsValid
        {
            get {
                try {
                    if (!this.InputNamaVM.IsValid) throw new Exception("");
                    else if (!this.InputNamaVM.IsValid) throw new Exception("");
                    else if (!this.InputEmailVM.IsValid) throw new Exception("");
                    else if (!this.InputNoTlpVM.IsValid) throw new Exception("");
                    else if (!this.InputPasswordVM.IsValid) throw new Exception("");
                    else if (!this.InputPasswordRetypeVM.IsValid) throw new Exception("");
                    else if (!this.PINVM.IsValid) throw new Exception("");
                    else if (this.Password != this.PasswordRetype) throw new Exception("Password (Konfirmasi) salah !");
                }
                catch (Exception ex){
                    this.OnAlert(ex);
                    return false;
                }
                return base.IsValid; 
            }
        }
        #endregion Properties

        #region Command
        public Command RegisterCommand { get; set; }
        #endregion Command  

        public PageRegisterVM() : base("","")
        {
            this.InputNamaVM = new InputTextVM(new InputText("", "", "Nama Lengkap", IconFont.User, TextEnum.Text));
            this.InputEmailVM = new InputTextVM(new InputText("", "", "Email", IconFont.Inbox, TextEnum.Email));
            this.InputNoTlpVM = new InputTextVM(new InputText("", "", "No. Tlp", IconFont.Phone, TextEnum.Phone));
            this.InputPasswordVM = new InputTextVM(new InputText("", "", "Password", IconFont.Key, TextEnum.Password));
            this.InputPasswordRetypeVM = new InputTextVM(new InputText("","", "Password (Konfirmasi)", IconFont.Key, TextEnum.Password));
            this.PINVM = new PINVM(new PIN());
            this.OTPVM = new PINVM(new PIN() { IsOTP = true });
            
            this.RegisterCommand = new Command(async () => {
                try {
                    if (!this.IsValid) return;
                    var r = await this.Db.Save(this.Entity, true);
                    if (!r.IsSuccess) throw new Exception(r.Message);

                    //-----Back to Page Login and try to Login-------//
                    await this.OnGotoAsync("..",new Account() { 
                        Email = this.Email,
                        Password = this.Password
                    });
                }
                catch (Exception ex) {
                    this.OnAlert(ex);
                }
            });
        }

        
    }
}
