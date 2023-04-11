using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Central.App.ViewModels
{
    public class ContentPayCekListVM : ContentPayListVM<PayCekListVM,PayCekVM,PayCek>
    {
        public ContentPayCekListVM() { }
        protected override PayCekListVM OnGetPanelList(List<TemplateEnum> ts)
        {
            var selectionenum = this.SelectionEnum;
            var panelenum = PanelEnum.GridList;
            return new PayCekListVM(ts, selectionenum,panelenum, false);
        }

        protected override void OnFilterSelect(Query<PayCek> querycurr, PageFilterV page, PageFilterVM<PayCek> vm)
        {
            //-----wajib di override-------//
            page = new PageFilterPayCekV();
            vm = new PageFilterPayCekVM(querycurr);
            vm.Execute += ((query) => {
                var db = (PayCekService)Base.GetDb(nameof(PayCek), this.DbName);
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
