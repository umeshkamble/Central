

namespace Central.App.ViewModels
{
    public class ProductWarehouseListVM : PanelListVM<ProductWarehouseVM, ProductWarehouse>
    {
        public ProductWarehouseListVM(List<TemplateEnum> ts, SelectionEnum selectionenum, PanelEnum panelenum, bool incall) : base(ts, selectionenum,panelenum,nameof(ProductWarehouse), incall) { }
        protected override Task<ProductWarehouseVM> OnInsertAsync(ProductWarehouse entity,PanelEnum panelenum, int no, ImageSource imagesource, ProductWarehouseVM item)
        {
            item = new ProductWarehouseVM(entity, panelenum, no, imagesource);
            return base.OnInsertAsync(entity, panelenum, no, imagesource, item);
        }

        protected override async Task OnLoadFinishedAsync()
        {
            //---ketika load selesai, masukkan entity default----//
            if (this.IncAll){
                await this.OnInsertAsync(new ProductWarehouse {
                    Id = "Semua",
                    Nama = "Semua"
                });
            }

            await base.OnLoadFinishedAsync();
        }
    }

}
