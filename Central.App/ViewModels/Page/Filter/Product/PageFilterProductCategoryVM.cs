using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Central.App.ViewModels
{
    public class PageFilterProductCategoryVM : PageFilterVM<ProductCategory>
    {
        public PageFilterProductCategoryVM(Query<ProductCategory> query) : base(query) { }
    }
}
