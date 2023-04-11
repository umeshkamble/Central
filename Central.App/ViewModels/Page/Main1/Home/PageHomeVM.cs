
namespace Central.App.ViewModels
{
    public class PageHomeVM : PageVM<City>
    {
        public Command LogoutCommand { get; set; }
        public PageHomeVM() : base("Home", "Dashboard") 
        {
            this.LogoutCommand = new Command(async () => {
                await this.OnLogoutAsync();
            });
        }
    }
}
