namespace Central.App.Templates
{
    public class AddressT : PanelV
    {
        public static readonly BindableProperty PnAlamatProperty = BindableProperty.Create(nameof(PnAlamat), typeof(string), typeof(AddressT), string.Empty);
        public string PnAlamat
        {
            get => (string)GetValue(PnAlamatProperty);
            set => SetValue(PnAlamatProperty, value);
        }
        
        public static readonly BindableProperty PnKotaProperty = BindableProperty.Create(nameof(PnKota), typeof(string), typeof(AddressT), string.Empty);
        public string PnKota
        {
            get => (string)GetValue(PnKotaProperty);
            set => SetValue(PnKotaProperty, value);
        }
    }
}


