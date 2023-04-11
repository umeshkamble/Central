
namespace Central.App.ViewModels
{
    public class ContentSuplierListVM : ContentContactListVM<SuplierListVM, SuplierVM, Suplier>
    {
        public ContentSuplierListVM()  { }
        protected override SuplierListVM OnGetPanelList(List<TemplateEnum> ts)
        {
            var selectionenum = this.SelectionEnum;
            var panelenum = PanelEnum.GridList;
            return new SuplierListVM(ts, selectionenum,panelenum, false);
        }

        protected override void OnFilterSelect(Query<Suplier> querycurr, PageFilterV page, PageFilterVM<Suplier> vm)
        {
            //-----wajib di override-------//
            page = new PageFilterSuplierV();
            vm = new PageFilterSuplierVM(querycurr);
            vm.Execute += ((query) => {
                var db = (SuplierService)Base.GetDb(nameof(Suplier));
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
