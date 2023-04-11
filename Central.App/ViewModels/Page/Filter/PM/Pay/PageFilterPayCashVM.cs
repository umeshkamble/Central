using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Central.App.ViewModels
{
    public class PageFilterPayCashVM : PageFilterPayVM<PayCash>
    {
        public PageFilterPayCashVM(Query<PayCash> query) : base(query) { }
    }
}
