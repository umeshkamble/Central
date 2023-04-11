namespace Central.App.Templates
{
    public class PhoneT : PanelV
    {
        public static readonly BindableProperty PnDeskripsiProperty = BindableProperty.Create(nameof(PnDeskripsi), typeof(string), typeof(PhoneT), string.Empty);
        public string PnDeskripsi
        {
            get => (string)GetValue(PnDeskripsiProperty);
            set => SetValue(PnDeskripsiProperty, value);
        }
        
        public static readonly BindableProperty PnNoTlpProperty = BindableProperty.Create(nameof(PnNoTlp), typeof(string), typeof(PhoneT), string.Empty);
        public string PnNoTlp
        {
            get => (string)GetValue(PnNoTlpProperty);
            set => SetValue(PnNoTlpProperty, value);
        }
    }
}


