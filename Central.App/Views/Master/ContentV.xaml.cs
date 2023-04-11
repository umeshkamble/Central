
namespace Central.App.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ContentV : ContentView
    {
        public View Nav
        {
            get => ContentNav;
            set => ContentNav.Content = value;
        }

        public View Header
        {
            get => ContentHeader;
            set => ContentHeader.Content = value;
        }

        public View Body
        {
            get => ContentBody;
            set => ContentBody.Content = value;
        }

        public View Footer
        {
            get => ContentFooter;
            set => ContentFooter.Content = value;
        }

        public ContentV()
        {
            InitializeComponent();
        }
    }
}