

namespace Central.App.Templates;

public partial class PMEditV : PMT
{
    public static readonly BindableProperty PnPayVariantList1VMProperty = BindableProperty.Create(nameof(PnPayVariantList1VM), typeof(object), typeof(PMEditV), null);
    public object PnPayVariantList1VM
    {
        get => (object)GetValue(PnPayVariantList1VMProperty);
        set => SetValue(PnPayVariantList1VMProperty, value);
    }

    public static readonly BindableProperty PnPayVariantList2VMProperty = BindableProperty.Create(nameof(PnPayVariantList2VM), typeof(object), typeof(PMEditV), null);
    public object PnPayVariantList2VM
    {
        get => (object)GetValue(PnPayVariantList2VMProperty);
        set => SetValue(PnPayVariantList2VMProperty, value);
    }


    public PMEditV()
	{
		InitializeComponent();
	}


}