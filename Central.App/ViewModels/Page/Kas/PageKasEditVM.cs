
namespace Central.App.ViewModels
{
    public class PageKasEditVM : PageMasterEditVM<KasVM, Kas>
    {
        public PageKasEditVM()  { }
        protected override KasVM OnGetEditVM(KasVM vm)
        {
            vm = new KasVM(PanelEnum.Edit1);
            return base.OnGetEditVM(vm);
        }
    }
}
