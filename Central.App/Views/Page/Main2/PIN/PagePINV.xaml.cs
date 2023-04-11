namespace Central.App.Views;

public partial class PagePINV : PageV
{
	public PagePINV(PagePINVM vm)
	{
		InitializeComponent();
		this.BindingContext = vm;
	}
}