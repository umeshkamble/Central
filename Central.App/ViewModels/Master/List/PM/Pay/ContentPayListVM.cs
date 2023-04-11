using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Central.App.ViewModels
{
    public class ContentPayListVM<PVMList,PVM,P> : ContentListVM<PVMList,PVM,P> where PVMList : PayListVM<PVM,P>
                                                                                where PVM : PayVM<P>
                                                                                where P : Pay
    {
        public ContentPayListVM() : base(new List<TemplateEnum>() { TemplateEnum.List, TemplateEnum.Grid }) { }
    }
}
