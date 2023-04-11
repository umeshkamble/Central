

namespace Central.App.ViewModels
{
    public class PageUserEditVM : PageContactEditVM<UserVM, User>
    {
        public PageUserEditVM() { }
        protected override UserVM OnGetEditVM(UserVM vm)
        {
            vm = new UserVM(PanelEnum.Edit1);
            return base.OnGetEditVM(vm);
        }
    }
}
