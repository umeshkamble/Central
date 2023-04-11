

namespace Central.App.ViewModels
{
    public class QRISListVM : PanelListVM<QRISVM, QRIS>
    {
        public QRISListVM(List<TemplateEnum> ts, SelectionEnum selectionenum, PanelEnum panelenum, bool incall) : base(ts, selectionenum,panelenum, nameof(QRIS), incall) { }
        protected override Task<QRISVM> OnInsertAsync(QRIS entity, PanelEnum panelenum, int no, ImageSource imagesource, QRISVM item)
        {
            item = new QRISVM(entity, panelenum, no, imagesource);
            return base.OnInsertAsync(entity, panelenum, no, imagesource, item);
        }

        protected override async Task OnLoadFinishedAsync()
        {
            //---ketika load selesai, masukkan entity default----//
            if (this.IncAll) {
                await this.OnInsertAsync(new QRIS {
                    Id = "Semua",
                    Nama = "Semua"
                });
            }

            await base.OnLoadFinishedAsync();
        }
    }

}
