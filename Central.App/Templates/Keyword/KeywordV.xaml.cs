namespace Central.App.Templates;

public partial class KeywordV : PanelV
{
    public static readonly BindableProperty PnTextProperty = BindableProperty.Create(nameof(PnText), typeof(string), typeof(KeywordV), string.Empty);
    public string PnText
    {
        get => (string)GetValue(PnTextProperty);
        set => SetValue(PnTextProperty, value);
    }

    public KeywordV()
	{
		InitializeComponent();
	}
}