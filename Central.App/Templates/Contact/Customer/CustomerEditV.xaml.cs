namespace Central.App.Templates;

public partial class CustomerEditV : ContactEditV
{
    public static readonly BindableProperty PnInputSalesmanVMProperty = BindableProperty.Create(nameof(PnInputSalesmanVM), typeof(object), typeof(CustomerEditV), null);
    public object PnInputSalesmanVM
    {
        get => (object)GetValue(PnInputSalesmanVMProperty);
        set => SetValue(PnInputSalesmanVMProperty, value);
    }

    public static readonly BindableProperty PnInputLamaJTVMProperty = BindableProperty.Create(nameof(PnInputLamaJTVM), typeof(object), typeof(CustomerEditV), null);
    public object PnInputLamaJTVM
    {
        get => (object)GetValue(PnInputLamaJTVMProperty);
        set => SetValue(PnInputLamaJTVMProperty, value);
    }

    public static readonly BindableProperty PnInputPlafondVMProperty = BindableProperty.Create(nameof(PnInputPlafondVM), typeof(object), typeof(CustomerEditV), null);
    public object PnInputPlafondVM
    {
        get => (object)GetValue(PnInputPlafondVMProperty);
        set => SetValue(PnInputPlafondVMProperty, value);
    }

    public static readonly BindableProperty PnInputNoNPWPVMProperty = BindableProperty.Create(nameof(PnInputNoNPWPVM), typeof(object), typeof(CustomerEditV), null);
    public object PnInputNoNPWPVM
    {
        get => (object)GetValue(PnInputNoNPWPVMProperty);
        set => SetValue(PnInputNoNPWPVMProperty, value);
    }

    public CustomerEditV()
	{
		InitializeComponent();
	}
}