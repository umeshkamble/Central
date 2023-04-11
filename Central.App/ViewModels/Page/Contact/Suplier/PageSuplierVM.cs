

namespace Central.App.ViewModels
{
    public class PageSuplierVM : PageContactVM<ContentSuplierListVM, SuplierListVM, SuplierVM, Suplier>
    {
        public PageSuplierVM() : base("Suplier", "Suplier list in this account.", nameof(PageSuplierEditV)) { }
        protected override ContentSuplierListVM OnGetContentListVM()
        {
            return new ContentSuplierListVM();
        }
       
        protected override SuplierVM OnGetInfoVM()
        {
            return new SuplierVM(PanelEnum.Info);
        }
    }
}
