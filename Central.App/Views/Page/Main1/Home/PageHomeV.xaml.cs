namespace Central.App.Views;

public partial class PageHomeV : PageV
{
	public PageHomeV(PageHomeVM vm)
	{
		InitializeComponent();
		this.BindingContext = vm;
	}

    protected override async Task OnLoadAsync()
    {
        await base.OnLoadAsync();
        ((PageHomeVM)this.BindingContext).LoadAsyncCommand.Execute(null);
    }

}