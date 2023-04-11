using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Central.App.Templates
{
    public class InputSwitchT : InputT
    {
        public static readonly BindableProperty PnOnProperty = BindableProperty.Create(nameof(PnOn), typeof(bool), typeof(InputSwitchT), false);
        public bool PnOn
        {
            get => (bool)GetValue(PnOnProperty);
            set => SetValue(PnOnProperty, value);
        }

        public static readonly BindableProperty PnCheckedChangedCommandProperty = BindableProperty.Create(nameof(PnCheckedChangedCommand), typeof(ICommand), typeof(InputSwitchT), null);
        public ICommand PnCheckedChangedCommand
        {
            get { return (ICommand)GetValue(PnCheckedChangedCommandProperty); }
            set { SetValue(PnCheckedChangedCommandProperty, value); }
        }
    }
}
