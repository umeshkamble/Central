

namespace Central.App.ViewModels
{
    public class PageSalesmanEditVM : PageContactEditVM<SalesmanVM, Salesman>
    {
        public PageSalesmanEditVM() { }
        protected override SalesmanVM OnGetEditVM(SalesmanVM vm)
        {
            vm = new SalesmanVM(PanelEnum.Edit1);
            return base.OnGetEditVM(vm);
        }

    }
}
