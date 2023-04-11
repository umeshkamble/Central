namespace Central.App.Templates
{
    public class KasT : PanelV
    {
        public static readonly BindableProperty PnNamaProperty = BindableProperty.Create(nameof(PnNama), typeof(string), typeof(KasT), string.Empty);
        public string PnNama
        {
            get => (string)GetValue(PnNamaProperty);
            set => SetValue(PnNamaProperty, value);
        }

        public static readonly BindableProperty PnTotalRpProperty = BindableProperty.Create(nameof(PnTotalRp), typeof(double), typeof(KasT), 0.0);
        public double PnTotalRp
        {
            get => (double)GetValue(PnTotalRpProperty);
            set => SetValue(PnTotalRpProperty, value);
        }
    }
}

