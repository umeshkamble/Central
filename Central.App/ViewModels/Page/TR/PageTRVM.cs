using Contact = Central.Library.Contact;

namespace Central.App.ViewModels
{
    public class PageTRVM<CListVM,HVMList,HVM,H,DVMList,DVM,D,C> : PageMasterVM<CListVM, HVMList, HVM, H>
                                                                    where CListVM : ContentTRListVM<HVMList,HVM,H,DVMList,DVM,D,C>
                                                                    where HVMList : TRListVM<HVM,H,DVMList,DVM, D, C>
                                                                    where HVM : TRVM<H,DVMList,DVM, D, C>
                                                                    where DVMList : TRDetailListVM<DVM,D>
                                                                    where DVM : TRDetailVM<D>
                                                                    where H : TR<D>
                                                                    where D : TRDetail
                                                                    where C : Contact

    {
        public PageTRVM(string title1, string title2, string pageeditname) : base(title1,title2,pageeditname) { }
    }
}
