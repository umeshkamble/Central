using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Central.App.ViewModels
{
    public class ContentProductWarehouseListVM : ContentListVM<ProductWarehouseListVM,ProductWarehouseVM,ProductWarehouse>
    {
        public ContentProductWarehouseListVM() : base(new List<TemplateEnum>() { TemplateEnum.List, TemplateEnum.Grid }) { }
        protected override ProductWarehouseListVM OnGetPanelList(List<TemplateEnum> ts)
        {
            var selectionenum = this.SelectionEnum;
            var panelenum = PanelEnum.GridList;
            return new ProductWarehouseListVM(ts, selectionenum,panelenum, false);
        }

        protected override void OnFilterSelect(Query<ProductWarehouse> querycurr, PageFilterV page, PageFilterVM<ProductWarehouse> vm)
        {
            //-----wajib di override-------//
            page = new PageFilterProductWarehouseV();
            vm = new PageFilterProductWarehouseVM(querycurr);
            vm.Execute += ((query) => {
                var db = (ProductWarehouseService)Base.GetDb(nameof(ProductWarehouse));
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
