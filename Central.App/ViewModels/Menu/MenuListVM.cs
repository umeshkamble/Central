namespace Central.App.ViewModels
{
    public class MenuListVM : PanelListVM<MenuVM, Menu>
    {
        public MenuListVM(List<TemplateEnum> ts, SelectionEnum selectionenum) : base(ts, selectionenum, PanelEnum.GridList, nameof(Menu), false) { }
        protected override Task<MenuVM> OnInsertAsync(Menu entity, PanelEnum panelenum, int no, ImageSource imagesource, MenuVM item)
        {
            item = new MenuVM(entity);
            return base.OnInsertAsync(entity, panelenum, no, imagesource, item);
        }

        public override void OnSelectedChanged(MenuVM item)
        {
            //base.OnSelectedChanged(item);
            this.OnMenuSelect(item.MenuEnum);
        }

        public MenuVM OnFind(MenuEnum menuenum)
        {
            return this.Items.AsEnumerable().Where(x => x.MenuEnum == menuenum).FirstOrDefault();
        }

        public void OnVisible(MenuEnum menuenum, bool isvisible)
        {
            var vm = this.OnFind(menuenum);
            if (vm != null) vm.IsVisible = isvisible;
        }
    }
}
