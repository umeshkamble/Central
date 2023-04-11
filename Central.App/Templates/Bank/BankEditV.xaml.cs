

namespace Central.App.Templates;

public partial class BankEditV : BankT
{
    public static readonly BindableProperty PnInputNamaVMProperty = BindableProperty.Create(nameof(PnInputNamaVM), typeof(object), typeof(BankEditV), null);
    public object PnInputNamaVM
    {
        get => (object)GetValue(PnInputNamaVMProperty);
        set => SetValue(PnInputNamaVMProperty, value);
    }

    public static readonly BindableProperty PnInputDeskripsiVMProperty = BindableProperty.Create(nameof(PnInputDeskripsiVM), typeof(object), typeof(BankEditV), null);
    public object PnInputDeskripsiVM
    {
        get => (object)GetValue(PnInputDeskripsiVMProperty);
        set => SetValue(PnInputDeskripsiVMProperty, value);
    }

    public BankEditV()
	{
		InitializeComponent();
	}


}