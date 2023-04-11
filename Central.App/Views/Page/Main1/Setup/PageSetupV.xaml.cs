namespace Central.App.Views;

public partial class PageSetupV : PageV
{
	public PageSetupV(PageSetupVM vm)
	{
		InitializeComponent();
        this.BindingContext = vm;
	}

    protected override async Task OnLoadAsync()
    {
        await base.OnLoadAsync();
        ((PageSetupVM)this.BindingContext).LoadAsyncCommand.Execute(null);
    }

    void OnPickerChanged(object sender, EventArgs e)
    {
        Picker picker = sender as Picker;
        Theme theme = (Theme)picker.SelectedItem;

        ICollection<ResourceDictionary> mergedDictionaries = Application.Current.Resources.MergedDictionaries;
        if (mergedDictionaries != null) {
            mergedDictionaries.Clear();

            switch (theme) {
                case Theme.Dark:
                    mergedDictionaries.Add(new ThemeDark());
                    break;
                case Theme.Light:
                default:
                    mergedDictionaries.Add(new ThemeLight());
                    break;
            }
        }
    }
}