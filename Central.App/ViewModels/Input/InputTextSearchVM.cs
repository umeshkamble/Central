
namespace Central.App.ViewModels
{
    public class InputTextSearchVM : InputTextVM
    {
        #region Properties
        #endregion Properties

        #region Command
        public Command SearchCommand { get; set; }
        public Command SearchEnterCommand { get; set; }
        public Command SearchDelayCommand { get; set; }
        #endregion Command

        #region Event
        public delegate void SearchEventHandler(string keyword);
        public event SearchEventHandler Search, SearchEnter, SearchDelay;
        #endregion Event

        public InputTextSearchVM(InputText entity) : base(entity) { }
        protected override void OnInitEvent(InputText entity, PanelEnum panelenum)
        {
            base.OnInitEvent(entity, panelenum);
            this.SearchCommand = new Command(() => this.OnSearch());
            this.SearchDelayCommand = new Command(() => this.OnSearchDelay());
            this.SearchEnterCommand = new Command(() => this.OnSearchEnter());

            this.IsRun = true;
        }

        public void OnClearText()
        {
            this.OnSetText("");
        }

        public void OnSetText(string keyword)
        {
            if (this.Text != keyword) {
                this.IsRun = false;
                this.Text = keyword;
            }
        }

        public void OnSearch(string text)
        {
            this.IsRun = true;
            this.Text = text;
            this.OnSearch();
        }

        public void OnSearch()
        {
            if (!this.IsRun) { this.IsRun = true; return; }
            if (this.Search != null) this.Search(this.Text);
        }

        public void OnSearchEnter()
        {
            if (this.SearchEnter != null) this.SearchEnter(this.Text);
        }
        public void OnSearchDelay()
        {
            if (this.SearchDelay != null) this.SearchDelay(this.Text);
        }
    }
}
