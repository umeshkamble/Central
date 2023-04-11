using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Central.App.ViewModels
{
    public class PageFilterPayBGVM : PageFilterPayVM<PayBG>
    {
        public PageFilterPayBGVM(Query<PayBG> query) : base(query) { }
    }
}
