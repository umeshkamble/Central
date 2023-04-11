namespace Central.App.Templates
{
    public class CityT : PanelV
    {
        public static readonly BindableProperty PnKodeProperty = BindableProperty.Create(nameof(PnKode), typeof(string), typeof(CityT), string.Empty);
        public string PnKode
        {
            get => (string)GetValue(PnKodeProperty);
            set => SetValue(PnKodeProperty, value);
        }
    }
}

