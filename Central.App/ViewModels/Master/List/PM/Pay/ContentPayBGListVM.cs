using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Central.App.ViewModels
{
    public class ContentPayBGListVM : ContentPayListVM<PayBGListVM,PayBGVM,PayBG>
    {
        public ContentPayBGListVM() { }
        protected override PayBGListVM OnGetPanelList(List<TemplateEnum> ts)
        {
            var selectionenum = this.SelectionEnum;
            var panelenum = PanelEnum.GridList;
            return new PayBGListVM(ts, selectionenum,panelenum, false);
        }

        protected override void OnFilterSelect(Query<PayBG> querycurr, PageFilterV page, PageFilterVM<PayBG> vm)
        {
            //-----wajib di override-------//
            page = new PageFilterPayBGV();
            vm = new PageFilterPayBGVM(querycurr);
            vm.Execute += ((query) => {
                var db = (PayBGService)Base.GetDb(nameof(PayBG), this.DbName);
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
