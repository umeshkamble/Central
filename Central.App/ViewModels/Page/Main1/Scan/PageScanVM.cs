

namespace Central.App.ViewModels
{
    public class PageScanVM : PageVM<City>
    {
        public MenuListVM MenuListVM { get; set; }
        public PageScanVM() : base("Scan", "Product") 
        {
            var menus = new List<Menu>();
            menus.Add(new Menu(MenuEnum.Add, IconFont.Plus));
            menus.Add(new Menu(MenuEnum.Edit, IconFont.Pen));
            menus.Add(new Menu(MenuEnum.Delete, IconFont.Trash));

            this.MenuListVM = new MenuListVM(new List<TemplateEnum> { TemplateEnum.T1 }, SelectionEnum.Single);
            this.MenuListVM.InsertCommand.Execute(menus);
        }
    }
}
