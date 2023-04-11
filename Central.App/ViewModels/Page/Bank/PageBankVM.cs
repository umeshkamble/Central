namespace Central.App.ViewModels
{
    public class PageBankVM : PageMasterVM<ContentBankListVM, BankListVM, BankVM, Bank>
    {
        public PageBankVM() : base("Bank", "Bank list in this account.", nameof(PageBankEditV)) { }
        protected override ContentBankListVM OnGetContentListVM()
        {
            return new ContentBankListVM();
        }
       
        protected override BankVM OnGetInfoVM()
        {
            return new BankVM(PanelEnum.Info);
        }

    }
}
