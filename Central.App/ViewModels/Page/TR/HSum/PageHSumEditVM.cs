
using Microsoft.Maui.Handlers;

namespace Central.App.ViewModels
{
    public class PageHSumEditVM : PageMasterEditVM<HSumVM, HSum>
    {
        public PageHSumEditVM()
        {
            this.SaveEnum = SaveEnum.SaveTemp;
            this.Title1 = "Diskon (Faktur)";
            this.Title2 = "Edit";
        }
        
        protected override HSumVM OnGetEditVM(HSumVM vm)
        {
            vm = new HSumVM(PanelEnum.Edit1);
            return base.OnGetEditVM(vm);
        }
    }
}
