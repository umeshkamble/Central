namespace Central.App.Templates
{
    public class QRIST : PanelV
    {
        public static readonly BindableProperty PnNamaProperty = BindableProperty.Create(nameof(PnNama), typeof(string), typeof(QRIST), string.Empty);
        public string PnNama
        {
            get => (string)GetValue(PnNamaProperty);
            set => SetValue(PnNamaProperty, value);
        }

        public static readonly BindableProperty PnNamaBankProperty = BindableProperty.Create(nameof(PnNamaBank), typeof(string), typeof(QRIST), string.Empty);
        public string PnNamaBank
        {
            get => (string)GetValue(PnNamaBankProperty);
            set => SetValue(PnNamaBankProperty, value);
        }

        public static readonly BindableProperty PnTotalRpProperty = BindableProperty.Create(nameof(PnTotalRp), typeof(double), typeof(QRIST), 0.0);
        public double PnTotalRp
        {
            get => (double)GetValue(PnTotalRpProperty);
            set => SetValue(PnTotalRpProperty, value);
        }
    }
}

