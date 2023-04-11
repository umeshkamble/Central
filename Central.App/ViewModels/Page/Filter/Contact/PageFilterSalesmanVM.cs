

namespace Central.App.ViewModels
{
    public class PageFilterSalesmanVM : PageFilterContactVM<Salesman>
    {
        public PageFilterSalesmanVM(Query<Salesman> query) : base(query) { }
    }
}
