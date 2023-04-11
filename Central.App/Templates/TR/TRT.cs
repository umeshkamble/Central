namespace Central.App.Templates
{
    public class TRT : PanelV
    {
        public static readonly BindableProperty PnTglProperty = BindableProperty.Create(nameof(PnTgl), typeof(DateTime), typeof(TRT), DateTime.Now);
        public DateTime PnTgl
        {
            get => (DateTime)GetValue(PnTglProperty);
            set => SetValue(PnTglProperty, value);
        }

        public static readonly BindableProperty PnTglJTProperty = BindableProperty.Create(nameof(PnTglJT), typeof(DateTime), typeof(TRT), DateTime.Now);
        public DateTime PnTglJT
        {
            get => (DateTime)GetValue(PnTglJTProperty);
            set => SetValue(PnTglJTProperty, value);
        }

        public static readonly BindableProperty PnNamaClientProperty = BindableProperty.Create(nameof(PnNamaClient), typeof(string), typeof(TRT), string.Empty);
        public string PnNamaClient
        {
            get => (string)GetValue(PnNamaClientProperty);
            set => SetValue(PnNamaClientProperty, value);
        }

        public static readonly BindableProperty PnNamaOperatorProperty = BindableProperty.Create(nameof(PnNamaOperator), typeof(string), typeof(TRT), string.Empty);
        public string PnNamaOperator
        {
            get => (string)GetValue(PnNamaOperatorProperty);
            set => SetValue(PnNamaOperatorProperty, value);
        }

        public static readonly BindableProperty PnNoFakturProperty = BindableProperty.Create(nameof(PnNoFaktur), typeof(string), typeof(TRT), string.Empty);
        public string PnNoFaktur
        {
            get => (string)GetValue(PnNoFakturProperty);
            set => SetValue(PnNoFakturProperty, value);
        }

        public static readonly BindableProperty PnNoReferensiProperty = BindableProperty.Create(nameof(PnNoReferensi), typeof(string), typeof(TRT), string.Empty);
        public string PnNoReferensi
        {
            get => (string)GetValue(PnNoReferensiProperty);
            set => SetValue(PnNoReferensiProperty, value);
        }

        public static readonly BindableProperty PnTotalTransaksiProperty = BindableProperty.Create(nameof(PnTotalTransaksi), typeof(double), typeof(TRT), 0.0);
        public double PnTotalTransaksi
        {
            get => (double)GetValue(PnTotalTransaksiProperty);
            set => SetValue(PnTotalTransaksiProperty, value);
        }

        public static readonly BindableProperty PnTotalSetorProperty = BindableProperty.Create(nameof(PnTotalSetor), typeof(double), typeof(TRT), 0.0);
        public double PnTotalSetor
        {
            get => (double)GetValue(PnTotalSetorProperty);
            set => SetValue(PnTotalSetorProperty, value);
        }

        public static readonly BindableProperty PnTotalBalanceProperty = BindableProperty.Create(nameof(PnTotalBalance), typeof(double), typeof(TRT), 0.0);
        public double PnTotalBalance
        {
            get => (double)GetValue(PnTotalBalanceProperty);
            set => SetValue(PnTotalBalanceProperty, value);
        }

        public static readonly BindableProperty PnInputClientVMProperty = BindableProperty.Create(nameof(PnInputClientVM), typeof(object), typeof(TRT), null);
        public object PnInputClientVM
        {
            get => (object)GetValue(PnInputClientVMProperty);
            set => SetValue(PnInputClientVMProperty, value);
        }

        public static readonly BindableProperty PnBillToVMProperty = BindableProperty.Create(nameof(PnBillToVM), typeof(object), typeof(TRT), null);
        public object PnBillToVM
        {
            get => (object)GetValue(PnBillToVMProperty);
            set => SetValue(PnBillToVMProperty, value);
        }

        public static readonly BindableProperty PnShipToVMProperty = BindableProperty.Create(nameof(PnShipToVM), typeof(object), typeof(TRT), null);
        public object PnShipToVM
        {
            get => (object)GetValue(PnShipToVMProperty);
            set => SetValue(PnShipToVMProperty, value);
        }

        public static readonly BindableProperty PnPhoneVMProperty = BindableProperty.Create(nameof(PnPhoneVM), typeof(object), typeof(TRT), null);
        public object PnPhoneVM
        {
            get => (object)GetValue(PnPhoneVMProperty);
            set => SetValue(PnPhoneVMProperty, value);
        }

        public static readonly BindableProperty PnDetailListVMProperty = BindableProperty.Create(nameof(PnDetailListVM), typeof(object), typeof(TRT), null);
        public object PnDetailListVM
        {
            get => (object)GetValue(PnDetailListVMProperty);
            set => SetValue(PnDetailListVMProperty, value);
        }

        public static readonly BindableProperty PnDetailMenuListVMProperty = BindableProperty.Create(nameof(PnDetailMenuListVM), typeof(object), typeof(TRT), null);
        public object PnDetailMenuListVM
        {
            get => (object)GetValue(PnDetailMenuListVMProperty);
            set => SetValue(PnDetailMenuListVMProperty, value);
        }

        public static readonly BindableProperty PnHSumVMProperty = BindableProperty.Create(nameof(PnHSumVM), typeof(object), typeof(TRT), null);
        public object PnHSumVM
        {
            get => (object)GetValue(PnHSumVMProperty);
            set => SetValue(PnHSumVMProperty, value);
        }

        public static readonly BindableProperty PnIcon2Property = BindableProperty.Create(nameof(PnIcon2), typeof(string), typeof(TRT), string.Empty);
        public string PnIcon2
        {
            get => (string)GetValue(PnIcon2Property);
            set => SetValue(PnIcon2Property, value);
        }

    }
}

