using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Central.App.ViewModels
{
    public class ContentBankListVM : ContentListVM<BankListVM,BankVM,Bank>
    {
        public ContentBankListVM() : base(new List<TemplateEnum>() { TemplateEnum.List, TemplateEnum.Grid }) { }
        protected override BankListVM OnGetPanelList(List<TemplateEnum> ts)
        {
            var selectionenum = this.SelectionEnum;
            var panelenum = PanelEnum.GridList;
            return new BankListVM(ts, selectionenum,panelenum, false);
        }

        protected override void OnFilterSelect(Query<Bank> querycurr, PageFilterV page, PageFilterVM<Bank> vm)
        {
            //-----wajib di override-------//
            page = new PageFilterBankV();
            vm = new PageFilterBankVM(querycurr);
            vm.Execute += ((query) => {
                var db = (BankService)Base.GetDb(nameof(Bank), this.DbName);
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
