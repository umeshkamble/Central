
namespace Central.App.ViewModels
{
    public class PageDashboardVM : PageVM<City>
    {
        public Command GotoAppShell1Command { get; set; }
        public PageDashboardVM() : base("Dashboard", "Panel")
        {
            this.GotoAppShell1Command = new Command(() => {
                App.Current.MainPage = new AppShell1();
            });   
        }
    }
}
