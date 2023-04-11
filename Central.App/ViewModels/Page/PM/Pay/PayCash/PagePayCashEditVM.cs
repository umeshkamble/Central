

namespace Central.App.ViewModels
{
    public class PagePayCashEditVM : PagePayEditVM<PayCashVM, PayCash>
    {
        public PagePayCashEditVM()  { }
        protected override PayCashVM OnGetEditVM(PayCashVM vm)
        {
            vm = new PayCashVM(PanelEnum.Edit1);
            return base.OnGetEditVM(vm);
        }
    }
}
