
namespace Central.App.ViewModels
{
    public class CityListVM : PanelListVM<CityVM, City>
    {
        public CityListVM(List<TemplateEnum> ts, SelectionEnum selectionenum, PanelEnum panelenum, bool incall) : base(ts, selectionenum,panelenum, nameof(City), incall) { }
        protected override Task<CityVM> OnInsertAsync(City entity, PanelEnum panelenum, int no, ImageSource imagesource, CityVM item)
        {
            item = new CityVM(entity,panelenum, no, imagesource);
            return base.OnInsertAsync(entity, panelenum, no, imagesource, item);
        }

        protected override async Task OnLoadFinishedAsync()
        {
            //---ketika load selesai, masukkan entity default----//
            if (this.IncAll){
                await this.OnInsertAsync(new City { 
                    Id = "Semua",
                    Nama = "Semua"
                });
            }

            await base.OnLoadFinishedAsync();
        }
    }

}
