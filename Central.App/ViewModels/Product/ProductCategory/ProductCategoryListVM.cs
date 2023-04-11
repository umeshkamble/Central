

namespace Central.App.ViewModels
{
    public class ProductCategoryListVM : PanelListVM<ProductCategoryVM, ProductCategory>
    {
        public ProductCategoryListVM(List<TemplateEnum> ts, SelectionEnum selectionenum, PanelEnum panelenum, bool incall) : base(ts, selectionenum,panelenum, nameof(ProductCategory), incall) { }
        protected override Task<ProductCategoryVM> OnInsertAsync(ProductCategory entity,PanelEnum panelenum, int no, ImageSource imagesource, ProductCategoryVM item)
        {
            item = new ProductCategoryVM(entity,panelenum, no, imagesource);
            return base.OnInsertAsync(entity, panelenum, no, imagesource, item);
        }

        protected override async Task OnLoadFinishedAsync()
        {
            //---ketika load selesai, masukkan entity default----//
            if (this.IncAll) {
                await this.OnInsertAsync(new ProductCategory {
                    Id = "Semua",
                    Nama = "Semua"
                });
            }

            await base.OnLoadFinishedAsync();
        }
    }

}
