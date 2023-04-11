
namespace Central.App.ViewModels
{
    public class PageProductWarehouseEditVM : PageMasterEditVM<ProductWarehouseVM, ProductWarehouse>
    {
        public PageProductWarehouseEditVM()  { }
        protected override ProductWarehouseVM OnGetEditVM(ProductWarehouseVM vm)
        {
            vm = new ProductWarehouseVM(PanelEnum.Edit1);
            return base.OnGetEditVM(vm);
        }
    }
}


