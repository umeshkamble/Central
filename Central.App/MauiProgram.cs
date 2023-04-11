namespace Central.App;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");

                fonts.AddFont("Font-Title.otf", "FontTitle");
                fonts.AddFont("Font-Regular.otf", "FontRegular");
                fonts.AddFont("Font-Italic.otf", "FontItalic");
                fonts.AddFont("Font-Awesome.otf", "FontAwesome");
            });


        //builder.Services.AddSingleton<IConnectivity>(Connectivity.Current);
        //builder.Services.AddSingleton<IGeolocation>(Geolocation.Default);
        //builder.Services.AddSingleton<IMap>(Map.Default);

        builder.Services.AddSingleton<PagePINV>();
        builder.Services.AddSingleton<PagePINVM>();

        builder.Services.AddSingleton<PageKasV>();
        builder.Services.AddSingleton<PageKasVM>();
        builder.Services.AddSingleton<PageKasEditV>();
        builder.Services.AddSingleton<PageKasEditVM>();

        builder.Services.AddSingleton<PageBankV>();
        builder.Services.AddSingleton<PageBankVM>();
        builder.Services.AddSingleton<PageBankEditV>();
        builder.Services.AddSingleton<PageBankEditVM>();

        builder.Services.AddSingleton<PageQRISV>();
        builder.Services.AddSingleton<PageQRISVM>();
        builder.Services.AddSingleton<PageQRISEditV>();
        builder.Services.AddSingleton<PageQRISEditVM>();


        builder.Services.AddSingleton<PageSuplierV>();
        builder.Services.AddSingleton<PageSuplierVM>();
        builder.Services.AddSingleton<PageSuplierEditV>();
        builder.Services.AddSingleton<PageSuplierEditVM>();

        builder.Services.AddSingleton<PageCustomerV>();
        builder.Services.AddSingleton<PageCustomerVM>();
        builder.Services.AddSingleton<PageCustomerEditV>();
        builder.Services.AddSingleton<PageCustomerEditVM>();

        builder.Services.AddSingleton<PageSalesmanV>();
        builder.Services.AddSingleton<PageSalesmanVM>();
        builder.Services.AddSingleton<PageSalesmanEditV>();
        builder.Services.AddSingleton<PageSalesmanEditVM>();



        builder.Services.AddSingleton<PageProductV>();
        builder.Services.AddSingleton<PageProductVM>();
        builder.Services.AddSingleton<PageProductEditV>();
        builder.Services.AddSingleton<PageProductEditVM>();

        builder.Services.AddSingleton<PageProductBrandV>();
        builder.Services.AddSingleton<PageProductBrandVM>();
        builder.Services.AddSingleton<PageProductBrandEditV>();
        builder.Services.AddSingleton<PageProductBrandEditVM>();


        builder.Services.AddSingleton<PageProductCategoryV>();
        builder.Services.AddSingleton<PageProductCategoryVM>();
        builder.Services.AddSingleton<PageProductCategoryEditV>();
        builder.Services.AddSingleton<PageProductCategoryEditVM>();


        builder.Services.AddSingleton<PageProductWarehouseV>();
        builder.Services.AddSingleton<PageProductWarehouseVM>();
        builder.Services.AddSingleton<PageProductWarehouseEditV>();
        builder.Services.AddSingleton<PageProductWarehouseEditVM>();



        builder.Services.AddSingleton<PagePIV>();
        builder.Services.AddSingleton<PagePIVM>();
        builder.Services.AddSingleton<PagePIEditV>();
        builder.Services.AddSingleton<PagePIEditVM>();


        builder.Services.AddSingleton<PagePMV>();
        builder.Services.AddSingleton<PagePMVM>();
        builder.Services.AddSingleton<PagePMEditV>();
        builder.Services.AddSingleton<PagePMEditVM>();

        builder.Services.AddSingleton<PagePayCashV>();
        builder.Services.AddSingleton<PagePayCashVM>();
        builder.Services.AddSingleton<PagePayCashEditV>();
        builder.Services.AddSingleton<PagePayCashEditVM>();

        builder.Services.AddSingleton<PagePayCekV>();
        builder.Services.AddSingleton<PagePayCekVM>();
        builder.Services.AddSingleton<PagePayCekEditV>();
        builder.Services.AddSingleton<PagePayCekEditVM>();

        builder.Services.AddSingleton<PagePayBGV>();
        builder.Services.AddSingleton<PagePayBGVM>();
        builder.Services.AddSingleton<PagePayBGEditV>();
        builder.Services.AddSingleton<PagePayBGEditVM>();

        builder.Services.AddSingleton<PagePayTransferV>();
        builder.Services.AddSingleton<PagePayTransferVM>();
        builder.Services.AddSingleton<PagePayTransferEditV>();
        builder.Services.AddSingleton<PagePayTransferEditVM>();

        builder.Services.AddSingleton<PageDashboardV>();
        builder.Services.AddSingleton<PageDashboardVM>();

        builder.Services.AddSingleton<PageStartupV>();
        builder.Services.AddSingleton<PageStartupVM>();

        builder.Services.AddSingleton<PageHomeV>();
        builder.Services.AddSingleton<PageHomeVM>();

        builder.Services.AddSingleton<PageOfficialV>();
        builder.Services.AddSingleton<PageOfficialVM>();

        builder.Services.AddSingleton<PageScanV>();
        builder.Services.AddSingleton<PageScanVM>();

        builder.Services.AddSingleton<PageWishlistV>();
        builder.Services.AddSingleton<PageWishlistVM>();

        builder.Services.AddSingleton<PageTrollyV>();
        builder.Services.AddSingleton<PageTrollyVM>();

        builder.Services.AddSingleton<PageSetupV>();
        builder.Services.AddSingleton<PageSetupVM>();

        builder.Services.AddSingleton<PageLoginV>();
        builder.Services.AddTransient<PageLoginVM>();

        builder.Services.AddSingleton<PageRegisterV>();
        builder.Services.AddTransient<PageRegisterVM>();

        builder.Services.AddSingleton<PageProgressV>();
        builder.Services.AddSingleton<PageProgressVM>();

        builder.Services.AddSingleton<PageStoreV>();
        builder.Services.AddSingleton<PageStoreVM>();
        builder.Services.AddSingleton<PageStoreEditV>();
        builder.Services.AddSingleton<PageStoreEditVM>();

        return builder.Build();
	}
}
