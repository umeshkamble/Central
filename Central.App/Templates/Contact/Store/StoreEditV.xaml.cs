namespace Central.App.Templates;

public partial class StoreEditV : ContactEditV
{
    public static readonly BindableProperty PnInputNoNPWPVMProperty = BindableProperty.Create(nameof(PnInputNoNPWPVM), typeof(object), typeof(StoreEditV), null);
    public object PnInputNoNPWPVM
    {
        get => (object)GetValue(PnInputNoNPWPVMProperty);
        set => SetValue(PnInputNoNPWPVMProperty, value);
    }

    public StoreEditV()
	{
		InitializeComponent();
	}
}