

namespace Central.App.ViewModels
{
    public class ProductListVM : PanelListVM<ProductVM, Product>
    {
        #region Properties
        private LevelHrgEnum LevelHrg_ = LevelHrgEnum.HrgApp;
        public LevelHrgEnum LevelHrg
        {
            set {
                if (LevelHrg_ == value) return;

                LevelHrg_ = value;
                this.RefreshCommand.Execute(null);
            }
            get { return LevelHrg_; }
        }
        #endregion Properties

        private int Index { get; set; } = 0;

        public ProductListVM(List<TemplateEnum> ts, SelectionEnum selectionenum, PanelEnum panelenum, bool incall) : base(ts, selectionenum, panelenum, nameof(Product), incall) { }
        protected override Task<ProductVM> OnInsertAsync(Product entity, PanelEnum panelenum, int no, ImageSource imagesource, ProductVM item)
        {
            this.Index++;
            if (this.Index > 5) this.Index = 1;
            imagesource = $"product{this.Index}.jpg";

            entity.SetLevelHrg(this.LevelHrg);
            item = new ProductVM(entity, panelenum, no, imagesource);
            return base.OnInsertAsync(entity, panelenum, no, imagesource, item);
        }

        protected override async Task OnLoadFinishedAsync()
        {
            //---ketika load selesai, masukkan entity default----//
            if (this.IncAll){
                await this.OnInsertAsync(new Product { 
                    Id = "Semua",
                    Nama = "Semua"
                });
            }

            await base.OnLoadFinishedAsync();
        }    
    }

}
