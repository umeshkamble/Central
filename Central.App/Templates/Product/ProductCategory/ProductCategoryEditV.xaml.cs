

namespace Central.App.Templates;

public partial class ProductCategoryEditV : ProductCategoryT
{
    public static readonly BindableProperty PnInputNamaVMProperty = BindableProperty.Create(nameof(PnInputNamaVM), typeof(object), typeof(ProductCategoryEditV), null);
    public object PnInputNamaVM
    {
        get => (object)GetValue(PnInputNamaVMProperty);
        set => SetValue(PnInputNamaVMProperty, value);
    }

    public static readonly BindableProperty PnInputDeskripsiVMProperty = BindableProperty.Create(nameof(PnInputDeskripsiVM), typeof(object), typeof(ProductCategoryEditV), null);
    public object PnInputDeskripsiVM
    {
        get => (object)GetValue(PnInputDeskripsiVMProperty);
        set => SetValue(PnInputDeskripsiVMProperty, value);
    }

    public ProductCategoryEditV()
	{
		InitializeComponent();
	}


}