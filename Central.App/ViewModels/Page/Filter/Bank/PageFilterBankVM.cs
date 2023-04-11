using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Central.App.ViewModels
{
    public class PageFilterBankVM : PageFilterVM<Bank>
    {
        public PageFilterBankVM(Query<Bank> query) : base(query) { }
    }
}
