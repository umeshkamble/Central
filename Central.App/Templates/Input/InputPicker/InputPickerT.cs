using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Central.App.Templates
{
    public class InputPickerT : InputT
    {
        public static readonly BindableProperty PnTextProperty = BindableProperty.Create(nameof(PnText), typeof(string), typeof(InputPickerT), string.Empty);
        public string PnText
        {
            get => (string)GetValue(PnTextProperty);
            set => SetValue(PnTextProperty, value);
        }

        public static readonly BindableProperty PnIcon2Property = BindableProperty.Create(nameof(PnIcon2), typeof(string), typeof(InputPickerT), string.Empty);
        public string PnIcon2
        {
            get => (string)GetValue(PnIcon2Property);
            set => SetValue(PnIcon2Property, value);
        }

        public static readonly BindableProperty PnPickerChangedCommandProperty = BindableProperty.Create(nameof(PnPickerChangedCommand), typeof(ICommand), typeof(InputPickerT), null);
        public ICommand PnPickerChangedCommand
        {
            get { return (ICommand)GetValue(PnPickerChangedCommandProperty); }
            set { SetValue(PnPickerChangedCommandProperty, value); }
        }
    }
}
