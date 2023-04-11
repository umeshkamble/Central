
namespace Central.App.ViewModels
{
    public class PagePayEditVM<PVM,P> : PageMasterEditVM<PVM, P> where PVM : PanelVM<P>
                                                                 where P : Pay 
    {
        public PagePayEditVM()  { }
    }
}
