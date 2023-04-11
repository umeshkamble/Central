namespace Central.App.Templates
{
    public class ProductWarehouseT : PanelV
    {
        public static readonly BindableProperty PnNamaProperty = BindableProperty.Create(nameof(PnNama), typeof(string), typeof(ProductWarehouseT), string.Empty);
        public string PnNama
        {
            get => (string)GetValue(PnNamaProperty);
            set => SetValue(PnNamaProperty, value);
        }

        public static readonly BindableProperty PnTotalItemProperty = BindableProperty.Create(nameof(PnTotalItem), typeof(int), typeof(ProductWarehouseT), 0);
        public int PnTotalItem
        {
            get => (int)GetValue(PnTotalItemProperty);
            set => SetValue(PnTotalItemProperty, value);
        }
    }
}



