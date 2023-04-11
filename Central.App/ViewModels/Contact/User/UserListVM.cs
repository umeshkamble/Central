

namespace Central.App.ViewModels
{
    public class UserListVM : ContactListVM<UserVM, User>
    {
        public UserListVM(List<TemplateEnum> ts, SelectionEnum selectionenum, PanelEnum panelenum, bool incall) : base(ts, selectionenum, panelenum, nameof(User), incall) { }
        protected override Task<UserVM> OnInsertAsync(User entity, PanelEnum panelenum, int no, ImageSource imagesource, UserVM item)
        {
            item = new UserVM(entity, panelenum, no, imagesource);
            return base.OnInsertAsync(entity, panelenum, no, imagesource, item);
        }
    }

}
