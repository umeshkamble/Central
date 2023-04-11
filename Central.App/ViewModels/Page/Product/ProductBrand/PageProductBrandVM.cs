namespace Central.App.ViewModels
{
    public class PageProductBrandVM : PageMasterVM<ContentProductBrandListVM, ProductBrandListVM, ProductBrandVM, ProductBrand>
    {
        public PageProductBrandVM() : base("Merk Produk", "Product brand list in this account.", nameof(PageProductBrandEditV)) { }
        protected override ContentProductBrandListVM OnGetContentListVM()
        {
            return new ContentProductBrandListVM();
        }

        protected override ProductBrandVM OnGetInfoVM()
        {
            return new ProductBrandVM(PanelEnum.Info);
        }

    }
}
