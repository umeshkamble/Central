using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Central.App.ViewModels
{
    public class PageFilterTRVM<H,D> : PageFilterVM<H> where H : TR<D>
                                                       where D : TRDetail
    {
        public PageFilterTRVM(Query<H> query) : base(query) { }
    }
}
