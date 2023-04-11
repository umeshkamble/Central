using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Contact = Central.Library.Contact;

namespace Central.App.ViewModels
{
    public class ContentTRListVM<HVMList,HVM,H,DVMList,DVM,D,C> : ContentListVM<HVMList,HVM,H> where HVMList : TRListVM<HVM,H,DVMList,DVM,D,C>
                                                                                               where HVM : TRVM<H, DVMList, DVM, D, C>
                                                                                               where DVMList : TRDetailListVM<DVM,D>
                                                                                               where DVM : TRDetailVM<D>
                                                                                               where H : TR<D>
                                                                                               where D : TRDetail
                                                                                               where C : Contact
    {
        public ContentTRListVM() : base(new List<TemplateEnum>() { TemplateEnum.List, TemplateEnum.Grid }) { }
    }
}
