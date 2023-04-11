

namespace Central.App.Templates;

public partial class PhoneEditV : PhoneT
{
    public static readonly BindableProperty PnInputDeskripsiVMProperty = BindableProperty.Create(nameof(PnInputDeskripsiVM), typeof(object), typeof(PhoneEditV), null);
    public object PnInputDeskripsiVM
    {
        get => (object)GetValue(PnInputDeskripsiVMProperty);
        set => SetValue(PnInputDeskripsiVMProperty, value);
    }

    public static readonly BindableProperty PnInputNoTlpVMProperty = BindableProperty.Create(nameof(PnInputNoTlpVM), typeof(object), typeof(PhoneEditV), null);
    public object PnInputNoTlpVM
    {
        get => (object)GetValue(PnInputNoTlpVMProperty);
        set => SetValue(PnInputNoTlpVMProperty, value);
    }

    public PhoneEditV()
	{
		InitializeComponent();
	}


}