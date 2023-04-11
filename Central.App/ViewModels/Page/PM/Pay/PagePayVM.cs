
using Pay = Central.Library.Pay;

namespace Central.App.ViewModels
{
    public class PagePayVM<CListPVM,PVMList,PVM,P> : PageMasterVM<CListPVM, PVMList, PVM, P>
                                                                where CListPVM : ContentPayListVM<PVMList, PVM, P>
                                                                where PVMList : PayListVM<PVM, P>
                                                                where PVM : PayVM<P>
                                                                where P : Pay
    {
        public PagePayVM(string title1, string title2, string pageditname) : base(title1, title2, pageditname) { }
    }
}
