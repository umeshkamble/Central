
namespace Central.App.ViewModels
{
    public class PagePIEditVM : PageTREditVM<PIVM, PI, PIDetailListVM, PIDetailVM, PIDetail,Suplier>
    {
        public PagePIEditVM() { }
        protected override PIVM OnGetEditVM(PIVM vm)
        {
            vm = new PIVM(PanelEnum.Edit1);
            return base.OnGetEditVM(vm);
        }
    }
}

