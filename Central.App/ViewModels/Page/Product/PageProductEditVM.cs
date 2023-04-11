
namespace Central.App.ViewModels
{
    public class PageProductEditVM : PageMasterEditVM<ProductVM, Product>
    {
        public PageProductEditVM()  { }
        protected override ProductVM OnGetEditVM(ProductVM vm)
        {
            vm = new ProductVM(PanelEnum.Edit1);
            return base.OnGetEditVM(vm);
        }
    }
}

