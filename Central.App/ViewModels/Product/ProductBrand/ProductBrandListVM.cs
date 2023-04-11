

namespace Central.App.ViewModels
{
    public class ProductBrandListVM : PanelListVM<ProductBrandVM, ProductBrand>
    {
        public ProductBrandListVM(List<TemplateEnum> ts, SelectionEnum selectionenum, PanelEnum panelenum, bool incall) : base(ts, selectionenum,panelenum, nameof(ProductBrand), incall) { }
        protected override Task<ProductBrandVM> OnInsertAsync(ProductBrand entity,PanelEnum panelenum, int no, ImageSource imagesource, ProductBrandVM item)
        {
            item = new ProductBrandVM(entity,panelenum, no, imagesource);
            return base.OnInsertAsync(entity, panelenum, no, imagesource, item);
        }

        protected override async Task OnLoadFinishedAsync()
        {
            //---ketika load selesai, masukkan entity default----//
            if (this.IncAll){
                await this.OnInsertAsync(new ProductBrand { 
                    Id = "Semua",
                    Nama = "Semua"
                });
            }

            await base.OnLoadFinishedAsync();
        }
    }

}
