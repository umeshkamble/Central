

namespace Central.App.ViewModels
{
    public class PayBGListVM : PayListVM<PayBGVM, PayBG>
    {
        public PayBGListVM(List<TemplateEnum> ts, SelectionEnum selectionenum, PanelEnum panelenum, bool incall) : base(ts, selectionenum, panelenum, nameof(PayBG), incall) { }
        protected override Task<PayBGVM> OnInsertAsync(PayBG entity, PanelEnum panelenum, int no, ImageSource imagesource, PayBGVM item)
        {
            item = new PayBGVM(entity, panelenum, no, imagesource);
            return base.OnInsertAsync(entity, panelenum, no, imagesource, item);
        }

        protected override void OnInsertAllAsync(PayBG p)
        {
            p = new PayBG() { Id = "All", Nama = "All" };
            base.OnInsertAllAsync(p);
        }
    }

}
