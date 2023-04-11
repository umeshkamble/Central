
namespace Central.App.ViewModels
{
    public class PagePINVM : PageVM<City>
    {
        #region Properties
        public PINVM PINVM { get; set; }
        public override bool IsValid
        {
            get {
                try {
                    if (!this.PINVM.IsValid) return false;
                }
                catch (Exception ex){
                    if (ex.Message != "") this.OnAlert(ex);
                    return false;
                }

                return base.IsValid; 
            }
        }
        #endregion Properties

        public PagePINVM() : base("", "",false) 
        {
            this.PINVM = new PINVM(new PIN());
            this.PINVM.Completed += ((PIN pin) => {
                var tasks = new List<Task> { this.OnLoginAsync(pin) };
                this.LoadAsyncCommand.Execute(tasks);
            });
        }

        private async Task OnLoginAsync(PIN pin)
        {
            if (!this.IsValid) return;

            var store = AppShell2.Store;
            var dbname = store.DbName;
            var db = (UserService)Base.GetDb(nameof(User), dbname);
            var user = await db.Login(pin);
            if (user is null) {
                this.OnAlert("PIN anda salah !");
                this.PINVM.OnClearPIN();
                return;
            }

            Base.User = user;
            await this.OnGotoAsync($"//{nameof(PagePMV)}_");
        }

    }
}
