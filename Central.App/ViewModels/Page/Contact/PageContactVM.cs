
using Contact = Central.Library.Contact;

namespace Central.App.ViewModels
{
    public class PageContactVM<CListVM,VMList,VM,E> : PageMasterVM<CListVM, VMList, VM, E>
                                                                where CListVM : ContentContactListVM<VMList, VM, E>
                                                                where VMList : ContactListVM<VM, E>
                                                                where VM : ContactVM<E>
                                                                where E : Contact
    {
        public PageContactVM(string title1, string title2, string pageditname) : base(title1, title2, pageditname) { }
    }
}
