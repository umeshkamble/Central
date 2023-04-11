

namespace Central.App.ViewModels
{
    public class CustomerListVM : ContactListVM<CustomerVM, Customer>
    {
        public CustomerListVM(List<TemplateEnum> ts, SelectionEnum selectionenum, PanelEnum panelenum, bool incall) : base(ts, selectionenum, panelenum, nameof(Customer), incall) { }
        protected override Task<CustomerVM> OnInsertAsync(Customer entity, PanelEnum panelenum, int no, ImageSource imagesource, CustomerVM item)
        {
            item = new CustomerVM(entity, panelenum, no, imagesource);
            return base.OnInsertAsync(entity, panelenum, no, imagesource, item);
        }
   
        protected override async Task OnLoadFinishedAsync()
        {
            //---ketika load selesai, masukkan entity default----//
            if (this.IncAll){
                await this.OnInsertAsync(new Customer { 
                    Id = "Semua",
                    Nama = "Semua"
                });
            }

            await base.OnLoadFinishedAsync();
        }
    }

}
