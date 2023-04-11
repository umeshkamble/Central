
namespace Central.App.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PageStoreV : PageContactV
    {
        public PageStoreV(PageStoreVM vm)
        {
            InitializeComponent();
            this.BindingContext = vm;
        }

        protected override async Task OnLoadAsync()
        {
            await base.OnLoadAsync();
            //((PageStoreVM)this.BindingContext).LoadAsyncCommand.Execute(null);
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync(nameof(PageStoreEditV),true);
        }
    }
}