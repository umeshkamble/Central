

namespace Central.App.Templates;

public partial class PayVariantEditV : PayVariantT
{
    public static readonly BindableProperty PnPayCashListVMProperty = BindableProperty.Create(nameof(PnPayCashListVM), typeof(object), typeof(PayVariantEditV), null);
    public object PnPayCashListVM
    {
        get => (object)GetValue(PnPayCashListVMProperty);
        set => SetValue(PnPayCashListVMProperty, value);
    }

    public static readonly BindableProperty PnPayCekListVMProperty = BindableProperty.Create(nameof(PnPayCekListVM), typeof(object), typeof(PayVariantEditV), null);
    public object PnPayCekListVM
    {
        get => (object)GetValue(PnPayCekListVMProperty);
        set => SetValue(PnPayCekListVMProperty, value);
    }

    public static readonly BindableProperty PnPayBGListVMProperty = BindableProperty.Create(nameof(PnPayBGListVM), typeof(object), typeof(PayVariantEditV), null);
    public object PnPayBGListVM
    {
        get => (object)GetValue(PnPayBGListVMProperty);
        set => SetValue(PnPayBGListVMProperty, value);
    }

    public static readonly BindableProperty PnPayTransferListVMProperty = BindableProperty.Create(nameof(PnPayTransferListVM), typeof(object), typeof(PayVariantEditV), null);
    public object PnPayTransferListVM
    {
        get => (object)GetValue(PnPayTransferListVMProperty);
        set => SetValue(PnPayTransferListVMProperty, value);
    }

    public static readonly BindableProperty PnViewCashProperty = BindableProperty.Create(nameof(PnViewCash), typeof(bool), typeof(PayVariantEditV), false);
    public bool PnViewCash
    {
        get => (bool)GetValue(PnViewCashProperty);
        set => SetValue(PnViewCashProperty, value);
    }

    public static readonly BindableProperty PnViewCekProperty = BindableProperty.Create(nameof(PnViewCek), typeof(bool), typeof(PayVariantEditV), false);
    public bool PnViewCek
    {
        get => (bool)GetValue(PnViewCekProperty);
        set => SetValue(PnViewCekProperty, value);
    }

    public static readonly BindableProperty PnViewBGProperty = BindableProperty.Create(nameof(PnViewBG), typeof(bool), typeof(PayVariantEditV), false);
    public bool PnViewBG
    {
        get => (bool)GetValue(PnViewBGProperty);
        set => SetValue(PnViewBGProperty, value);
    }

    public static readonly BindableProperty PnViewTransferProperty = BindableProperty.Create(nameof(PnViewTransfer), typeof(bool), typeof(PayVariantEditV), false);
    public bool PnViewTransfer
    {
        get => (bool)GetValue(PnViewTransferProperty);
        set => SetValue(PnViewTransferProperty, value);
    }

    public PayVariantEditV()
	{
		InitializeComponent();
	}


}