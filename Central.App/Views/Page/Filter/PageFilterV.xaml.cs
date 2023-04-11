namespace Central.App.Views;

public partial class PageFilterV : PageV
{
    public View BodyFilter
    {
        get => BodyFilterContent.Content;
        set => BodyFilterContent.Content = value;
    }

    public PageFilterV()
	{
		InitializeComponent();
	}
}