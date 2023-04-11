using Central.App.Templates;

namespace Central.App.Views;

public partial class PageV : ContentPage
{
    protected bool IsFirstLoad { get; set; } = true;
    public View Body
    {
        get => ContentBody;
        set => ContentBody.Content = value;
    }

    public PageV()
	{
		InitializeComponent();
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        Debug.WriteLine("XYZ...");
        if (this.IsFirstLoad) {
            Debug.WriteLine("XYZ...OnLoadAsync");
            this.IsFirstLoad = false;
            await Task.Delay(1);
            await this.OnLoadAsync();
        }
    }

    protected virtual async Task OnLoadAsync()
    {
        //------di override semua page-------//
        await Task.FromResult(true);
    }

}