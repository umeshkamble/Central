

namespace Central.App.ViewModels
{
    public class PageCustomerVM : PageContactVM<ContentCustomerListVM, CustomerListVM, CustomerVM, Customer>
    {
        public PageCustomerVM() : base("Customer", "Customer list in this account.", nameof(PageCustomerEditV)) { }
        protected override ContentCustomerListVM OnGetContentListVM()
        {
            return new ContentCustomerListVM();
        }
       
        protected override CustomerVM OnGetInfoVM()
        {
            return new CustomerVM(PanelEnum.Info);
        }
    
    }
}
