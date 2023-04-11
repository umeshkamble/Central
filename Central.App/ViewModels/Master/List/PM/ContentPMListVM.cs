using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Central.App.ViewModels
{
    public class ContentPMListVM : ContentListVM<PMListVM,PMVM,PM>
    {
        public ContentPMListVM() : base(new List<TemplateEnum>() { TemplateEnum.List, TemplateEnum.Grid }) { }
        protected override PMListVM OnGetPanelList(List<TemplateEnum> ts)
        {
            var selectionenum = this.SelectionEnum;
            var panelenum = PanelEnum.GridList;
            return new PMListVM(ts, selectionenum,panelenum, false);
        }

        protected override void OnFilterSelect(Query<PM> querycurr, PageFilterV page, PageFilterVM<PM> vm)
        {
            //-----wajib di override-------//
            page = new PageFilterPMV();
            vm = new PageFilterPMVM(querycurr);
            vm.Execute += ((query) => {
                var db = (PMService)Base.GetDb(nameof(PM), this.DbName);
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
