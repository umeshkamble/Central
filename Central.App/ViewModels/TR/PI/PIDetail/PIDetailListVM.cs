using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Central.App.ViewModels
{
    public class PIDetailListVM : TRDetailListVM<PIDetailVM,PIDetail>
    {
        public PIDetailListVM(List<TemplateEnum> ts, SelectionEnum selectionenum, PanelEnum panelenum) : base(ts, selectionenum, panelenum, false) { }
        protected override Task<PIDetailVM> OnInsertAsync(PIDetail entity, PanelEnum panelenum, int no, ImageSource imagesource, PIDetailVM item)
        {
            item = new PIDetailVM(entity, panelenum, no, imagesource);
            return base.OnInsertAsync(entity, panelenum, no, imagesource, item);
        }
    }
}
