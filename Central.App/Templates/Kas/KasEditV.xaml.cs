

namespace Central.App.Templates;

public partial class KasEditV : KasT
{
    public static readonly BindableProperty PnInputNamaVMProperty = BindableProperty.Create(nameof(PnInputNamaVM), typeof(object), typeof(KasEditV), null);
    public object PnInputNamaVM
    {
        get => (object)GetValue(PnInputNamaVMProperty);
        set => SetValue(PnInputNamaVMProperty, value);
    }

    public static readonly BindableProperty PnInputDeskripsiVMProperty = BindableProperty.Create(nameof(PnInputDeskripsiVM), typeof(object), typeof(KasEditV), null);
    public object PnInputDeskripsiVM
    {
        get => (object)GetValue(PnInputDeskripsiVMProperty);
        set => SetValue(PnInputDeskripsiVMProperty, value);
    }

    public KasEditV()
	{
		InitializeComponent();
	}


}