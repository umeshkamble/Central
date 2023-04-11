using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Central.App.ViewModels
{
    public class PageFilterProductVM : PageFilterVM<Product>
    {
        public PageFilterProductVM(Query<Product> query) : base(query) { }
    }
}
