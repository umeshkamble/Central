using Central.App.Views;

namespace Central.App;

public partial class AppShell2 : Shell
{
    public static Store Store { get; set; }
    public static string DbName
    {
        get { return AppShell2.Store.DbName; }
    }

    public static Dictionary<string, object> Pages { get; set; } = new Dictionary<string, object>();
    public static Dictionary<string, object> Vms { get; set; } = new Dictionary<string, object>();

    public AppShell2(Store store)
    {
        InitializeComponent();

        AppShell2.Store = store;
        Routing.RegisterRoute(nameof(PagePINV), typeof(PagePINV));
        Routing.RegisterRoute(nameof(PageDashboardV), typeof(PageDashboardV));

        Routing.RegisterRoute(nameof(PageKasV), typeof(PageKasV));
        Routing.RegisterRoute(nameof(PageKasEditV), typeof(PageKasEditV));

        Routing.RegisterRoute(nameof(PageBankV), typeof(PageBankV));
        Routing.RegisterRoute(nameof(PageBankEditV), typeof(PageBankEditV));

        Routing.RegisterRoute(nameof(PageQRISV), typeof(PageQRISV));
        Routing.RegisterRoute(nameof(PageQRISEditV), typeof(PageQRISEditV));

        Routing.RegisterRoute(nameof(PageSuplierV), typeof(PageSuplierV));
        Routing.RegisterRoute(nameof(PageSuplierEditV), typeof(PageSuplierEditV));

        Routing.RegisterRoute(nameof(PageCustomerV), typeof(PageCustomerV));
        Routing.RegisterRoute(nameof(PageCustomerEditV), typeof(PageCustomerEditV));

        Routing.RegisterRoute(nameof(PageSalesmanV), typeof(PageSalesmanV));
        Routing.RegisterRoute(nameof(PageSalesmanEditV), typeof(PageSalesmanEditV));

        Routing.RegisterRoute(nameof(PageProductV), typeof(PageProductV));
        Routing.RegisterRoute(nameof(PageProductEditV), typeof(PageProductEditV));

        Routing.RegisterRoute(nameof(PageProductCategoryV), typeof(PageProductCategoryV));
        Routing.RegisterRoute(nameof(PageProductCategoryEditV), typeof(PageProductCategoryEditV));

        Routing.RegisterRoute(nameof(PageProductWarehouseV), typeof(PageProductWarehouseV));
        Routing.RegisterRoute(nameof(PageProductWarehouseEditV), typeof(PageProductWarehouseEditV));

        Routing.RegisterRoute(nameof(PageProductBrandV), typeof(PageProductBrandV));
        Routing.RegisterRoute(nameof(PageProductBrandEditV), typeof(PageProductBrandEditV));

        Routing.RegisterRoute(nameof(PagePIV), typeof(PagePIV));
        Routing.RegisterRoute(nameof(PagePIEditV), typeof(PagePIEditV));

        Routing.RegisterRoute(nameof(PagePMV), typeof(PagePMV));
        Routing.RegisterRoute(nameof(PagePMEditV), typeof(PagePMEditV));

        Routing.RegisterRoute(nameof(PagePayCashV), typeof(PagePayCashV));
        Routing.RegisterRoute(nameof(PagePayCashEditV), typeof(PagePayCashEditV));

        Routing.RegisterRoute(nameof(PagePayBGV), typeof(PagePayBGV));
        Routing.RegisterRoute(nameof(PagePayBGEditV), typeof(PagePayBGEditV));

        Routing.RegisterRoute(nameof(PagePayCekV), typeof(PagePayCekV));
        Routing.RegisterRoute(nameof(PagePayCekEditV), typeof(PagePayCekEditV));

        Routing.RegisterRoute(nameof(PagePayTransferV), typeof(PagePayTransferV));
        Routing.RegisterRoute(nameof(PagePayTransferEditV), typeof(PagePayTransferEditV));
    }

    public static object GetVM(string name, SelectionEnum selectionenum)
    {
        object vm = null;
        try { vm = AppShell2.Vms[name]; }
        catch {
            switch (name) {
                case nameof(Store): vm = new PageStoreVM() { IsPicker = true, SelectionEnum = selectionenum }; break;
                case nameof(Kas): vm = new PageKasVM() { IsPicker = true, SelectionEnum = selectionenum }; break;
                case nameof(Bank): vm = new PageBankVM() { IsPicker = true, SelectionEnum = selectionenum }; break;
                case nameof(QRIS): vm = new PageQRISVM() { IsPicker = true, SelectionEnum = selectionenum }; break;
                //case nameof(City): vm = new PageCityVM() { IsPicker = true, SelectionEnum = selectionenum }; break;
                case nameof(Suplier): vm = new PageSuplierVM() { IsPicker = true, SelectionEnum = selectionenum }; break;
                case nameof(Customer): vm = new PageCustomerVM() { IsPicker = true, SelectionEnum = selectionenum }; break;
                case nameof(Salesman): vm = new PageSalesmanVM() { IsPicker = true, SelectionEnum = selectionenum }; break;
                
                case nameof(Product): vm = new PageProductVM() { IsPicker = true, SelectionEnum = selectionenum }; break;
                case nameof(ProductBrand): vm = new PageProductBrandVM() { IsPicker = true, SelectionEnum = selectionenum }; break;
                case nameof(ProductCategory): vm = new PageProductCategoryVM() { IsPicker = true, SelectionEnum = selectionenum }; break;
                case nameof(ProductWarehouse): vm = new PageProductWarehouseVM() { IsPicker = true, SelectionEnum = selectionenum }; break;

                default: vm = null; break;
            }
            if (!(vm is null)) AppShell2.Vms.Add(name, vm);
            else Debug.WriteLine($"ERROR GetVM() : {name} is NULL !!!");
        }
        return vm;
    }

    public static object GetPage(string name, object vm)
    {
        object page = null;
        try { page = AppShell2.Pages[name]; }
        catch {
            switch (name) {
                case nameof(Store): page = new PageStoreV((PageStoreVM)vm); break;
                case nameof(Kas): page = new PageKasV((PageKasVM)vm); break;
                case nameof(Bank): page = new PageBankV((PageBankVM)vm); break;
                case nameof(QRIS): page = new PageQRISV((PageQRISVM)vm); break;
                //case nameof(City): page = new PageCityV((PageCityVM)vm); break;
                case nameof(Suplier): page = new PageSuplierV((PageSuplierVM)vm); break;
                case nameof(Customer): page = new PageCustomerV((PageCustomerVM)vm); break;
                case nameof(Salesman): page = new PageSalesmanV((PageSalesmanVM)vm); break;
                
                case nameof(Product): page = new PageProductV((PageProductVM)vm); break;
                case nameof(ProductBrand): page = new PageProductBrandV((PageProductBrandVM)vm); break;
                case nameof(ProductCategory): page = new PageProductCategoryV((PageProductCategoryVM)vm); break;
                case nameof(ProductWarehouse): page = new PageProductWarehouseV((PageProductWarehouseVM)vm); break;

                default: page = null; break;
            }
            if (!(page is null)) AppShell2.Pages.Add(name, page);
            else Debug.WriteLine($"ERROR GetPage() : {name} is NULL !!!");
        }
        return page;
    }
}
