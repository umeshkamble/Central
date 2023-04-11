namespace Central.App.Views;

public partial class PageStartupV : PageV
{
	public PageStartupV(PageStartupVM vm)
	{
		InitializeComponent();
		this.BindingContext = vm;
	}

    protected override async Task OnLoadAsync()
    {
        await base.OnLoadAsync();
        ((PageStartupVM)this.BindingContext).LoadAsyncCommand.Execute(null);
    }


}