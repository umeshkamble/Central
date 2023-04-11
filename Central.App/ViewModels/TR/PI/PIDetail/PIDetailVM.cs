using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Central.App.ViewModels
{
    public class PIDetailVM : TRDetailVM<PIDetail>
    {
        public PIDetailVM(PanelEnum panelenum) : this(null, panelenum, 1, null) { }
        public PIDetailVM(PIDetail entity, PanelEnum panelenum, int no, ImageSource imagesource) : base(entity,panelenum, no, imagesource) { }
    }
}
