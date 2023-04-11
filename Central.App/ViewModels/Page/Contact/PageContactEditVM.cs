
using Contact = Central.Library.Contact;

namespace Central.App.ViewModels
{
    public class PageContactEditVM<VM,C> : PageMasterEditVM<VM, C>  where VM : PanelVM<C>
                                                              where C : Contact 
    {
        public PageContactEditVM()  { }
    }
}
