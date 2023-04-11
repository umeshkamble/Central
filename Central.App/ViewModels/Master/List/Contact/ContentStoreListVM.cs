
namespace Central.App.ViewModels
{
    public class ContentStoreListVM : ContentContactListVM<StoreListVM,StoreVM,Store>
    {
        public ContentStoreListVM()  { }
        protected override StoreListVM OnGetPanelList(List<TemplateEnum> ts)
        {
            var selectionenum = this.SelectionEnum;
            var panelenum = PanelEnum.GridList;
            return new StoreListVM(ts, selectionenum,panelenum, false);
        }

        protected override void OnFilterSelect(Query<Store> querycurr, PageFilterV page, PageFilterVM<Store> vm)
        {
            //-----wajib di override-------//
            page = new PageFilterStoreV();
            vm = new PageFilterStoreVM(querycurr);
            vm.Execute += ((query) => {
                var db = (StoreService)this.Db;
                var keyword = db.GetFilterValue(query.Filters, FilterEnum.Keyword);
                var id_city = db.GetFilterValue(query.Filters, FilterEnum.City);

                this.CboId = id_city;
                this.Keyword = keyword;
                this.PanelListVM.LoadAsyncCommand.Execute(query);
            });

            base.OnFilterSelect(querycurr, page, vm);
        }

    }
}
