namespace Central.App.Views;

public partial class PageTrollyV : PageV
{
	public PageTrollyV(PageTrollyVM vm)
	{
		InitializeComponent();
		this.BindingContext = vm;
	}

    protected override async Task OnLoadAsync()
    {
        await base.OnLoadAsync();
        ((PageTrollyVM)this.BindingContext).LoadAsyncCommand.Execute(null);
    }

}