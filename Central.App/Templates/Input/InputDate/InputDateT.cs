using System.Windows.Input;
namespace Central.App.Templates
{
    public class InputDateT : InputT
    {
        public static readonly BindableProperty PnValueProperty = BindableProperty.Create(nameof(PnValue), typeof(DateTime), typeof(InputDateT), DateTime.Now);
        public DateTime PnValue
        {
            get => (DateTime)GetValue(PnValueProperty);
            set => SetValue(PnValueProperty, value);
        }

        public static readonly BindableProperty PnValueMinProperty = BindableProperty.Create(nameof(PnValueMin), typeof(DateTime), typeof(InputDateT), DateTime.Now);
        public DateTime PnValueMin
        {
            get => (DateTime)GetValue(PnValueMinProperty);
            set => SetValue(PnValueMinProperty, value);
        }

        public static readonly BindableProperty PnValueMaxProperty = BindableProperty.Create(nameof(PnValueMax), typeof(DateTime), typeof(InputDateT), DateTime.Now);
        public DateTime PnValueMax
        {
            get => (DateTime)GetValue(PnValueMaxProperty);
            set => SetValue(PnValueMaxProperty, value);
        }

        public static readonly BindableProperty PnValueChangedCommandProperty = BindableProperty.Create(nameof(PnValueChangedCommand), typeof(ICommand), typeof(InputDateT), null);
        public ICommand PnValueChangedCommand
        {
            get { return (ICommand)GetValue(PnValueChangedCommandProperty); }
            set { SetValue(PnValueChangedCommandProperty, value); }
        }
    }
}
