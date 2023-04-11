

namespace Central.App.ViewModels
{
    public class PagePayBGEditVM : PagePayEditVM<PayBGVM, PayBG>
    {
        public PagePayBGEditVM()  { }
        protected override PayBGVM OnGetEditVM(PayBGVM vm)
        {
            vm = new PayBGVM(PanelEnum.Edit1);
            return base.OnGetEditVM(vm);
        }
    }
}
