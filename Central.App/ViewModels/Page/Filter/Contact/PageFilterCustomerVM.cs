
namespace Central.App.ViewModels
{
    public class PageFilterCustomerVM : PageFilterContactVM<Customer>
    {
        public PageFilterCustomerVM(Query<Customer> query) : base(query) { }
      
    }
}
