using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Central.App.ViewModels
{
    public class PageFilterPIVM : PageFilterTRVM<PI,PIDetail>
    {
        public PageFilterPIVM(Query<PI> query) : base(query) { }
    }
}
