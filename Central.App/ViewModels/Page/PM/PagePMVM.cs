namespace Central.App.ViewModels
{
    public class PagePMVM : PageMasterVM<ContentPMListVM, PMListVM, PMVM, PM>
    {
        public PagePMVM() : base("Pembayaran (PM)", "Daftar pembayaran In/Out", nameof(PagePMEditV)) { }
        protected override ContentPMListVM OnGetContentListVM()
        {
            return new ContentPMListVM();
        }
       
        protected override PMVM OnGetInfoVM()
        {
            return new PMVM(PanelEnum.Info);
        }

    }
}
