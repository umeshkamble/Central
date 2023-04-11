

namespace Central.App.Templates;

public partial class PayEditV : PayT
{
    public View BodyPay
    {
        get => ContentBodyPay;
        set => ContentBodyPay.Content = value;
    }

    public static readonly BindableProperty PnInputNoReferensiVMProperty = BindableProperty.Create(nameof(PnInputNoReferensiVM), typeof(object), typeof(PayEditV), null);
    public object PnInputNoReferensiVM
    {
        get => (object)GetValue(PnInputNoReferensiVMProperty);
        set => SetValue(PnInputNoReferensiVMProperty, value);
    }

    public static readonly BindableProperty PnInputTotalVMProperty = BindableProperty.Create(nameof(PnInputTotalVM), typeof(object), typeof(PayEditV), null);
    public object PnInputTotalVM
    {
        get => (object)GetValue(PnInputTotalVMProperty);
        set => SetValue(PnInputTotalVMProperty, value);
    }

    public static readonly BindableProperty PnInputDeskripsiVMProperty = BindableProperty.Create(nameof(PnInputDeskripsiVM), typeof(object), typeof(PayEditV), null);
    public object PnInputDeskripsiVM
    {
        get => (object)GetValue(PnInputDeskripsiVMProperty);
        set => SetValue(PnInputDeskripsiVMProperty, value);
    }

    public PayEditV()
	{
		InitializeComponent();
	}


}