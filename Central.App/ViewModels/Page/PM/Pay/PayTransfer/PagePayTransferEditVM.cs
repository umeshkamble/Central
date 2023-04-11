

namespace Central.App.ViewModels
{
    public class PagePayTransferEditVM : PagePayEditVM<PayTransferVM, PayTransfer>
    {
        public PagePayTransferEditVM()  { }
        protected override PayTransferVM OnGetEditVM(PayTransferVM vm)
        {
            vm = new PayTransferVM(PanelEnum.Edit1);
            return base.OnGetEditVM(vm);
        }
    }
}
