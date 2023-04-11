

namespace Central.App.ViewModels
{
    public class PageCustomerEditVM : PageContactEditVM<CustomerVM, Customer>
    {
        public PageCustomerEditVM()  { }
        protected override CustomerVM OnGetEditVM(CustomerVM vm)
        {
            vm = new CustomerVM(PanelEnum.Edit1);
            return base.OnGetEditVM(vm);
        }
    }
}
