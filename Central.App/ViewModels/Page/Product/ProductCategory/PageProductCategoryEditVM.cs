
namespace Central.App.ViewModels
{
    public class PageProductCategoryEditVM : PageMasterEditVM<ProductCategoryVM, ProductCategory>
    {
        public PageProductCategoryEditVM()  { }
        protected override ProductCategoryVM OnGetEditVM(ProductCategoryVM vm)
        {
            vm = new ProductCategoryVM(PanelEnum.Edit1);
            return base.OnGetEditVM(vm);
        }
    }
}


