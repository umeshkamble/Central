namespace Central.App.Views;

public partial class PageMasterV : PageV
{
    public View List
    {
        get => ContentList;
        set => ContentList.Content = value;
    }

    public View Info
    {
        get => ContentInfo;
        set => ContentInfo.Content = value;
    }

    public View InfoFooter
    {
        get => ContentInfoFooter;
        set => ContentInfoFooter.Content = value;
    }

    public PageMasterV()
	{
		InitializeComponent();
	}
}