using Central.App.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Central.App.ViewModels
{
    public class ContentPIListVM : ContentTRListVM<PIListVM, PIVM, PI, PIDetailListVM,PIDetailVM, PIDetail,Suplier>
    {
        public ContentPIListVM()  { }
        protected override PIListVM OnGetPanelList(List<TemplateEnum> ts)
        {
            var selectionenum = this.SelectionEnum;
            return new PIListVM(ts, selectionenum, PanelEnum.GridList, false);
        }

        protected override void OnFilterSelect(Query<PI> querycurr, PageFilterV page, PageFilterVM<PI> vm)
        {
            /*
            nanti perlu aktifkan jika pagefilterPI sudah ada


            //-----wajib di override-------//
            page = new PageFilterPIV();
            vm = new PageFilterPIVM(querycurr);
            vm.Execute += ((query) => {
                var db = (PIService)Base.GetDb(nameof(PI));
                var keyword = db.GetFilterValue(query.Filters, FilterEnum.Keyword);
                var id_city = db.GetFilterValue(query.Filters, FilterEnum.City);

                this.CboId = id_city;
                this.Keyword = keyword;
                this.PanelListVM.LoadCommand.Execute(query);
            });
            */

            base.OnFilterSelect(querycurr, page, vm);
        }
    }
}
