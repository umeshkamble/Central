

namespace Central.App.ViewModels
{
    public class PagePayCekEditVM : PagePayEditVM<PayCekVM, PayCek>
    {
        public PagePayCekEditVM()  { }
        protected override PayCekVM OnGetEditVM(PayCekVM vm)
        {
            vm = new PayCekVM(PanelEnum.Edit1);
            return base.OnGetEditVM(vm);
        }
    }
}
