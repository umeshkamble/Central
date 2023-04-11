namespace Central.App.Views;

public partial class PageProgressV : PageV
{
	public PageProgressV(PageProgressVM vm)
	{
		InitializeComponent();
		this.BindingContext = vm;
	}

}