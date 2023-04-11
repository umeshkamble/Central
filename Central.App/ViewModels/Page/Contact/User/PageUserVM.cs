
namespace Central.App.ViewModels
{
    public class PageUserVM : PageContactVM<ContentUserListVM, UserListVM, UserVM, User>
    {
        public PageUserVM() : base("User", "User list in this account.", nameof(PageUserEditV)) { }
        protected override ContentUserListVM OnGetContentListVM()
        {
            return new ContentUserListVM();
        }
       
        protected override UserVM OnGetInfoVM()
        {
            return new UserVM(PanelEnum.Info);
        }
    }
}
