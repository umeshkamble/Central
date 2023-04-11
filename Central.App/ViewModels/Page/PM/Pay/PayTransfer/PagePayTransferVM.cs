

namespace Central.App.ViewModels
{
    public class PagePayTransferVM : PagePayVM<ContentPayTransferListVM, PayTransferListVM, PayTransferVM, PayTransfer>
    {
        public PagePayTransferVM() : base("Transfer", "Transfer list in this account.", nameof(PagePayTransferEditV)) { }
        protected override ContentPayTransferListVM OnGetContentListVM()
        {
            return new ContentPayTransferListVM();
        }
       
        protected override PayTransferVM OnGetInfoVM()
        {
            return new PayTransferVM(PanelEnum.Info);
        }
    
    }
}
