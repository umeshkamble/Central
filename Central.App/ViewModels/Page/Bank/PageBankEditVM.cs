
namespace Central.App.ViewModels
{
    public class PageBankEditVM : PageMasterEditVM<BankVM, Bank>
    {
        public PageBankEditVM()  { }
        protected override BankVM OnGetEditVM(BankVM vm)
        {
            vm = new BankVM(PanelEnum.Edit1);
            return base.OnGetEditVM(vm);
        }
    }
}
