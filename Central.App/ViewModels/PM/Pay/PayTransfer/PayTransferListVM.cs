

namespace Central.App.ViewModels
{
    public class PayTransferListVM : PayListVM<PayTransferVM, PayTransfer>
    {
        public PayTransferListVM(List<TemplateEnum> ts, SelectionEnum selectionenum, PanelEnum panelenum, bool incall) : base(ts, selectionenum, panelenum, nameof(PayTransfer), incall) { }
        protected override Task<PayTransferVM> OnInsertAsync(PayTransfer entity, PanelEnum panelenum, int no, ImageSource imagesource, PayTransferVM item)
        {
            item = new PayTransferVM(entity, panelenum, no, imagesource);
            return base.OnInsertAsync(entity, panelenum, no, imagesource, item);
        }

        protected override void OnInsertAllAsync(PayTransfer p)
        {
            p = new PayTransfer() { Id = "All", Nama = "All" };
            base.OnInsertAllAsync(p);
        }
    }

}
