namespace Central.App.ViewModels
{
    public class PageQRISVM : PageMasterVM<ContentQRISListVM, QRISListVM, QRISVM, QRIS>
    {
        public PageQRISVM() : base("QRIS", "QRIS list in this account.", nameof(PageQRISEditV)) { }
        protected override ContentQRISListVM OnGetContentListVM()
        {
            return new ContentQRISListVM();
        }

        protected override QRISVM OnGetInfoVM()
        {
            return new QRISVM(PanelEnum.Info);
        }

    }
}
