namespace Central.App.ViewModels
{
    public class PageProductWarehouseVM : PageMasterVM<ContentProductWarehouseListVM, ProductWarehouseListVM, ProductWarehouseVM, ProductWarehouse>
    {
        public PageProductWarehouseVM() : base("Gudang", "Product warehouse list in this account.", nameof(PageProductWarehouseEditV)) { }
        protected override ContentProductWarehouseListVM OnGetContentListVM()
        {
            return new ContentProductWarehouseListVM();
        }

        protected override ProductWarehouseVM OnGetInfoVM()
        {
            return new ProductWarehouseVM(PanelEnum.Info);
        }

    }
}
