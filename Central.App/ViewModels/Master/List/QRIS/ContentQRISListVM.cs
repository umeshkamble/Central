using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Central.App.ViewModels
{
    public class ContentQRISListVM : ContentListVM<QRISListVM,QRISVM,QRIS>
    {
        public ContentQRISListVM() : base(new List<TemplateEnum>() { TemplateEnum.List, TemplateEnum.Grid }) { }
        protected override QRISListVM OnGetPanelList(List<TemplateEnum> ts)
        {
            var selectionenum = this.SelectionEnum;
            var panelenum = PanelEnum.GridList;

            return new QRISListVM(ts, selectionenum, panelenum, false);
        }

        protected override void OnFilterSelect(Query<QRIS> querycurr, PageFilterV page, PageFilterVM<QRIS> vm)
        {
            //-----wajib di override-------//
            page = new PageFilterQRISV();
            vm = new PageFilterQRISVM(querycurr);
            vm.Execute += ((query) => {
                var db = (QRISService)Base.GetDb(nameof(QRIS));
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
