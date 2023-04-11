

namespace Central.App.ViewModels
{
    public class PageFilterPMVM : PageFilterVM<PM>
    {
        public CityListVM CityListVM { get; set; }
        public PageFilterPMVM(Query<PM> query) : base(query)
        {
            this.CityListVM = new CityListVM(new List<TemplateEnum>() { TemplateEnum.Grid }, SelectionEnum.Single, PanelEnum.GridList, true);
            this.CityListVM.LoadFinished += (() => {
                var id = this.Db.GetFilterValue(this.Query.Filters, FilterEnum.City);
                if (id == "") id = "Semua";
                this.CityListVM.OnSelect(id);
            });

            this.CityListVM.OnSetTitle("Kota");
            this.CityListVM.LoadCommand.Execute(null);
        }

        protected override List<Filter<PM>> OnGetFilters(List<Filter<PM>> filters)
        {
            var db = (PMService)this.Db;
            var vm = this.CityListVM.ItemSelectedFirst;
            if (vm != null){
                var id = vm.Id;
                //var filterDef = db.GetFilterByCity(id);
                //filters.Add(new Filter<PM>(FilterEnum.City, filterDef, id));
            }

            return base.OnGetFilters(filters);
        }
    }
}
