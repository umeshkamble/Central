namespace Central.App.Views;

public partial class PageOfficialV : PageV
{
	public PageOfficialV(PageOfficialVM vm)
	{
		InitializeComponent();
		this.BindingContext = vm;
	}


    protected override async Task OnLoadAsync()
    {
        await base.OnLoadAsync();
        ((PageOfficialVM)this.BindingContext).LoadAsyncCommand.Execute(null);
    }

}