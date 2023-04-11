namespace Central.App.Views;

public partial class PageDashboardV : PageV
{
	public PageDashboardV(PageDashboardVM vm)
	{
		InitializeComponent();
		this.BindingContext = vm;
	}


    protected override async Task OnLoadAsync()
    {
        await base.OnLoadAsync();
        ((PageDashboardVM)this.BindingContext).LoadAsyncCommand.Execute(null);
    }

}