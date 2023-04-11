
namespace Central.App.ViewModels
{
    public class PageProductBrandEditVM : PageMasterEditVM<ProductBrandVM, ProductBrand>
    {
        public PageProductBrandEditVM()  { }
        protected override ProductBrandVM OnGetEditVM(ProductBrandVM vm)
        {
            vm = new ProductBrandVM(PanelEnum.Edit1);
            return base.OnGetEditVM(vm);
        }
    }
}

