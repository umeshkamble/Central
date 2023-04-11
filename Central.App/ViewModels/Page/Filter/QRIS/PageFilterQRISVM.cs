using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Central.App.ViewModels
{
    public class PageFilterQRISVM : PageFilterVM<QRIS>
    {
        public PageFilterQRISVM(Query<QRIS> query) : base(query) { }
    }
}
