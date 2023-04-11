
using Central.App.Models;

namespace Central.App.ViewModels
{
    public interface IContentListVM<VMList, VM, E>  : IContentVM<E> where VMList : PanelListVM<VM, E>
                                                                    where VM : PanelVM<E>
                                                                    where E : EntityBase
    {
        string Keyword { get; set; }
        string CboId { get; set; }

        InputTextSearchVM InputTextSearchVM { get; set; }
        PanelListVM<VM,E> PanelListVM { get; set; }
        VM ItemSelectedFirst { get; }
        List<TemplateEnum> Templates { get; set; }
        
        string IdSelected { get; }
        string IdSelecteds { get; }
        string CaptionSelecteds { get; }

        int TotalSelected { get; set; }
        int TotalRecord { get; set; }
        bool IsExpandList { get; set; }

        void OnTemplateSelectNext();
        Command RefreshCommand { get; set; }
    }

    public class ContentListVM<VMList, VM, E> : ContentVM<E>, IContentListVM<VMList, VM, E> where VMList : PanelListVM<VM, E>
                                                                                            where VM : PanelVM<E>
                                                                                            where E : EntityBase
    {
        #region Properties
        private string Keyword_;
        public string Keyword
        {
            set {
                Keyword_ = value;
                this.InputTextSearchVM.OnSetText(Keyword_);
            }
            get {
                return this.InputTextSearchVM.Text;
            }
        }

        private string CboId_;
        public string CboId
        {
            set {
                CboId_ = value;
                this.OnCboChanged(CboId_);
            }
            get { return CboId_; }
        }

        private SelectionEnum SelectionEnum_ = SelectionEnum.Single;
        public SelectionEnum SelectionEnum
        {
            set {
                SelectionEnum_ = value;
                this.PanelListVM.SelectionEnum = SelectionEnum_;
            }
            get { return SelectionEnum_; }
        }

        public InputTextSearchVM InputTextSearchVM { get; set; } 
        public PanelListVM<VM, E> PanelListVM { get; set; }
        public List<TemplateEnum> Templates { get; set; }
        
        public VM ItemSelectedFirst
        {
            get { return PanelListVM.ItemSelectedFirst; }
        }

        public string IdSelected
        {
            get { return PanelListVM.IdSelected; }
        }

        public string IdSelecteds
        {
            get { return PanelListVM.IdSelecteds.ToLower(); }
        }

        public string CaptionSelecteds
        {
            get { return PanelListVM.CaptionSelecteds; }
        }

        private int TotalSelected_;
        public int TotalSelected
        {
            set { this.OnSetProperty(ref TotalSelected_, value); }
            get { return TotalSelected_; }
        }

        private int TotalRecord_;
        public int TotalRecord
        {
            set { this.OnSetProperty(ref TotalRecord_, value); }
            get { return TotalRecord_; }
        }

        private bool IsExpandList_;
        public bool IsExpandList
        {
            set {
                IsExpandList_ = value;
                //var menu = IsExpandList_ ? new Menu(MenuEnum.ExpandLeft, IconFont.ArrowLeft) : new Menu(MenuEnum.ExpandRight, IconFont.ArrowRight);
                //var vm = this.MenuList0VM.Items.AsEnumerable().Where(x => x.MenuEnum == MenuEnum.ExpandRight || x.MenuEnum == MenuEnum.ExpandLeft).FirstOrDefault();
                //vm.MenuEnum = menu.MenuEnum;
                //vm.Icon = menu.Icon;

                if (this.ExpandListChanged != null) this.ExpandListChanged(IsExpandList_);
            }
            get { return IsExpandList_; }
        }
        #endregion Properties

        #region Command
        public Command RefreshCommand { get; set; }
        public Command LoadByIdCommand { get; set; }
        public Command LoadByKeywordCommand { get; set; }
        #endregion Command

        #region Event
        public delegate void EventHandler(VM item);
        public event EventHandler SelectedChanged, ActionChanged;

        public delegate void ViewDetailEventHandler(bool isviewdetail);
        public event ViewDetailEventHandler ExpandListChanged;
        #endregion Event    

        public ContentListVM(List<TemplateEnum> ts) : base(false)
        {
            this.Templates = ts;
            this.OnCboReset();

            this.PanelListVM = this.OnGetPanelList(ts);
            this.PanelListVM.LoadFinished += (() => {
                if (!this.IsDevicePhone) this.PanelListVM.OnSelectFirst();
                this.TotalRecord = this.PanelListVM.ItemCount;
            });
            this.PanelListVM.ActionChanged += ((item) => this.OnActionChanged(item));
            this.PanelListVM.SelectedChanged += ((item) => this.OnSelectedChanged(item));
            this.PanelListVM.UnSelectedChanged += ((item) => this.OnUnSelectedChanged(item));

            this.InputTextSearchVM = new InputTextSearchVM(new InputText("", "", "Search", "", TextEnum.Text));
            this.InputTextSearchVM.Search += ((keyword) => this.OnLoadByIdKeyword(keyword, true));

            this.RefreshCommand = new Command(() => this.PanelListVM.RefreshCommand.Execute(null));
            this.LoadByIdCommand = new Microsoft.Maui.Controls.Command<string>((string id) => this.OnLoadByIdKeyword(id, false));
            this.LoadByKeywordCommand = new Microsoft.Maui.Controls.Command<string>((string keyword) => this.OnLoadByIdKeyword(keyword, true));

            //this.OnSetBtnTemplate();
        }

        protected override Task<List<Task>> OnLoadFirstAsync(List<Task> tasks)
        {
            tasks.Add(this.PanelListVM.OnLoadAsync()); 
            return base.OnLoadFirstAsync(tasks);
        }

        protected override Task OnLoadFinishedAsync()
        {
            this.OnSetBtnTemplate();
            return base.OnLoadFinishedAsync();
        }

        private void OnLoadByIdKeyword(string text, bool iskeyword)
        {
            this.OnCboReset();

            if (iskeyword) this.PanelListVM.LoadByKeywordCommand.Execute(text);
            else this.PanelListVM.LoadByIdCommand.Execute(text);
        }

        protected virtual VMList OnGetPanelList(List<TemplateEnum> ts)
        {
            return null;
        }

        protected override void OnTitleSelect()
        {
            this.OnMenuSelect(MenuEnum.CboFilter);
        }

        protected override List<Menu> OnGetMenus0(List<Menu> menus)
        {
            menus.Add(new Menu(MenuEnum.Filter, IconFont.Filter));
            menus.Add(new Menu(MenuEnum.TemplateGrid, IconFont.Table));
            return base.OnGetMenus0(menus);
        }

        public void OnTemplateSelectNext()
        {
            this.PanelListVM.OnTemplateSelectNext();
            this.OnSetBtnTemplate();
        }

        private void OnSetBtnTemplate()
        {
            var tnext = this.PanelListVM.OnGetTemplateNext();
            
            Menu menu;
            switch (tnext){
                case TemplateEnum.List: menu = new Menu(MenuEnum.TemplateList,IconFont.List);break;
                case TemplateEnum.Grid: menu = new Menu(MenuEnum.TemplateGrid, IconFont.Table);break;
                default: menu = new Menu(MenuEnum.TemplateTable, IconFont.Table);break;
            }

            var vm = this.MenuList0VM.Items.AsEnumerable().Where(x => x.MenuEnum == MenuEnum.TemplateList || x.MenuEnum == MenuEnum.TemplateGrid || x.MenuEnum == MenuEnum.TemplateTable).FirstOrDefault();
            vm.MenuEnum = menu.MenuEnum;
            vm.Icon = menu.Icon;
        }

        private void OnCboReset()
        {
            this.CboId = "Semua";
        }
        protected virtual void OnCboChanged(string id) { }
        protected virtual void OnCboFilterSelect() { }
       
        protected virtual void OnSelectedChanged(VM item)
        {
            this.TotalSelected = this.PanelListVM.ItemSelectedCount;
            if (this.SelectedChanged != null) this.SelectedChanged(item);
        }

        protected virtual void OnUnSelectedChanged(VM item)
        {
            this.TotalSelected = this.PanelListVM.ItemSelectedCount;
        }

        protected virtual void OnActionChanged(VM item)
        {
            if (this.ActionChanged != null) this.ActionChanged(item);
        }

        protected virtual async void OnFilterSelect(Query<E> querycurr, PageFilterV page, PageFilterVM<E> vm)
        {
            page.BindingContext = vm;
            await Shell.Current.Navigation.PushAsync(page);
        }

        public override void OnMenuSelect(MenuEnum menu)
        {
            switch (menu) { 
                 case MenuEnum.TemplateList: {
                        this.OnTemplateSelectNext();
                        break;
                    }
                case MenuEnum.TemplateGrid:{
                        this.OnTemplateSelectNext();
                        break;
                    }
                case MenuEnum.TemplateTable:{
                        this.OnTemplateSelectNext();
                        break;
                    }
                case MenuEnum.Filter: {
                        var querycurr = this.PanelListVM.OnGetQueryCurrent();
                        this.OnFilterSelect(querycurr, null, null);
                        break;
                    }
                case MenuEnum.CboFilter:{
                        this.OnCboFilterSelect();
                        break;
                    }
                case MenuEnum.ExpandRight:{
                        this.IsExpandList = true;
                        break;
                    }
                case MenuEnum.ExpandLeft:{
                        this.IsExpandList = false;
                        break;
                    }
                default: {
                        base.OnMenuSelect(menu);
                        break;
                    } 
            }

        }
    }
}
