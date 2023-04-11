

namespace Central.App.ViewModels
{
    public class PageKasVM : PageMasterVM<ContentKasListVM, KasListVM, KasVM, Kas>
    {
        public PageKasVM() : base("Kas", "Kas list in this account.", nameof(PageKasEditV)) { }
        protected override ContentKasListVM OnGetContentListVM()
        {
            return new ContentKasListVM();
        }
       
        protected override KasVM OnGetInfoVM()
        {
            return new KasVM(PanelEnum.Info);
        }

    }
}
