namespace Central.App.Templates
{
    public class ProductT : PanelV
    {
        public static readonly BindableProperty PnNamaProperty = BindableProperty.Create(nameof(PnNama), typeof(string), typeof(ProductT), string.Empty);
        public string PnNama
        {
            get => (string)GetValue(PnNamaProperty);
            set => SetValue(PnNamaProperty, value);
        }

        public static readonly BindableProperty PnNoItemProperty = BindableProperty.Create(nameof(PnNoItem), typeof(string), typeof(ProductT), string.Empty);
        public string PnNoItem
        {
            get => (string)GetValue(PnNoItemProperty);
            set => SetValue(PnNoItemProperty, value);
        }

        public static readonly BindableProperty PnRateVMProperty = BindableProperty.Create(nameof(PnRateVM), typeof(object), typeof(ProductT), null);
        public object PnRateVM
        {
            get => (object)GetValue(PnRateVMProperty);
            set => SetValue(PnRateVMProperty, value);
        }

        public static readonly BindableProperty PnInputNamaVMProperty = BindableProperty.Create(nameof(PnInputNamaVM), typeof(object), typeof(ProductT), null);
        public object PnInputNamaVM
        {
            get => (object)GetValue(PnInputNamaVMProperty);
            set => SetValue(PnInputNamaVMProperty, value);
        }

        public static readonly BindableProperty PnInputNoItemVMProperty = BindableProperty.Create(nameof(PnInputNoItemVM), typeof(object), typeof(ProductT), null);
        public object PnInputNoItemVM
        {
            get => (object)GetValue(PnInputNoItemVMProperty);
            set => SetValue(PnInputNoItemVMProperty, value);
        }

        public static readonly BindableProperty PnInputDeskripsiVMProperty = BindableProperty.Create(nameof(PnInputDeskripsiVM), typeof(object), typeof(ProductT), null);
        public object PnInputDeskripsiVM
        {
            get => (object)GetValue(PnInputDeskripsiVMProperty);
            set => SetValue(PnInputDeskripsiVMProperty, value);
        }

        public static readonly BindableProperty PnInputSwitchPPNVMProperty = BindableProperty.Create(nameof(PnInputSwitchPPNVM), typeof(object), typeof(ProductT), null);
        public object PnInputSwitchPPNVM
        {
            get => (object)GetValue(PnInputSwitchPPNVMProperty);
            set => SetValue(PnInputSwitchPPNVMProperty, value);
        }

        public static readonly BindableProperty PnInputKategoriVMProperty = BindableProperty.Create(nameof(PnInputKategoriVM), typeof(object), typeof(ProductT), null);
        public object PnInputKategoriVM
        {
            get => (object)GetValue(PnInputKategoriVMProperty);
            set => SetValue(PnInputKategoriVMProperty, value);
        }

        public static readonly BindableProperty PnInputBrandVMProperty = BindableProperty.Create(nameof(PnInputBrandVM), typeof(object), typeof(ProductT), null);
        public object PnInputBrandVM
        {
            get => (object)GetValue(PnInputBrandVMProperty);
            set => SetValue(PnInputBrandVMProperty, value);
        }

        public static readonly BindableProperty PnInputSuplierVMProperty = BindableProperty.Create(nameof(PnInputSuplierVM), typeof(object), typeof(ProductT), null);
        public object PnInputSuplierVM
        {
            get => (object)GetValue(PnInputSuplierVMProperty);
            set => SetValue(PnInputSuplierVMProperty, value);
        }

        public static readonly BindableProperty PnVariantMenuListVMProperty = BindableProperty.Create(nameof(PnVariantMenuListVM), typeof(object), typeof(ProductT), null);
        public object PnVariantMenuListVM
        {
            get => (object)GetValue(PnVariantMenuListVMProperty);
            set => SetValue(PnVariantMenuListVMProperty, value);
        }


        public static readonly BindableProperty PnVariantListVMProperty = BindableProperty.Create(nameof(PnVariantListVM), typeof(object), typeof(ProductT), null);
        public object PnVariantListVM
        {
            get => (object)GetValue(PnVariantListVMProperty);
            set => SetValue(PnVariantListVMProperty, value);
        }

        public static readonly BindableProperty PnProductVariantListVMProperty = BindableProperty.Create(nameof(PnProductVariantListVM), typeof(object), typeof(ProductT), null);
        public object PnProductVariantListVM
        {
            get => (object)GetValue(PnProductVariantListVMProperty);
            set => SetValue(PnProductVariantListVMProperty, value);
        }



    }
}





