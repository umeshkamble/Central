

namespace Central.App.ViewModels
{
    public class PagePayCekVM : PagePayVM<ContentPayCekListVM, PayCekListVM, PayCekVM, PayCek>
    {
        public PagePayCekVM() : base("Cek", "Cek list in this account.", nameof(PagePayCekEditV)) { }
        protected override ContentPayCekListVM OnGetContentListVM()
        {
            return new ContentPayCekListVM();
        }
       
        protected override PayCekVM OnGetInfoVM()
        {
            return new PayCekVM(PanelEnum.Info);
        }
    
    }
}
