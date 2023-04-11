namespace Central.App.Templates
{
    public class RateT : PanelV
    {
        public static readonly BindableProperty PnRateModeProperty = BindableProperty.Create(nameof(PnRateMode), typeof(RateModeEnum), typeof(RateT), RateModeEnum.Today);
        public RateModeEnum PnRateMode
        {
            get => (RateModeEnum)GetValue(PnRateModeProperty);
            set => SetValue(PnRateModeProperty, value);
        }

        public static readonly BindableProperty PnUnitProperty = BindableProperty.Create(nameof(PnUnit), typeof(string), typeof(RateT), string.Empty);
        public string PnUnit
        {
            get => (string)GetValue(PnUnitProperty);
            set => SetValue(PnUnitProperty, value);
        }

        public static readonly BindableProperty PnUnitQtyProperty = BindableProperty.Create(nameof(PnUnitQty), typeof(double), typeof(RateT), (double)0);
        public double PnUnitQty
        {
            get => (double)GetValue(PnUnitQtyProperty);
            set => SetValue(PnUnitQtyProperty, value);
        }

        public static readonly BindableProperty PnHrgNormalProperty = BindableProperty.Create(nameof(PnHrgNormal), typeof(double), typeof(RateT), (double)0);
        public double PnHrgNormal
        {
            get => (double)GetValue(PnHrgNormalProperty);
            set => SetValue(PnHrgNormalProperty, value);
        }

        public static readonly BindableProperty PnDiskonRpProperty = BindableProperty.Create(nameof(PnDiskonRp), typeof(double), typeof(RateT), (double)0);
        public double PnDiskonRp
        {
            get => (double)GetValue(PnDiskonRpProperty);
            set => SetValue(PnDiskonRpProperty, value);
        }

        public static readonly BindableProperty PnDiskon1Property = BindableProperty.Create(nameof(PnDiskon1), typeof(double), typeof(RateT), (double)0);
        public double PnDiskon1
        {
            get => (double)GetValue(PnDiskon1Property);
            set => SetValue(PnDiskon1Property, value);
        }

        public static readonly BindableProperty PnDiskon2Property = BindableProperty.Create(nameof(PnDiskon2), typeof(double), typeof(RateT), (double)0);
        public double PnDiskon2
        {
            get => (double)GetValue(PnDiskon2Property);
            set => SetValue(PnDiskon2Property, value);
        }

        public static readonly BindableProperty PnDiskon3Property = BindableProperty.Create(nameof(PnDiskon3), typeof(double), typeof(RateT), (double)0);
        public double PnDiskon3
        {
            get => (double)GetValue(PnDiskon3Property);
            set => SetValue(PnDiskon3Property, value);
        }

        public static readonly BindableProperty PnHrgPublishProperty = BindableProperty.Create(nameof(PnHrgPublish), typeof(double), typeof(RateT), (double)0);
        public double PnHrgPublish
        {
            get => (double)GetValue(PnHrgPublishProperty);
            set => SetValue(PnHrgPublishProperty, value);
        }

        public static readonly BindableProperty PnTotalDiskonRpProperty = BindableProperty.Create(nameof(PnTotalDiskonRp), typeof(double), typeof(RateT), (double)0);
        public double PnTotalDiskonRp
        {
            get => (double)GetValue(PnTotalDiskonRpProperty);
            set => SetValue(PnTotalDiskonRpProperty, value);
        }

        public static readonly BindableProperty PnTotalDiskonProperty = BindableProperty.Create(nameof(PnTotalDiskon), typeof(double), typeof(RateT), (double)0);
        public double PnTotalDiskon
        {
            get => (double)GetValue(PnTotalDiskonProperty);
            set => SetValue(PnTotalDiskonProperty, value);
        }

        public static readonly BindableProperty PnDeskripsiProperty = BindableProperty.Create(nameof(PnDeskripsi), typeof(string), typeof(RateT), string.Empty);
        public string PnDeskripsi
        {
            get => (string)GetValue(PnDeskripsiProperty);
            set => SetValue(PnDeskripsiProperty, value);
        }

        public static readonly BindableProperty PnViewDiskonProperty = BindableProperty.Create(nameof(PnViewDiskon), typeof(bool), typeof(RateT), false);
        public bool PnViewDiskon
        {
            get => (bool)GetValue(PnViewDiskonProperty);
            set => SetValue(PnViewDiskonProperty, value);
        }

        public static readonly BindableProperty PnInputHrgNormalVMProperty = BindableProperty.Create(nameof(PnInputHrgNormalVM), typeof(object), typeof(RateT), null);
        public object PnInputHrgNormalVM
        {
            get => (object)GetValue(PnInputHrgNormalVMProperty);
            set => SetValue(PnInputHrgNormalVMProperty, value);
        }

        public static readonly BindableProperty PnInputDiskonRpVMProperty = BindableProperty.Create(nameof(PnInputDiskonRpVM), typeof(object), typeof(RateT), null);
        public object PnInputDiskonRpVM
        {
            get => (object)GetValue(PnInputDiskonRpVMProperty);
            set => SetValue(PnInputDiskonRpVMProperty, value);
        }

        public static readonly BindableProperty PnInputDiskon1VMProperty = BindableProperty.Create(nameof(PnInputDiskon1VM), typeof(object), typeof(RateT), null);
        public object PnInputDiskon1VM
        {
            get => (object)GetValue(PnInputDiskon1VMProperty);
            set => SetValue(PnInputDiskon1VMProperty, value);
        }

        public static readonly BindableProperty PnInputDiskon2VMProperty = BindableProperty.Create(nameof(PnInputDiskon2VM), typeof(object), typeof(RateT), null);
        public object PnInputDiskon2VM
        {
            get => (object)GetValue(PnInputDiskon2VMProperty);
            set => SetValue(PnInputDiskon2VMProperty, value);
        }

        public static readonly BindableProperty PnInputDiskon3VMProperty = BindableProperty.Create(nameof(PnInputDiskon3VM), typeof(object), typeof(RateT), null);
        public object PnInputDiskon3VM
        {
            get => (object)GetValue(PnInputDiskon3VMProperty);
            set => SetValue(PnInputDiskon3VMProperty, value);
        }

        public static readonly BindableProperty PnInputHrgPublishVMProperty = BindableProperty.Create(nameof(PnInputHrgPublishVM), typeof(object), typeof(RateT), null);
        public object PnInputHrgPublishVM
        {
            get => (object)GetValue(PnInputHrgPublishVMProperty);
            set => SetValue(PnInputHrgPublishVMProperty, value);
        }
    }
}



