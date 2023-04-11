namespace Central.App.Templates;

public partial class PayBGEditV : PayEditV
{
    public static readonly BindableProperty PnInputBankVMProperty = BindableProperty.Create(nameof(PnInputBankVM), typeof(object), typeof(PayBGEditV), null);
    public object PnInputBankVM
    {
        get => (object)GetValue(PnInputBankVMProperty);
        set => SetValue(PnInputBankVMProperty, value);
    }

    public static readonly BindableProperty PnInputTglBGVMProperty = BindableProperty.Create(nameof(PnInputTglBGVM), typeof(object), typeof(PayBGEditV), null);
    public object PnInputTglBGVM
    {
        get => (object)GetValue(PnInputTglBGVMProperty);
        set => SetValue(PnInputTglBGVMProperty, value);
    }

    public static readonly BindableProperty PnInputTglJTVMProperty = BindableProperty.Create(nameof(PnInputTglJTVM), typeof(object), typeof(PayBGEditV), null);
    public object PnInputTglJTVM
    {
        get => (object)GetValue(PnInputTglJTVMProperty);
        set => SetValue(PnInputTglJTVMProperty, value);
    }

    public static readonly BindableProperty PnInputNoRekeningPenerimaVMProperty = BindableProperty.Create(nameof(PnInputNoRekeningPenerimaVM), typeof(object), typeof(PayBGEditV), null);
    public object PnInputNoRekeningPenerimaVM
    {
        get => (object)GetValue(PnInputNoRekeningPenerimaVMProperty);
        set => SetValue(PnInputNoRekeningPenerimaVMProperty, value);
    }

    public static readonly BindableProperty PnInputNamaPenerimaVMProperty = BindableProperty.Create(nameof(PnInputNamaPenerimaVM), typeof(object), typeof(PayBGEditV), null);
    public object PnInputNamaPenerimaVM
    {
        get => (object)GetValue(PnInputNamaPenerimaVMProperty);
        set => SetValue(PnInputNamaPenerimaVMProperty, value);
    }

    public static readonly BindableProperty PnInputBankPenerimaVMProperty = BindableProperty.Create(nameof(PnInputBankPenerimaVM), typeof(object), typeof(PayBGEditV), null);
    public object PnInputBankPenerimaVM
    {
        get => (object)GetValue(PnInputBankPenerimaVMProperty);
        set => SetValue(PnInputBankPenerimaVMProperty, value);
    }


    public PayBGEditV()
	{
		InitializeComponent();
	}
}