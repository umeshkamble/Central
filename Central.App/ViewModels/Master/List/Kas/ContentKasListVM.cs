using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Central.App.ViewModels
{
    public class ContentKasListVM : ContentListVM<KasListVM,KasVM,Kas>
    {
        public ContentKasListVM() : base(new List<TemplateEnum>() { TemplateEnum.List, TemplateEnum.Grid }) { }
        protected override KasListVM OnGetPanelList(List<TemplateEnum> ts)
        {
            var selectionenum = this.SelectionEnum;
            var panelenum = PanelEnum.GridList;

            return new KasListVM(ts, selectionenum,panelenum, false);
        }

        protected override void OnFilterSelect(Query<Kas> querycurr, PageFilterV page, PageFilterVM<Kas> vm)
        {
            //-----wajib di override-------//
            page = new PageFilterKasV();
            vm = new PageFilterKasVM(querycurr);
            vm.Execute += ((query) => {
                var db = (KasService)Base.GetDb(nameof(Kas));
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
