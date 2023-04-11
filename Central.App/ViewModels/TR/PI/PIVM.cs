using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Central.App.ViewModels
{
    public class PIVM : TRVM<PI, PIDetailListVM, PIDetailVM, PIDetail, Suplier>
    {
        public PIVM(PanelEnum panelenum) : this(null, panelenum, 1, null) { }
        public PIVM(PI entity, PanelEnum panelenum, int no, ImageSource imagesource) : base(entity, panelenum, no, imagesource) { }

        protected override PIDetailListVM OnGetDetailListVM(PanelEnum panelenum)
        {
            return new PIDetailListVM(new List<TemplateEnum> { TemplateEnum.Edit1 }, SelectionEnum.Single, panelenum);
        }

        protected override PageTRDetailEditV OnGetPageEditV()
        {
            return new PagePIDetailEditV();
        }

        protected override PageTRDetailEditVM<PIDetailVM, PIDetail> OnGetPageEditVM()
        {
            return new PagePIDetailEditVM();
        }

        protected override async Task OnEditAsync(Product p, HSum hsum, PIDetail detail, bool isnew)
        {
            if (detail is null) detail = new PIDetail(p);
            await base.OnEditAsync(p, hsum, detail, isnew);
        }
    }

}
