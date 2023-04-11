using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Central.App.ViewModels
{
    public class ContentProductListVM : ContentListVM<ProductListVM,ProductVM,Product>
    {
        #region Properties
        private LevelHrgEnum LevelHrg_;
        public LevelHrgEnum LevelHrg
        {
            set {
                if (LevelHrg_ == value) return;

                LevelHrg_ = value;
                ((ProductListVM)this.PanelListVM).LevelHrg = LevelHrg_;
            }
            get { return ((ProductListVM)this.PanelListVM).LevelHrg; }
        }
        #endregion Properties

        public ContentProductListVM() : base(new List<TemplateEnum>() { TemplateEnum.Grid, TemplateEnum.List }) { }
        protected override ProductListVM OnGetPanelList(List<TemplateEnum> ts)
        {
            var selectionenum = this.SelectionEnum;
            var panelenum = PanelEnum.GridList;

            return new ProductListVM(ts, selectionenum, panelenum, false);
        }

        protected override void OnFilterSelect(Query<Product> querycurr, PageFilterV page, PageFilterVM<Product> vm)
        {
            //-----wajib di override-------//
            page = new PageFilterProductV();
            vm = new PageFilterProductVM(querycurr);
            vm.Execute += ((query) => {
                var db = (ProductService)Base.GetDb(nameof(Product));
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
