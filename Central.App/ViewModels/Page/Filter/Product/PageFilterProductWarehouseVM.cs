using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Central.App.ViewModels
{
    public class PageFilterProductWarehouseVM : PageFilterVM<ProductWarehouse>
    {
        public PageFilterProductWarehouseVM(Query<ProductWarehouse> query) : base(query) { }
    }
}
