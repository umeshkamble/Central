
namespace Central.App.ViewModels
{
    public interface IContentVM<E> where E : EntityBase
    {
        MenuListVM MenuList0VM { get; set; }
        bool IsPicker { get; set; }

        Command TitleSelectCommand { get; set; }
    }

    public class ContentVM<E> : BaseVM<E>,IContentVM<E> where E : EntityBase
    {
        #region Properties
        public MenuListVM MenuList0VM { get; set; }

        public bool IsTemp { get; set; }
        public bool IsPicker { get; set; }
        #endregion Properties

        #region Command
        public Command TitleSelectCommand { get; set; }
        #endregion Command

        public ContentVM() : this(false) { }
        public ContentVM(bool ispicker) 
        {
            this.IsPicker = ispicker;
            this.MenuList0VM = new MenuListVM(new List<TemplateEnum>() { TemplateEnum.T1 }, SelectionEnum.None);
            this.MenuList0VM.MenuSelectedChanged += this.OnMenuSelect;

            this.TitleSelectCommand = new Command(() => this.OnTitleSelect());
        }

        protected override Task<List<Task>> OnLoadFirstAsync(List<Task> tasks)
        {
            tasks.Add(this.MenuList0VM.OnInsertAsync(this.OnGetMenus0(new List<Menu>()), true));
            return base.OnLoadFirstAsync(tasks);
        }

        protected virtual void OnTitleSelect() { }
        protected virtual List<Menu> OnGetMenus0(List<Menu> menus)
        {
            return menus;
        }
    }
}
