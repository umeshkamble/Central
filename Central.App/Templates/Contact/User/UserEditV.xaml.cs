namespace Central.App.Templates;

public partial class UserEditV : ContactEditV
{
    public static readonly BindableProperty PnInputUsernameVMProperty = BindableProperty.Create(nameof(PnInputUsernameVM), typeof(object), typeof(UserEditV), null);
    public object PnInputUsernameVM
    {
        get => (object)GetValue(PnInputUsernameVMProperty);
        set => SetValue(PnInputUsernameVMProperty, value);
    }

    public static readonly BindableProperty PnInputPasswordVMProperty = BindableProperty.Create(nameof(PnInputPasswordVM), typeof(object), typeof(UserEditV), null);
    public object PnInputPasswordVM
    {
        get => (object)GetValue(PnInputPasswordVMProperty);
        set => SetValue(PnInputPasswordVMProperty, value);
    }

    public static readonly BindableProperty PnInputPasswordNewVMProperty = BindableProperty.Create(nameof(PnInputPasswordNewVM), typeof(object), typeof(UserEditV), null);
    public object PnInputPasswordNewVM
    {
        get => (object)GetValue(PnInputPasswordNewVMProperty);
        set => SetValue(PnInputPasswordNewVMProperty, value);
    }

    public static readonly BindableProperty PnInputPasswordNewRetypeVMProperty = BindableProperty.Create(nameof(PnInputPasswordNewRetypeVM), typeof(object), typeof(UserEditV), null);
    public object PnInputPasswordNewRetypeVM
    {
        get => (object)GetValue(PnInputPasswordNewRetypeVMProperty);
        set => SetValue(PnInputPasswordNewRetypeVMProperty, value);
    }

    public UserEditV()
	{
		InitializeComponent();
	}
}