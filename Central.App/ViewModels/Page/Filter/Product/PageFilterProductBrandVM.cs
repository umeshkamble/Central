using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Central.App.ViewModels
{
    public class PageFilterProductBrandVM : PageFilterVM<ProductBrand>
    {
        public PageFilterProductBrandVM(Query<ProductBrand> query) : base(query) { }
    }
}
