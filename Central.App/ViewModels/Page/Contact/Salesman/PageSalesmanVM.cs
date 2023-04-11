

namespace Central.App.ViewModels
{
    public class PageSalesmanVM : PageContactVM<ContentSalesmanListVM, SalesmanListVM, SalesmanVM, Salesman>
    {
        public PageSalesmanVM() : base("Salesman", "Salesman list in this account.", nameof(PageSalesmanEditV)) { }
        protected override ContentSalesmanListVM OnGetContentListVM()
        {
            return new ContentSalesmanListVM();
        }
       
        protected override SalesmanVM OnGetInfoVM()
        {
            return new SalesmanVM(PanelEnum.Info);
        }       
    }
}
