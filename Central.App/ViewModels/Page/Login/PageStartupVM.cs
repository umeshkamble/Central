
using Newtonsoft.Json;

namespace Central.App.ViewModels
{
    public class PageStartupVM : PageVM<Account>
    {
        #region Properties
        private string Text_ = "Please wait...";
        public string Text
        {
            set { this.OnSetProperty(ref Text_, value); }
            get { return Text_; }
        }
        #endregion Properties

        public PageStartupVM() : base("", "", false) { }
        protected override Task<List<Task>> OnLoadFirstAsync(List<Task> tasks)
        {
            tasks.Add(this.OnStartupAsync());
            return base.OnLoadFirstAsync(tasks);
        }

        private void OnProgress(string text)
        {
            this.Text = text;
            this.OnLog(text);
        }

        private async Task OnStartupAsync()
        {
            this.OnProgress("Reading account...");
            var text = Base.ToString(Preferences.Get(nameof(Base.Account), "")).Trim();

            try {
                if (text == "") throw new Exception("Direct to login page...");
                var account = JsonConvert.DeserializeObject<Account>(text);
                this.OnProgress($"Login as {account.Nama}...");

                account = await this.OnLoginAsync(account.Email, account.Password, account.Id);
                if (account is null) throw new Exception("Session expired...");
                this.OnProgress("Login sucessfull...100%");
            }
            catch (Exception ex) {
                this.OnProgress(ex.Message);
                await this.OnLogoutAsync();
            }            
        }
    }
}
