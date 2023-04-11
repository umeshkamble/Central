

namespace Central.App.ViewModels
{
    public class StoreListVM : ContactListVM<StoreVM, Store>
    {
        public StoreListVM(List<TemplateEnum> ts, SelectionEnum selectionenum, PanelEnum panelenum, bool incall) : base(ts, selectionenum, panelenum, nameof(Store), incall) { }
        protected override Task<StoreVM> OnInsertAsync(Store entity,PanelEnum panelenum, int no, ImageSource imagesource, StoreVM item)
        {
            item = new StoreVM(entity, panelenum, no, imagesource);
            return base.OnInsertAsync(entity, panelenum, no, imagesource, item);
        }

        protected override async Task OnLoadFinishedAsync()
        {
            //---ketika load selesai, masukkan entity default----//
            if (this.IncAll) {
                await this.OnInsertAsync(new Store {
                    Id = "Semua",
                    Nama = "Semua"
                });
            }

            await base.OnLoadFinishedAsync();
        }
    }

}
