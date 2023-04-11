

namespace Central.App.ViewModels
{
    public class PMListVM : PanelListVM<PMVM, PM>
    {
        public PMListVM(List<TemplateEnum> ts, SelectionEnum selectionenum, PanelEnum panelenum, bool incall) : base(ts, selectionenum, panelenum, nameof(PM), incall) { }
        protected override Task<PMVM> OnInsertAsync(PM entity, PanelEnum panelenum, int no, ImageSource imagesource, PMVM item)
        {
            item = new PMVM(entity, panelenum, no, imagesource);
            return base.OnInsertAsync(entity, panelenum, no, imagesource, item);
        }

        protected override async Task OnLoadFinishedAsync()
        {
            //---ketika load selesai, masukkan entity default----//
            if (this.IncAll){
                await this.OnInsertAsync(new PM { 
                    Id = "Semua",
                    Nama = "Semua",
                    NoReferensis = "Semua"
                });
            }

            await base.OnLoadFinishedAsync();
        }
    }

}
