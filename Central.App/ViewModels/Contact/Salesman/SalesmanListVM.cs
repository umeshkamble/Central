


namespace Central.App.ViewModels
{
    public class SalesmanListVM : ContactListVM<SalesmanVM, Salesman>
    {
        #region Command
        public Command LoadByCityCommand { get; set; }
        #endregion Command

        public SalesmanListVM(List<TemplateEnum> ts, SelectionEnum selectionenum,PanelEnum panelenum, bool incall) : base(ts, selectionenum, panelenum, nameof(Salesman),incall) 
        {
            this.LoadByCityCommand = new Microsoft.Maui.Controls.Command<string>((string id) => this.LoadByCity(id));
        }

        protected override Task<SalesmanVM> OnInsertAsync(Salesman entity, PanelEnum panelenum, int no, ImageSource imagesource, SalesmanVM item)
        {
            item = new SalesmanVM(entity,panelenum, no, imagesource);
            return base.OnInsertAsync(entity, panelenum, no, imagesource, item);
        }

        private void LoadByCity(string id)
        {
            this.OnLog($"LoadByCity(string id) : {id}");
            var db = (SalesmanService)this.Db;
            var filterDef = db.GetFilterByCity(id);
            var filters = this.QueryDef.Filters.ToList();
            var sorts = this.QueryDef.Sorts.ToList();
            var limit = this.QueryDef.Limit;

            filters.Add(new Filter<Salesman>(FilterEnum.City, filterDef, id));
            var query = this.Db.GetQuery(filters, sorts, limit, 0);
            this.LoadCommand.Execute(query);
        }
    }

}
