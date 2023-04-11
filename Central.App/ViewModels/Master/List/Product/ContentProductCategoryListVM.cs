using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Central.App.ViewModels
{
    public class ContentProductCategoryListVM : ContentListVM<ProductCategoryListVM,ProductCategoryVM,ProductCategory>
    {
        public ContentProductCategoryListVM() : base(new List<TemplateEnum>() { TemplateEnum.List, TemplateEnum.Grid }) { }
        protected override ProductCategoryListVM OnGetPanelList(List<TemplateEnum> ts)
        {
            var selectionenum = this.SelectionEnum;
            var panelenum = PanelEnum.GridList;
            return new ProductCategoryListVM(ts, selectionenum,panelenum, false);
        }

        protected override void OnFilterSelect(Query<ProductCategory> querycurr, PageFilterV page, PageFilterVM<ProductCategory> vm)
        {
            //-----wajib di override-------//
            page = new PageFilterProductCategoryV();
            vm = new PageFilterProductCategoryVM(querycurr);
            vm.Execute += ((query) => {
                var db = (ProductCategoryService)Base.GetDb(nameof(ProductCategory));
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
