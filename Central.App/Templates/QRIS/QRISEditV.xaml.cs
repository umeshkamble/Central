

namespace Central.App.Templates;

public partial class QRISEditV : QRIST
{
    public static readonly BindableProperty PnInputNamaVMProperty = BindableProperty.Create(nameof(PnInputNamaVM), typeof(object), typeof(QRISEditV), null);
    public object PnInputNamaVM
    {
        get => (object)GetValue(PnInputNamaVMProperty);
        set => SetValue(PnInputNamaVMProperty, value);
    }

    public static readonly BindableProperty PnInputDeskripsiVMProperty = BindableProperty.Create(nameof(PnInputDeskripsiVM), typeof(object), typeof(QRISEditV), null);
    public object PnInputDeskripsiVM
    {
        get => (object)GetValue(PnInputDeskripsiVMProperty);
        set => SetValue(PnInputDeskripsiVMProperty, value);
    }

    public static readonly BindableProperty PnInputBankVMProperty = BindableProperty.Create(nameof(PnInputBankVM), typeof(object), typeof(QRISEditV), null);
    public object PnInputBankVM
    {
        get => (object)GetValue(PnInputBankVMProperty);
        set => SetValue(PnInputBankVMProperty, value);
    }

    public QRISEditV()
	{
		InitializeComponent();
	}


}