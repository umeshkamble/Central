

namespace Central.App.ViewModels
{
    public class PayCekListVM : PayListVM<PayCekVM, PayCek>
    {
        public PayCekListVM(List<TemplateEnum> ts, SelectionEnum selectionenum, PanelEnum panelenum, bool incall) : base(ts, selectionenum, panelenum, nameof(PayCek), incall) { }
        protected override Task<PayCekVM> OnInsertAsync(PayCek entity, PanelEnum panelenum, int no, ImageSource imagesource, PayCekVM item)
        {
            item = new PayCekVM(entity, panelenum, no, imagesource);
            return base.OnInsertAsync(entity, panelenum, no, imagesource, item);
        }

        protected override void OnInsertAllAsync(PayCek p)
        {
            p = new PayCek() { Id = "All", Nama = "All" };
            base.OnInsertAllAsync(p);
        }
    }

}
