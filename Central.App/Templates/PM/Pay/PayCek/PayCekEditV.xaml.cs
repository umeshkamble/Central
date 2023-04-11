namespace Central.App.Templates;

public partial class PayCekEditV : PayEditV
{
    public static readonly BindableProperty PnInputKasBankVMProperty = BindableProperty.Create(nameof(PnInputKasBankVM), typeof(object), typeof(PayCekEditV), null);
    public object PnInputKasBankVM
    {
        get => (object)GetValue(PnInputKasBankVMProperty);
        set => SetValue(PnInputKasBankVMProperty, value);
    }

    public static readonly BindableProperty PnInputTglCekVMProperty = BindableProperty.Create(nameof(PnInputTglCekVM), typeof(object), typeof(PayCekEditV), null);
    public object PnInputTglCekVM
    {
        get => (object)GetValue(PnInputTglCekVMProperty);
        set => SetValue(PnInputTglCekVMProperty, value);
    }

    public static readonly BindableProperty PnInputNamaPenerimaVMProperty = BindableProperty.Create(nameof(PnInputNamaPenerimaVM), typeof(object), typeof(PayCekEditV), null);
    public object PnInputNamaPenerimaVM
    {
        get => (object)GetValue(PnInputNamaPenerimaVMProperty);
        set => SetValue(PnInputNamaPenerimaVMProperty, value);
    }



    public PayCekEditV()
	{
		InitializeComponent();
	}
}