using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Central.App.ViewModels
{
    public class ContentPayTransferListVM : ContentPayListVM<PayTransferListVM,PayTransferVM,PayTransfer>
    {
        public ContentPayTransferListVM() { }
        protected override PayTransferListVM OnGetPanelList(List<TemplateEnum> ts)
        {
            var selectionenum = this.SelectionEnum;
            var panelenum = PanelEnum.GridList;
            return new PayTransferListVM(ts, selectionenum,panelenum, false);
        }

        protected override void OnFilterSelect(Query<PayTransfer> querycurr, PageFilterV page, PageFilterVM<PayTransfer> vm)
        {
            //-----wajib di override-------//
            page = new PageFilterPayTransferV();
            vm = new PageFilterPayTransferVM(querycurr);
            vm.Execute += ((query) => {
                var db = (PayTransferService)Base.GetDb(nameof(PayTransfer), this.DbName);
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
