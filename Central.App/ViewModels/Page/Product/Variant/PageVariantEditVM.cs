using Central.Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Central.App.ViewModels
{
    public class PageVariantEditVM : PageMasterEditVM<VariantVM, Variant>
    {
        #region Command
        public Command SaveCommand { get; set; }
        #endregion Command

        public PageVariantEditVM()
        {
            this.Title1 = "Varian";
            this.Title2 = "Edit";
            this.SaveEnum = SaveEnum.SaveTemp;
            this.SaveCommand = new Command(() => this.OnMenuSelect(MenuEnum.Save));
        }

        protected override VariantVM OnGetEditVM(VariantVM vm)
        {
            vm = new VariantVM(PanelEnum.Edit1);
            return base.OnGetEditVM(vm);
        }
    }
}
