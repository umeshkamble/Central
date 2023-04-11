

namespace Central.App.ViewModels
{
    public class PayCashListVM : PayListVM<PayCashVM, PayCash>
    {
        public PayCashListVM(List<TemplateEnum> ts, SelectionEnum selectionenum, PanelEnum panelenum, bool incall) : base(ts, selectionenum, panelenum, nameof(PayCash), incall) { }
        protected override Task<PayCashVM> OnInsertAsync(PayCash entity, PanelEnum panelenum, int no, ImageSource imagesource, PayCashVM item)
        {
            item = new PayCashVM(entity, panelenum, no, imagesource);
            return base.OnInsertAsync(entity, panelenum, no, imagesource, item);
        }

        protected override void OnInsertAllAsync(PayCash p)
        {
            p = new PayCash() { Id = "All", Nama = "All" };
            base.OnInsertAllAsync(p);
        }
    }

}
