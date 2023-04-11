namespace Central.App.ViewModels
{
    public interface IFilterPageVM<E> where E : EntityBase
    { 
        Query<E> Query { get; set; }
        SortGrupListVM SortGrupListVM { get; set; }
        KeywordListVM KeywordListVM { get; set; }

        Command ExecuteCommand { get; set; }
    }

    public class PageFilterVM<E> : PageVM<E>, IFilterPageVM<E> where E : EntityBase
    {
        #region Properties
        public Query<E> Query { get; set; }    
        public SortGrupListVM SortGrupListVM { get; set; }
        public KeywordListVM KeywordListVM { get; set; }
        #endregion Properties

        #region Command
        public Command ExecuteCommand { get; set; }
        #endregion Command

        #region Event
        public delegate void FilterEventHandler(Query<E> query);
        public event FilterEventHandler Execute;
        #endregion Event

        public PageFilterVM(Query<E> query) : base("", "")
        {
            this.Title1 = this.EntityName;
            this.Title2 = "Filter & Sort Data";
            this.Query = query;

            var keyword = this.Db.GetFilterValue(this.Query.Filters, FilterEnum.Keyword);
            var isviewkeyword = keyword.Trim() == "" ? false : true;

            var sortdefs = this.Db.GetSortCollection();
            this.SortGrupListVM = new SortGrupListVM(SelectionEnum.SingleDeselect);
            this.SortGrupListVM.LoadFinished += (() => {
                this.SortGrupListVM.EntitySelecteds = query.Sorts; 
            });
            this.SortGrupListVM.InsertCommand.Execute(sortdefs);

            this.KeywordListVM = new KeywordListVM(new List<TemplateEnum>() { TemplateEnum.Grid }, SelectionEnum.SingleDeselect, PanelEnum.GridList, isviewkeyword);
            this.KeywordListVM.LoadFinished += (() => {
                if (isviewkeyword) this.KeywordListVM.OnSelectFirst();
            });

            if (isviewkeyword){
                var keywords = new List<Keyword>() {
                    new Keyword(){ Text = keyword }
                };

                this.KeywordListVM.OnSetTitle("Keyword");
                this.KeywordListVM.InsertCommand.Execute(keywords);
            }

            this.ExecuteCommand = new Command(() => {
                var filters = Db.GetFilterDef();
                var filterEtcs = this.OnGetFilters(new List<Filter<E>>());
                filters.AddRange(filterEtcs);
                
                var sorts = this.OnGetSorts();
                var limit = this.Query.Limit;
                var skip = 0;

                this.Query = this.Db.GetQuery(filters, sorts, limit, skip);
                if (this.Execute != null) this.Execute(this.Query);
                this.OnMenuSelect(MenuEnum.Back);
            });

            this.LoadAsyncCommand.Execute(null);
        }

        private List<Sort> OnGetSorts()
        {
            return this.SortGrupListVM.EntitySelecteds;
        }
        
        protected virtual List<Filter<E>> OnGetFilters(List<Filter<E>> filters)
        {
            var vm = this.KeywordListVM.ItemSelectedFirst;
            if (vm != null) {
                var keyword = vm.Caption;
                var filterDef = this.Db.GetFilterByKeyword(keyword);
                filters.Add(new Filter<E>(FilterEnum.Keyword, filterDef, keyword));
            }
            
            return filters;
        }

    }
}
