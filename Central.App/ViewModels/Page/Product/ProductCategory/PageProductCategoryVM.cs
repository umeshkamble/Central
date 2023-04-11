namespace Central.App.ViewModels
{
    public class PageProductCategoryVM : PageMasterVM<ContentProductCategoryListVM, ProductCategoryListVM, ProductCategoryVM, ProductCategory>
    {
        public PageProductCategoryVM() : base("Kategori Produk", "Product category list in this account.", nameof(PageProductCategoryEditV)) { }
        protected override ContentProductCategoryListVM OnGetContentListVM()
        {
            return new ContentProductCategoryListVM();
        }

        protected override ProductCategoryVM OnGetInfoVM()
        {
            return new ProductCategoryVM(PanelEnum.Info);
        }

    }
}
