
using Contact = Central.Library.Contact;

namespace Central.App.ViewModels
{
    public class ContactListVM<VM,C> : PanelListVM<VM, C> where VM : ContactVM<C>
                                                          where C : Contact
    {
        public ContactListVM(List<TemplateEnum> ts, SelectionEnum selectionenum, PanelEnum panelenum, string tname, bool incall) : base(ts, selectionenum, panelenum, tname, incall) { }
    }

}
