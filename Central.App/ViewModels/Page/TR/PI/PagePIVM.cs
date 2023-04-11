namespace Central.App.ViewModels
{
    public class PagePIVM : PageTRVM<ContentPIListVM, PIListVM, PIVM, PI, PIDetailListVM, PIDetailVM, PIDetail,Suplier>
    {
        public PagePIVM() : base("Pembelian (PI)", "PI list in this account.", nameof(PagePIEditV)) { }
        protected override ContentPIListVM OnGetContentListVM()
        {
            return new ContentPIListVM();
        }
       
        protected override PIVM OnGetInfoVM()
        {
            return new PIVM(PanelEnum.Info);
        }

    }
}

