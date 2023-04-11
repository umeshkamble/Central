namespace Central.App.Templates
{
    public class ProductBrandT : PanelV
    {
        public static readonly BindableProperty PnNamaProperty = BindableProperty.Create(nameof(PnNama), typeof(string), typeof(ProductBrandT), string.Empty);
        public string PnNama
        {
            get => (string)GetValue(PnNamaProperty);
            set => SetValue(PnNamaProperty, value);
        }

        public static readonly BindableProperty PnTotalItemProperty = BindableProperty.Create(nameof(PnTotalItem), typeof(int), typeof(ProductBrandT), 0);
        public int PnTotalItem
        {
            get => (int)GetValue(PnTotalItemProperty);
            set => SetValue(PnTotalItemProperty, value);
        }
    }
}



