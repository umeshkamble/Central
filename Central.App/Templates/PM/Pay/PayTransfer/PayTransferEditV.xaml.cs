namespace Central.App.Templates;

public partial class PayTransferEditV : PayEditV
{
    public static readonly BindableProperty PnInputTglTransferVMProperty = BindableProperty.Create(nameof(PnInputTglTransferVM), typeof(object), typeof(PayTransferEditV), null);
    public object PnInputTglTransferVM
    {
        get => (object)GetValue(PnInputTglTransferVMProperty);
        set => SetValue(PnInputTglTransferVMProperty, value);
    }

    public static readonly BindableProperty PnInputBankVMProperty = BindableProperty.Create(nameof(PnInputBankVM), typeof(object), typeof(PayTransferEditV), null);
    public object PnInputBankVM
    {
        get => (object)GetValue(PnInputBankVMProperty);
        set => SetValue(PnInputBankVMProperty, value);
    }

    public static readonly BindableProperty PnInputKasVMProperty = BindableProperty.Create(nameof(PnInputKasVM), typeof(object), typeof(PayTransferEditV), null);
    public object PnInputKasVM
    {
        get => (object)GetValue(PnInputKasVMProperty);
        set => SetValue(PnInputKasVMProperty, value);
    }

    public static readonly BindableProperty PnInputQRISVMProperty = BindableProperty.Create(nameof(PnInputQRISVM), typeof(object), typeof(PayTransferEditV), null);
    public object PnInputQRISVM
    {
        get => (object)GetValue(PnInputQRISVMProperty);
        set => SetValue(PnInputQRISVMProperty, value);
    }


    public PayTransferEditV()
	{
		InitializeComponent();
	}
}