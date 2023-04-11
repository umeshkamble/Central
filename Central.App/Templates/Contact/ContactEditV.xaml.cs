

namespace Central.App.Templates;

public partial class ContactEditV : ContactT
{
    public View BodyContact
    {
        get => ContentBodyContact;
        set => ContentBodyContact.Content = null;// value;
    }

    public static readonly BindableProperty PnInputNamaVMProperty = BindableProperty.Create(nameof(PnInputNamaVM), typeof(object), typeof(ContactEditV), null);
    public object PnInputNamaVM
    {
        get => (object)GetValue(PnInputNamaVMProperty);
        set => SetValue(PnInputNamaVMProperty, value);
    }

    public static readonly BindableProperty PnInputEmailVMProperty = BindableProperty.Create(nameof(PnInputEmailVM), typeof(object), typeof(ContactEditV), null);
    public object PnInputEmailVM
    {
        get => (object)GetValue(PnInputEmailVMProperty);
        set => SetValue(PnInputEmailVMProperty, value);
    }

    public static readonly BindableProperty PnInputDeskripsiVMProperty = BindableProperty.Create(nameof(PnInputDeskripsiVM), typeof(object), typeof(ContactEditV), null);
    public object PnInputDeskripsiVM
    {
        get => (object)GetValue(PnInputDeskripsiVMProperty);
        set => SetValue(PnInputDeskripsiVMProperty, value);
    }

    public static readonly BindableProperty PnAddressMenuListVMProperty = BindableProperty.Create(nameof(PnAddressMenuListVM), typeof(object), typeof(ContactEditV), null);
    public object PnAddressMenuListVM
    {
        get => (object)GetValue(PnAddressMenuListVMProperty);
        set => SetValue(PnAddressMenuListVMProperty, value);
    }

    public static readonly BindableProperty PnPhoneMenuListVMProperty = BindableProperty.Create(nameof(PnPhoneMenuListVM), typeof(object), typeof(ContactEditV), null);
    public object PnPhoneMenuListVM
    {
        get => (object)GetValue(PnPhoneMenuListVMProperty);
        set => SetValue(PnPhoneMenuListVMProperty, value);
    }


    public static readonly BindableProperty PnPhoneListVMProperty = BindableProperty.Create(nameof(PnPhoneListVM), typeof(object), typeof(ContactEditV), null);
    public object PnPhoneListVM
    {
        get => (object)GetValue(PnPhoneListVMProperty);
        set => SetValue(PnPhoneListVMProperty, value);
    }

    public static readonly BindableProperty PnAddressListVMProperty = BindableProperty.Create(nameof(PnAddressListVM), typeof(object), typeof(ContactEditV), null);
    public object PnAddressListVM
    {
        get => (object)GetValue(PnAddressListVMProperty);
        set => SetValue(PnAddressListVMProperty, value);
    }


    public ContactEditV()
	{
		InitializeComponent();
	}


}