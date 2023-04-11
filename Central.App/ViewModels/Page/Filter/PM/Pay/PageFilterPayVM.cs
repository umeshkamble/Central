using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Central.App.ViewModels
{
    public class PageFilterPayVM<P> : PageFilterVM<P> where P : Pay
    {
        public PageFilterPayVM(Query<P> query) : base(query) { }
    }
}
