

namespace Central.App.ViewModels
{
    public class PageFilterUserVM : PageFilterContactVM<User>
    {
        public PageFilterUserVM(Query<User> query) : base(query) { }
    }
}
