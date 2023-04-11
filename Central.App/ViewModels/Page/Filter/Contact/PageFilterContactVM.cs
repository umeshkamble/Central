
using Contact = Central.Library.Contact;

namespace Central.App.ViewModels
{
    public class PageFilterContactVM<C> : PageFilterVM<C> where C : Contact
    {
        public CityListVM CityListVM { get; set; }
        public PageFilterContactVM(Query<C> query) : base(query)
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

        protected override List<Filter<C>> OnGetFilters(List<Filter<C>> filters)
        {
            var db = (ContactService<C>)this.Db;
            var vm = this.CityListVM.ItemSelectedFirst;
            if (vm != null){
                var id = vm.Id;
                var filterDef = db.GetFilterByCity(id);
                filters.Add(new Filter<C>(FilterEnum.City, filterDef, id));
            }

            return base.OnGetFilters(filters);
        }
    }
}
