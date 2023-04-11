namespace Central.App.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ContentListV : ContentV
    {
        public View HeaderList
        {
            get => ContentHeaderList;
            set => ContentHeaderList.Content = value;
        }

        public ContentListV()
        {
            InitializeComponent();
        }
    }
}