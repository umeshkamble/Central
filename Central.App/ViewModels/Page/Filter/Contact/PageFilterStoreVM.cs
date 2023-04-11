
namespace Central.App.ViewModels
{
    public class PageFilterStoreVM : PageFilterContactVM<Store>
    {
        public PageFilterStoreVM(Query<Store> query) : base(query) { }
    }
}
