using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Central.App.ViewModels
{
    public class PageLoginVM : PageVM<Account>
    {
        #region Properties
        public InputTextVM InputEmailPhoneVM { get; set; }
        public InputTextVM InputPasswordVM { get; set; }

        public override Account Entity 
        {
            set {
                if (value is null) return;

                var entity = value;
                base.Entity = entity;
                this.EmailPhone = entity.Email;
                this.Password = entity.Password;

                if (entity.Email != "" && entity.Password != "") this.LoginCommand.Execute(null);
            }
            get {  return base.Entity; }
        }

        private string EmailPhone_ = "";
        public string EmailPhone
        {
            set {
                EmailPhone_ = value;
                this.InputEmailPhoneVM.Text = EmailPhone_;
            }
            get { return this.InputEmailPhoneVM.Text.Trim(); }
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

        public override bool IsValid
        {
            get {
                try {
                    if (!this.InputEmailPhoneVM.IsValid) throw new Exception("");
                    else if (!this.InputPasswordVM.IsValid) throw new Exception("");
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
        public Command LoginCommand { get; set; }
        public Command RegisterCommand { get; set; }
        #endregion Command  

        public PageLoginVM() : base("","",false)
        {
            this.InputEmailPhoneVM = new InputTextVM(new InputText("", "", "Email / No. Hp", IconFont.User, TextEnum.Text) { IsTitleCase = false });
            this.InputPasswordVM = new InputTextVM(new InputText("", "", "Password", IconFont.Key, TextEnum.Password));
            
            this.LoginCommand = new Command(() => {
                if (!this.IsValid) return;

                var tasks = new List<Task> { this.OnLoginAsync(this.EmailPhone, this.Password, "") };
                this.LoadAsyncCommand.Execute(tasks);
            });

            this.RegisterCommand = new Command(async () => {
                await this.OnGotoAsync(nameof(PageRegisterV), new Account() { Nama = "XXX"});
            });
        }
    }
}
