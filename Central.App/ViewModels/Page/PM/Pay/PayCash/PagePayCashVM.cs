

namespace Central.App.ViewModels
{
    public class PagePayCashVM : PagePayVM<ContentPayCashListVM, PayCashListVM, PayCashVM, PayCash>
    {
        public PagePayCashVM() : base("Cash", "Cash list in this account.", nameof(PagePayCashEditV)) { }
        protected override ContentPayCashListVM OnGetContentListVM()
        {
            return new ContentPayCashListVM();
        }
       
        protected override PayCashVM OnGetInfoVM()
        {
            return new PayCashVM(PanelEnum.Info);
        }
    
    }
}
