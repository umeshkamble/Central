
namespace Central.App.ViewModels
{
    public class ContentUserListVM : ContentContactListVM<UserListVM, UserVM, User>
    {
        public ContentUserListVM()  { }
        protected override UserListVM OnGetPanelList(List<TemplateEnum> ts)
        {
            var selectionenum = this.SelectionEnum;
            var panelenum = PanelEnum.GridList;

            return new UserListVM(ts, selectionenum,panelenum, false);
        }

        protected override void OnFilterSelect(Query<User> querycurr, PageFilterV page, PageFilterVM<User> vm)
        {
            //-----wajib di override-------//
            page = new PageFilterUserV();
            vm = new PageFilterUserVM(querycurr);
            vm.Execute += ((query) => {
                var db = (UserService)Base.GetDb(nameof(User));
                var keyword = db.GetFilterValue(query.Filters, FilterEnum.Keyword);
                this.Keyword = keyword;
                this.PanelListVM.LoadCommand.Execute(query);
            });

            base.OnFilterSelect(querycurr, page, vm);
        }

    }
}
