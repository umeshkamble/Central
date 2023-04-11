using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Central.App.ViewModels
{
    public class PageVM<E> : BaseVM<E> where E : EntityBase
    {
        #region Properties
        public MenuListVM MenuListNav1VM { get; set; }
        public MenuListVM MenuListNav2VM { get; set; }
        private bool IsViewBack { get; set; }
        #endregion Properties

        public PageVM(string title1, string title2) : this(title1, title2, true) { }
        public PageVM(string title1, string title2, bool isviewback)  
        {
            this.Title1 = title1;
            this.Title2 = title2;
            this.IsViewBack = isviewback;
            
            this.MenuListNav1VM = new MenuListVM(new List<TemplateEnum> { TemplateEnum.T1 }, SelectionEnum.None);
            this.MenuListNav1VM.MenuSelectedChanged += this.OnMenuSelect;
            
            this.MenuListNav2VM = new MenuListVM(new List<TemplateEnum> { TemplateEnum.T1 }, SelectionEnum.None);
            this.MenuListNav2VM.MenuSelectedChanged += this.OnMenuSelect;
        }

        protected override Task<List<Task>> OnLoadFirstAsync(List<Task> tasks)
        {
            tasks.Add(this.MenuListNav1VM.OnInsertAsync(this.OnGetMenusNav1(new List<Menu>()), true));
            tasks.Add(this.MenuListNav2VM.OnInsertAsync(this.OnGetMenusNav2(new List<Menu>()), true));
            return base.OnLoadFirstAsync(tasks);
        }

        protected virtual List<Menu> OnGetMenusNav1(List<Menu> menus)
        {
            if (this.IsViewBack) menus.Add(new Menu(MenuEnum.Back, IconFont.ArrowLeft));
            return menus;
        }

        protected virtual List<Menu> OnGetMenusNav2(List<Menu> menus)
        {
            return menus;
        }

        public override async void OnMenuSelect(MenuEnum menu)
        {
            switch (menu) {
                case MenuEnum.Back: {
                        await this.OnGoBackAsync(); 
                        break;
                    } 
                default: base.OnMenuSelect(menu);break;
            }
        }

        public virtual async Task<bool> OnBackPressed()
        {
            return await this.OnAlert("Anda yakin ingin keluar ?", "Exit", "OK", "Cancel");
        }
    }
}
