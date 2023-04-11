namespace Central.App.Templates
{
    public class PayVariantT : PanelV
    {
        public static readonly BindableProperty PnNamaProperty = BindableProperty.Create(nameof(PnNama), typeof(string), typeof(PayVariantT), string.Empty);
        public string PnNama
        {
            get => (string)GetValue(PnNamaProperty);
            set => SetValue(PnNamaProperty, value);
        }

        public static readonly BindableProperty PnTotalProperty = BindableProperty.Create(nameof(PnTotal), typeof(double), typeof(PayVariantT), 0.0);
        public double PnTotal
        {
            get => (double)GetValue(PnTotalProperty);
            set => SetValue(PnTotalProperty, value);
        }

        public static readonly BindableProperty PnTotalItemProperty = BindableProperty.Create(nameof(PnTotalItem), typeof(int), typeof(PayVariantT), 0);
        public int PnTotalItem
        {
            get => (int)GetValue(PnTotalItemProperty);
            set => SetValue(PnTotalItemProperty, value);
        }

        public static readonly BindableProperty PnIcon2Property = BindableProperty.Create(nameof(PnIcon2), typeof(string), typeof(PayVariantT), string.Empty);
        public string PnIcon2
        {
            get => (string)GetValue(PnIcon2Property);
            set => SetValue(PnIcon2Property, value);
        }
    }
}

