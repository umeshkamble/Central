
using Newtonsoft.Json;

namespace Central.App.ViewModels
{
    public class PageQRISEditVM : PageMasterEditVM<QRISVM, QRIS>
    {
        public PageQRISEditVM()  { }
        protected override QRISVM OnGetEditVM(QRISVM vm)
        {
            vm = new QRISVM(PanelEnum.Edit1);
            return base.OnGetEditVM(vm);
        }
    }
}
