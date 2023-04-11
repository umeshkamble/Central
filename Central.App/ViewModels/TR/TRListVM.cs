

using Contact = Central.Library.Contact;

namespace Central.App.ViewModels
{
    public class TRListVM<HVM,H,DVMList,DVM,D,C> : PanelListVM<HVM, H> where HVM : TRVM<H, DVMList, DVM, D, C>
                                                                       where DVMList : TRDetailListVM<DVM,D>
                                                                       where DVM : TRDetailVM<D>
                                                                       where H : TR<D>
                                                                       where D : TRDetail
                                                                       where C : Contact
    {
        public TRListVM(List<TemplateEnum> ts, SelectionEnum selectionenum, PanelEnum panelenum, bool incall) : base(ts, selectionenum, panelenum, typeof(H).Name, incall) { }
    }

}
