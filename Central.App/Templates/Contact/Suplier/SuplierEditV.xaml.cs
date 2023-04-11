namespace Central.App.Templates;

public partial class SuplierEditV : ContactEditV
{
    public static readonly BindableProperty PnInputLamaJTVMProperty = BindableProperty.Create(nameof(PnInputLamaJTVM), typeof(object), typeof(SuplierEditV), null);
    public object PnInputLamaJTVM
    {
        get => (object)GetValue(PnInputLamaJTVMProperty);
        set => SetValue(PnInputLamaJTVMProperty, value);
    }

    public SuplierEditV()
	{
		InitializeComponent();
	}
}