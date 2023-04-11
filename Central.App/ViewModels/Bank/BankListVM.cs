

namespace Central.App.ViewModels
{
    public class BankListVM : PanelListVM<BankVM, Bank>
    {
        public BankListVM(List<TemplateEnum> ts, SelectionEnum selectionenum, PanelEnum panelenum, bool incall) : base(ts, selectionenum, panelenum, nameof(Bank), incall) { }
        protected override Task<BankVM> OnInsertAsync(Bank entity, PanelEnum panelenum, int no, ImageSource imagesource, BankVM item)
        {
            item = new BankVM(entity, panelenum, no, imagesource);
            return base.OnInsertAsync(entity, panelenum, no, imagesource, item);
        }

        protected override async Task OnLoadFinishedAsync()
        {
            //---ketika load selesai, masukkan entity default----//
            if (this.IncAll){
                await this.OnInsertAsync(new Bank { 
                    Id = "Semua",
                    Nama = "Semua"
                });
            }

            await base.OnLoadFinishedAsync();
        }
    }

}
