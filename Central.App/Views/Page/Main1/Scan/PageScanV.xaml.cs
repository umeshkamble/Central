namespace Central.App.Views;

public partial class PageScanV : PageV
{
	public PageScanV(PageScanVM vm)
	{
		InitializeComponent();
		this.BindingContext = vm;
	}

    protected override async Task OnLoadAsync()
    {
        await base.OnLoadAsync();
        ((PageScanVM)this.BindingContext).LoadAsyncCommand.Execute(null);
    }

}