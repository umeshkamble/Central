﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Central.App.ViewModels
{
    public class PageFilterPayCekVM : PageFilterPayVM<PayCek>
    {
        public PageFilterPayCekVM(Query<PayCek> query) : base(query) { }
    }
}
