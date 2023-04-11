namespace Central.App.Views;

public partial class PageLoginV : PageV
{
	public PageLoginV(PageLoginVM vm)
	{
		InitializeComponent();
		this.BindingContext = vm;
	}
}