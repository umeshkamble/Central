

namespace Central.App.ViewModels
{
    public class PagePayBGVM : PagePayVM<ContentPayBGListVM, PayBGListVM, PayBGVM, PayBG>
    {
        public PagePayBGVM() : base("BG", "BG list in this account.", nameof(PagePayBGEditV)) { }
        protected override ContentPayBGListVM OnGetContentListVM()
        {
            return new ContentPayBGListVM();
        }
       
        protected override PayBGVM OnGetInfoVM()
        {
            return new PayBGVM(PanelEnum.Info);
        }
    
    }
}
