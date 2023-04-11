namespace Central.App.Views;

public partial class PageMasterEditV : PageV
{
    //public View List
    //{
    //    get => ContentList;
    //    set => ContentList.Content = value;
    //}

    public View Edit
    {
        get => ContentEdit;
        set => ContentEdit.Content = value;
    }

    public View EditFooter
    {
        get => ContentEditFooter;
        set => ContentEditFooter.Content = value;
    }

    public PageMasterEditV()
	{
		InitializeComponent();
	}
}