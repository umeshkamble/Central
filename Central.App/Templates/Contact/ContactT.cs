namespace Central.App.Templates
{
    public class ContactT : PanelV
    {
        public static readonly BindableProperty PnNamaProperty = BindableProperty.Create(nameof(PnNama), typeof(string), typeof(ContactT), string.Empty);
        public string PnNama
        {
            get => (string)GetValue(PnNamaProperty);
            set => SetValue(PnNamaProperty, value);
        }

        public static readonly BindableProperty PnKotaProperty = BindableProperty.Create(nameof(PnKota), typeof(string), typeof(ContactT), string.Empty);
        public string PnKota
        {
            get => (string)GetValue(PnKotaProperty);
            set => SetValue(PnKotaProperty, value);
        }

        public static readonly BindableProperty PnNoTlpProperty = BindableProperty.Create(nameof(PnNoTlp), typeof(string), typeof(ContactT), string.Empty);
        public string PnNoTlp
        {
            get => (string)GetValue(PnNoTlpProperty);
            set => SetValue(PnNoTlpProperty, value);
        }
    }
}
