using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Central.App.ViewModels
{
    public class PageSetupVM : PageVM<EntityBase>
    {
        public MenuVM Menu1VM { get; set; }
        public MenuVM Menu2VM { get; set; }
        public MenuVM Menu3VM { get; set; }

        public PageSetupVM() : base("Setup","")
        {
            this.Menu1VM = new MenuVM(new Menu(MenuEnum.Save, IconFont.Save, "Save"));
            this.Menu2VM = new MenuVM(new Menu(MenuEnum.Delete, IconFont.Recycle, "Delete"));
            this.Menu3VM = new MenuVM(new Menu(MenuEnum.Edit, IconFont.Edit, "Edit"));
        }
    }
}
