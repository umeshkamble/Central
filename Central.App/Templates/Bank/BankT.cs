namespace Central.App.Templates
{
    public class BankT : PanelV
    {
        public static readonly BindableProperty PnNamaProperty = BindableProperty.Create(nameof(PnNama), typeof(string), typeof(BankT), string.Empty);
        public string PnNama
        {
            get => (string)GetValue(PnNamaProperty);
            set => SetValue(PnNamaProperty, value);
        }

        public static readonly BindableProperty PnTotalRpProperty = BindableProperty.Create(nameof(PnTotalRp), typeof(double), typeof(BankT), 0.0);
        public double PnTotalRp
        {
            get => (double)GetValue(PnTotalRpProperty);
            set => SetValue(PnTotalRpProperty, value);
        }
    }
}

