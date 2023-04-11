namespace Central.App.Views;

public partial class PageRegisterV : PageV
{
	public PageRegisterV(PageRegisterVM vm)
	{
		InitializeComponent();
		this.BindingContext = vm;
	}

    protected override async Task OnLoadAsync()
    {
        await base.OnLoadAsync();
        ((PageRegisterVM)this.BindingContext).LoadAsyncCommand.Execute(null);
    }

}