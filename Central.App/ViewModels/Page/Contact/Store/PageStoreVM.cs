namespace Central.App.ViewModels
{
    public class PageStoreVM : PageContactVM<ContentStoreListVM, StoreListVM, StoreVM, Store>
    {
        public PageStoreVM() : base("Store", "Store list in this account.", nameof(PageStoreEditV)) { }
        protected override ContentStoreListVM OnGetContentListVM()
        {
            return new ContentStoreListVM();
        }
        
        protected override StoreVM OnGetInfoVM()
        {
            var vm = new StoreVM(PanelEnum.Info);
            vm.Select += ((item) => this.OnMenuSelect(MenuEnum.OpenStore));
            return vm;
        }
     
        public override async void OnMenuSelect(MenuEnum menu)
        {
            switch (menu) {
                case MenuEnum.OpenStore: {
                        var id = this.IdSelected;
                        var db = (StoreService)Base.GetDb(nameof(Store));
                        var store = await db.Get(id);
                        App.Current.MainPage = new AppShell2(store);
                        break; 
                    }
                default: base.OnMenuSelect(menu);break;
            }
           
        }
    }
}
