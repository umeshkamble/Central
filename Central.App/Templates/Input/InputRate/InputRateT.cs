using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Central.App.Templates
{
    public class InputRateT : InputT
    {
        public static readonly BindableProperty PnRateVMProperty = BindableProperty.Create(nameof(PnRateVM), typeof(object), typeof(InputRateT), null);
        public object PnRateVM
        {
            get => (object)GetValue(PnRateVMProperty);
            set => SetValue(PnRateVMProperty, value);
        }
    }
}
