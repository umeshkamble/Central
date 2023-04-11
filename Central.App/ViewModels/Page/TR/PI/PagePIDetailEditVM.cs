
namespace Central.App.ViewModels
{
    public class PagePIDetailEditVM : PageTRDetailEditVM<PIDetailVM, PIDetail>
    {
        public PagePIDetailEditVM() { }
        protected override PIDetailVM OnGetEditVM(PIDetailVM vm)
        {
            vm = new PIDetailVM(PanelEnum.Edit2);
            //vm.DetailChanged +=
            return base.OnGetEditVM(vm);
        }
    }
}
