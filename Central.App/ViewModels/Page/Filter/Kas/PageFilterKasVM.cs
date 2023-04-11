using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Central.App.ViewModels
{
    public class PageFilterKasVM : PageFilterVM<Kas>
    {
        public PageFilterKasVM(Query<Kas> query) : base(query) { }
    }
}
