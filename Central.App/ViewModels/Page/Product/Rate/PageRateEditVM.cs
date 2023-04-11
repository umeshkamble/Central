
using Microsoft.Maui.Handlers;

namespace Central.App.ViewModels
{
    public class PageRateEditVM : PageMasterEditVM<RateVM, Rate>
    {
        public PageRateEditVM()
        {
            this.SaveEnum = SaveEnum.SaveTemp;
            this.Title1 = "Harga / Rate";
            this.Title2 = "Edit";
        }
        
        protected override RateVM OnGetEditVM(RateVM vm)
        {
            vm = new RateVM(PanelEnum.Edit1);
            return base.OnGetEditVM(vm);
        }
    }
}
