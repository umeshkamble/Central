
namespace Central.App.ViewModels
{
    public class PageSuplierEditVM : PageContactEditVM<SuplierVM, Suplier>
    {
        public PageSuplierEditVM()  { }
        protected override SuplierVM OnGetEditVM(SuplierVM vm)
        {
            vm = new SuplierVM(PanelEnum.Edit1);
            return base.OnGetEditVM(vm);
        }
    }
}
