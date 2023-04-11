namespace Central.App.ViewModels
{
    public class PageProductVM : PageMasterVM<ContentProductListVM, ProductListVM, ProductVM, Product>
    {
        #region Properties
        private LevelHrgEnum LevelHrg_;
        public LevelHrgEnum LevelHrg
        {
            set {
                if (LevelHrg_ == value) return;
                LevelHrg_ = value;
                ((ContentProductListVM)this.ContentListVM).LevelHrg = LevelHrg_;
            }
            get { return ((ContentProductListVM)this.ContentListVM).LevelHrg; }
        }
        #endregion Properties

        public PageProductVM() : base("Produk", "Product list in this account.", nameof(PageProductEditV)) { }
        protected override ContentProductListVM OnGetContentListVM()
        {
            return new ContentProductListVM();
        }
       
        protected override ProductVM OnGetInfoVM()
        {
            return new ProductVM(PanelEnum.Info);
        }

    }
}
