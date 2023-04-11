

namespace Central.App.ViewModels
{
    public class AddressListVM : PanelListVM<AddressVM, Address>
    {
        public AddressListVM(List<TemplateEnum> ts, SelectionEnum selectionenum, PanelEnum panelenum) : base(ts, selectionenum, panelenum, "Address", false) { }
        protected override Task<AddressVM> OnInsertAsync(Address entity, PanelEnum panelenum, int no, ImageSource imagesource, AddressVM item)
        {
            item = new AddressVM(entity, panelenum, no, imagesource);
            return base.OnInsertAsync(entity, panelenum, no, imagesource, item);
        }
    }

}
