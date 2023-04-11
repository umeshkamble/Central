

namespace Central.App.Templates;

public partial class AddressEditV : AddressT
{
    public static readonly BindableProperty PnInputAlamatVMProperty = BindableProperty.Create(nameof(PnInputAlamatVM), typeof(object), typeof(AddressEditV), null);
    public object PnInputAlamatVM
    {
        get => (object)GetValue(PnInputAlamatVMProperty);
        set => SetValue(PnInputAlamatVMProperty, value);
    }

    public static readonly BindableProperty PnInputKelurahanVMProperty = BindableProperty.Create(nameof(PnInputKelurahanVM), typeof(object), typeof(AddressEditV), null);
    public object PnInputKelurahanVM
    {
        get => (object)GetValue(PnInputKelurahanVMProperty);
        set => SetValue(PnInputKelurahanVMProperty, value);
    }

    public static readonly BindableProperty PnInputKecamatanVMProperty = BindableProperty.Create(nameof(PnInputKecamatanVM), typeof(object), typeof(AddressEditV), null);
    public object PnInputKecamatanVM
    {
        get => (object)GetValue(PnInputKecamatanVMProperty);
        set => SetValue(PnInputKecamatanVMProperty, value);
    }

    public static readonly BindableProperty PnInputKotaVMProperty = BindableProperty.Create(nameof(PnInputKotaVM), typeof(object), typeof(AddressEditV), null);
    public object PnInputKotaVM
    {
        get => (object)GetValue(PnInputKotaVMProperty);
        set => SetValue(PnInputKotaVMProperty, value);
    }

    public static readonly BindableProperty PnInputProvinsiVMProperty = BindableProperty.Create(nameof(PnInputProvinsiVM), typeof(object), typeof(AddressEditV), null);
    public object PnInputProvinsiVM
    {
        get => (object)GetValue(PnInputProvinsiVMProperty);
        set => SetValue(PnInputProvinsiVMProperty, value);
    }

    public static readonly BindableProperty PnInputKodePosVMProperty = BindableProperty.Create(nameof(PnInputKodePosVM), typeof(object), typeof(AddressEditV), null);
    public object PnInputKodePosVM
    {
        get => (object)GetValue(PnInputKodePosVMProperty);
        set => SetValue(PnInputKodePosVMProperty, value);
    }

    public AddressEditV()
	{
		InitializeComponent();
	}


}