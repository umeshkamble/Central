

namespace Central.App.ViewModels
{
    public class ContentSalesmanListVM : ContentContactListVM<SalesmanListVM,SalesmanVM,Salesman>
    {
        public ContentSalesmanListVM()  { }
        protected override SalesmanListVM OnGetPanelList(List<TemplateEnum> ts)
        {
            var selectionenum = this.SelectionEnum;
            var panelenum = PanelEnum.GridList;

            return new SalesmanListVM(ts, selectionenum, panelenum, false);
        }

        protected override void OnFilterSelect(Query<Salesman> querycurr, PageFilterV page, PageFilterVM<Salesman> vm)
        {
            //-----wajib di override-------//
            page = new PageFilterSalesmanV();
            vm = new PageFilterSalesmanVM(querycurr);
            vm.Execute += ((query) => {
                var db = (SalesmanService)Base.GetDb(nameof(Salesman));
                var keyword = db.GetFilterValue(query.Filters, FilterEnum.Keyword);
                var id_city = db.GetFilterValue(query.Filters, FilterEnum.City);

                this.CboId = id_city;
                this.Keyword = keyword;
                this.PanelListVM.LoadCommand.Execute(query);
            });

            base.OnFilterSelect(querycurr, page, vm);
        }

    }
}
