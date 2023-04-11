using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Central.App.ViewModels
{
    public class ContentPayCashListVM : ContentPayListVM<PayCashListVM,PayCashVM,PayCash>
    {
        public ContentPayCashListVM() { }
        protected override PayCashListVM OnGetPanelList(List<TemplateEnum> ts)
        {
            var selectionenum = this.SelectionEnum;
            var panelenum = PanelEnum.GridList;
            return new PayCashListVM(ts, selectionenum,panelenum, false);
        }

        protected override void OnFilterSelect(Query<PayCash> querycurr, PageFilterV page, PageFilterVM<PayCash> vm)
        {
            //-----wajib di override-------//
            page = new PageFilterPayCashV();
            vm = new PageFilterPayCashVM(querycurr);
            vm.Execute += ((query) => {
                var db = (PayCashService)Base.GetDb(nameof(PayCash), this.DbName);
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
