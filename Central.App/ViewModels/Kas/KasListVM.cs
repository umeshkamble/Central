

namespace Central.App.ViewModels
{
    public class KasListVM : PanelListVM<KasVM, Kas>
    {
        public KasListVM(List<TemplateEnum> ts, SelectionEnum selectionenum, PanelEnum panelenum, bool incall) : base(ts, selectionenum,panelenum, nameof(Kas), incall) { }
        protected override Task<KasVM> OnInsertAsync(Kas entity, PanelEnum panelenum, int no, ImageSource imagesource, KasVM item)
        {
            item = new KasVM(entity, panelenum, no, imagesource);
            return base.OnInsertAsync(entity, panelenum, no, imagesource, item);
        }

        protected override async Task OnLoadFinishedAsync()
        {
            //---ketika load selesai, masukkan entity default----//
            if (this.IncAll) {
                await this.OnInsertAsync(new Kas {
                    Id = "Semua",
                    Nama = "Semua"
                });
            }

            await base.OnLoadFinishedAsync();
        }
    }

}
