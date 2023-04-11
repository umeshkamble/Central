
namespace Central.App.ViewModels
{
    public class PageStoreEditVM : PageContactEditVM<StoreVM, Store>
    {
        public PageStoreEditVM() { }
        protected override StoreVM OnGetEditVM(StoreVM vm)
        {
            vm = new StoreVM(PanelEnum.Edit1);
            return base.OnGetEditVM(vm);
        }
    }
}
