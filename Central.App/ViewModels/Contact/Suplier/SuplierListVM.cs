

namespace Central.App.ViewModels
{
    public class SuplierListVM : ContactListVM<SuplierVM, Suplier>
    {
        public Command LoadByCityCommand { get; set; }
        public SuplierListVM(List<TemplateEnum> ts, SelectionEnum selectionenum, PanelEnum panelenum, bool incall) : base(ts, selectionenum, panelenum, nameof(Suplier), incall)
        {
            this.LoadByCityCommand = new Microsoft.Maui.Controls.Command<string>((string id) => this.OnLoadByCity(id));
        }

        protected override Task<SuplierVM> OnInsertAsync(Suplier entity, PanelEnum panelenum, int no, ImageSource imagesource, SuplierVM item)
        {
            item = new SuplierVM(entity, panelenum, no, imagesource);
            return base.OnInsertAsync(entity, panelenum, no, imagesource, item);
        }

        private void OnLoadByCity(string id)
        {
            this.OnLog($"LoadByCity(string id) : {id}");
            var db = (SuplierService)this.Db;
            var filterDef = db.GetFilterByCity(id);
            var filters = this.QueryDef.Filters.ToList();
            var sorts = this.QueryDef.Sorts.ToList();
            var limit = this.QueryDef.Limit;

            filters.Add(new Filter<Suplier>(FilterEnum.City, filterDef, id));
            var query = this.Db.GetQuery(filters, sorts, limit, 0);
            this.LoadCommand.Execute(query);
        }

        
        protected override async Task OnLoadFinishedAsync()
        {
            //---ketika load selesai, masukkan entity default----//
            if (this.IncAll){
                await this.OnInsertAsync(new Suplier { 
                    Id = "Semua",
                    Nama = "Semua"
                });
            }

            await base.OnLoadFinishedAsync();
        }
    }

}
