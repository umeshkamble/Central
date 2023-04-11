using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Central.App.ViewModels
{
    public class ContentProductBrandListVM : ContentListVM<ProductBrandListVM,ProductBrandVM,ProductBrand>
    {
        public ContentProductBrandListVM() : base(new List<TemplateEnum>() { TemplateEnum.List, TemplateEnum.Grid }) { }
        protected override ProductBrandListVM OnGetPanelList(List<TemplateEnum> ts)
        {
            var selectionenum = this.SelectionEnum;
            var panelenum = PanelEnum.GridList;
            return new ProductBrandListVM(ts, selectionenum,panelenum, false);
        }

        protected override void OnFilterSelect(Query<ProductBrand> querycurr, PageFilterV page, PageFilterVM<ProductBrand> vm)
        {
            //-----wajib di override-------//
            page = new PageFilterProductBrandV();
            vm = new PageFilterProductBrandVM(querycurr);
            vm.Execute += ((query) => {
                var db = (ProductBrandService)Base.GetDb(nameof(ProductBrand));
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
