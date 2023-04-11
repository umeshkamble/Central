using Central.App.Views;

namespace Central.App;

public partial class AppShell1 : Shell
{
	public AppShell1()
	{
		InitializeComponent();

        Routing.RegisterRoute(nameof(PageStartupV), typeof(PageStartupV));
        Routing.RegisterRoute(nameof(PageLoginV), typeof(PageLoginV));
        Routing.RegisterRoute(nameof(PageRegisterV), typeof(PageRegisterV));
        Routing.RegisterRoute(nameof(PageProgressV), typeof(PageProgressV));

        Routing.RegisterRoute(nameof(PageHomeV), typeof(PageHomeV));
        Routing.RegisterRoute(nameof(PageOfficialV), typeof(PageOfficialV));
        Routing.RegisterRoute(nameof(PageScanV), typeof(PageScanV));
        Routing.RegisterRoute(nameof(PageWishlistV), typeof(PageWishlistV));
        Routing.RegisterRoute(nameof(PageTrollyV), typeof(PageTrollyV));
        Routing.RegisterRoute(nameof(PageSetupV), typeof(PageSetupV));

        Routing.RegisterRoute(nameof(PageStoreV), typeof(PageStoreV));
        Routing.RegisterRoute(nameof(PageStoreEditV), typeof(PageStoreEditV));
    }
}
