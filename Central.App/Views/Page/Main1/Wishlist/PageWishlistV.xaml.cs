namespace Central.App.Views;

public partial class PageWishlistV : PageV
{
	public PageWishlistV(PageWishlistVM vm)
	{
		InitializeComponent();
		this.BindingContext = vm;
	}

    protected override async Task OnLoadAsync()
    {
        await base.OnLoadAsync();
        ((PageWishlistVM)this.BindingContext).LoadAsyncCommand.Execute(null);
    }
}