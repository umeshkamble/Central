

namespace Central.App.ViewModels
{
    public class PhoneListVM : PanelListVM<PhoneVM, Phone>
    {
        public PhoneListVM(List<TemplateEnum> ts, SelectionEnum selectionenum, PanelEnum panelenum) : base(ts, selectionenum, panelenum, "Phone", false) { }
        protected override Task<PhoneVM> OnInsertAsync(Phone entity, PanelEnum panelenum, int no, ImageSource imagesource, PhoneVM item)
        {
            item = new PhoneVM(entity, panelenum, no, imagesource);
            return base.OnInsertAsync(entity, panelenum, no, imagesource, item);
        }
    }

}
