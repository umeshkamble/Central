using Central.Library;

namespace Central.App.ViewModels
{
    public class PageMasterParam1
    {
        public string Title1 { get; set; } = "";
        public string Title2 { get; set; } = "";
        public bool IsPicker { get; set; } = false;
        public SelectionEnum SelectionEnum { get; set; } = SelectionEnum.Single;
        public object Query { get; set; } = null;

        public PageMasterParam1() { }
        public PageMasterParam1(string title1, string title2, bool ispicker, SelectionEnum selectionenum) : this(title1, title2, ispicker, selectionenum, null) { }
        public PageMasterParam1(string title1, string title2, bool ispicker, SelectionEnum selectionenum, object query)
        {
            this.Title1 = title1;
            this.Title2 = title2;
            this.IsPicker = ispicker;
            this.SelectionEnum = selectionenum;
            this.Query = query;
        }
    }

    public class PageMasterParam2
    {
        public string Id { get; set; } = "";
        public PageMasterParam2(string id)
        {
            this.Id = id;
        }
    }


    public interface IPageMasterVM<CListVM, VMList, VM, E>  where CListVM : ContentListVM<VMList, VM, E>
                                                            where VMList : PanelListVM<VM, E>
                                                            where VM : PanelVM<E>
                                                            where E : EntityBase
    {
        CListVM ContentListVM { get; set; }
        VM InfoVM { get; set; }

        GridLength ContentListWidth { get; set; }
        GridLength ContentInfoWidth { get; set; }

        string Keyword { get; set; }
        PanelListVM<VM, E> PanelListVM { get; }

        string IdSelected { get; }
        string IdSelecteds { get; }
        string CaptionSelecteds { get; }

        bool IsPicker { get; set; }
        bool IsExpandList { get; set; }
    }



    [QueryProperty(nameof(PageMasterParam1), nameof(PageMasterParam1))]
    [QueryProperty(nameof(PageMasterParam2), nameof(PageMasterParam2))]
    public class PageMasterVM<CListVM, VMList, VM, E> : PageVM<E>, IPageMasterVM<CListVM, VMList, VM, E>
                                                                         where CListVM : ContentListVM<VMList, VM, E>
                                                                         where VMList : PanelListVM<VM, E>
                                                                         where VM : PanelVM<E>
                                                                         where E : EntityBase
    {
        #region Properties
        private PageMasterParam1 PageMasterParam1_;
        public PageMasterParam1 PageMasterParam1
        { 
            set {
                if (value is null) return;

                PageMasterParam1_ = value;
                var title1 = PageMasterParam1_.Title1;
                var title2 = PageMasterParam1_.Title2;
                var ispicker = PageMasterParam1_.IsPicker;
                var selectionenum = PageMasterParam1_.SelectionEnum;

                if (!ispicker) {
                    if (this.IsDevicePhone) selectionenum = SelectionEnum.None;
                }

                this.Title1 = title1;
                this.Title2 = title2;
                this.SelectionEnum = selectionenum;
                this.IsPicker = ispicker;

                this.LoadAsyncCommand.Execute(null);
            }
            get { return PageMasterParam1_; }
        }

        private PageMasterParam2 PageMasterParam2_;
        public PageMasterParam2 PageMasterParam2
        {
            set {
                if (value is null) return;

                PageMasterParam2_ = value;
                if (this.IsDevicePhone) this.IsExpandList = true;
                this.ContentListVM.LoadByIdCommand.Execute(PageMasterParam2_.Id);
            }
            get { return PageMasterParam2_; }
        }

        public CListVM ContentListVM { get; set; }
        public VM InfoVM { get; set; }

        private GridLength ContentListWidth_;
        public GridLength ContentListWidth
        {
            set { this.OnSetProperty(ref ContentListWidth_, value); }
            get { return ContentListWidth_; }
        }

        private GridLength ContentInfoWidth_;
        public GridLength ContentInfoWidth
        {
            set { this.OnSetProperty(ref ContentInfoWidth_, value); }
            get { return ContentInfoWidth_; }
        }

        public string PageEditName { get; set; }

        private string Keyword_;
        public string Keyword
        {
            set {
                Keyword_ = value;
                this.ContentListVM.Keyword = Keyword_;
            }
            get {
                return this.ContentListVM.Keyword;
            }
        }

        public PanelListVM<VM, E> PanelListVM
        {
            get { return this.ContentListVM.PanelListVM; }
        }

        public string IdSelected
        {
            get { return this.ContentListVM.IdSelected; }
        }

        public string IdSelecteds
        {
            get { return this.ContentListVM.IdSelecteds; }
        }

        public string CaptionSelecteds
        {
            get { return this.ContentListVM.CaptionSelecteds; }
        }

        private SelectionEnum SelectionEnum_ = SelectionEnum.Single;
        public SelectionEnum SelectionEnum
        {
            set {
                SelectionEnum_ = value;
                this.ContentListVM.SelectionEnum = SelectionEnum_;
            }
            get { return SelectionEnum_; }
        }

        private bool IsPicker_ = false;
        public bool IsPicker
        {
            set {
                IsPicker_ = value;
                this.ContentListVM.IsPicker = IsPicker_;
            }
            get { return IsPicker_; }
        }

        private bool IsViewList_ = true;
        public virtual bool IsViewList
        {
            set { this.OnSetProperty(ref IsViewList_, value); }
            get { return IsViewList_; }
        }

        private bool IsViewInfo_ = true;
        public virtual bool IsViewInfo
        {
            set { this.OnSetProperty(ref IsViewInfo_, value); }
            get { return IsViewInfo_; }
        }

        private bool IsExpandList_;
        public bool IsExpandList
        {
            set {
                IsExpandList_ = value;

                var isviewlist = true;
                var isviewinfo = true;
                GridLength width1, width2;
                if (DeviceInfo.Current.Idiom == DeviceIdiom.Phone) {
                    width1 = IsExpandList_ ? new GridLength(0.999, GridUnitType.Star) : new GridLength(0.001, GridUnitType.Star);
                    width2 = IsExpandList_ ? new GridLength(0.001, GridUnitType.Star) : new GridLength(0.999, GridUnitType.Star);

                    isviewlist = IsExpandList_;
                    isviewinfo = !IsExpandList_;
                }
                else {
                    width1 = IsExpandList_ ? new GridLength(0.75, GridUnitType.Star) : new GridLength(0.25, GridUnitType.Star);
                    width2 = IsExpandList_ ? new GridLength(0.25, GridUnitType.Star) : new GridLength(0.75, GridUnitType.Star);
                }

                this.ContentListWidth = width1;
                this.ContentInfoWidth = width2;

                this.IsViewList = isviewlist;
                this.IsViewInfo = isviewinfo;
            }
            get => IsExpandList_;
        }
        #endregion Properties

        #region Event
        public delegate void PickerEventHandler(string idselecteds, string captionselecteds);
        public event PickerEventHandler PickerSelectedChanged;
        #endregion Event    

        #region Command
        public Command AddCommand { get; set; }
        public Command EditCommand { get; set; }
        public Command DeleteCommand { get; set; }
        #endregion Command  


        public PageMasterVM(string title1, string title2, string pageeditname) : base(title1,title2)
        {
            //------------------ContentList----------------------------//
            this.PageEditName = pageeditname;
            this.ContentListVM = this.OnGetContentListVM();
            this.ContentListVM.MenuSelectedChanged += this.OnMenuSelect;
            this.ContentListVM.SelectedChanged += ((item) => {
                //----jika Device.Phone/Tablet, maka lgs munculkan ContentInfo----//
                if (!this.IsPicker) {
                    if (this.IsDevicePhone) this.IsExpandList = false;
                }
                
                this.InfoVM.LoadByIdCommand.Execute(item.Id);
            });
            this.ContentListVM.ActionChanged += ((item) => {
                if (this.IsDeviceDesktop) {
                    //---------hanya berlaku utk desktop-------------//
                    var menuenum = this.IsPicker ? MenuEnum.Select : MenuEnum.Edit;
                    this.OnMenuSelect(menuenum);
                }
            });

            //------------------ContentInfo----------------------------//
            this.InfoVM = this.OnGetInfoVM();
            this.InfoVM.MenuSelectedChanged += this.OnMenuSelect;

            //------------------AddCommand & EditCommand----------------------------//
            this.AddCommand = new Command(() => {
                this.EditCommand.Execute("");
            });
            this.EditCommand = new Microsoft.Maui.Controls.Command<string>((string id) => {
                var tasks = new List<Task> { this.OnEditAsync(id) };
                this.LoadAsyncCommand.Execute(tasks);
            });
            this.DeleteCommand = new Microsoft.Maui.Controls.Command<string>((string id) => {
                var tasks = new List<Task> { this.OnDeleteAsync(id) };
                this.LoadAsyncCommand.Execute(tasks);
            });

            this.ContentListVM.IsExpandList = true;
            this.IsExpandList = true;
            //this.ContentListVM.IsExpandList = ispicker ? false : true;
        }

        protected override Task<List<Task>> OnLoadFirstAsync(List<Task> tasks)
        {
            tasks.Add(this.ContentListVM.OnLoadAsync()); 
            return base.OnLoadFirstAsync(tasks);
        }

        public void OnRefresh()
        {
            this.ContentListVM.RefreshCommand.Execute(null);
        }

        protected override List<Menu> OnGetMenusNav2(List<Menu> menus)
        {
            menus.Add(new Menu(MenuEnum.Add, IconFont.Plus));
            menus.Add(new Menu(MenuEnum.Edit, IconFont.Pen));
            menus.Add(new Menu(MenuEnum.Delete, IconFont.Trash));
            if (this.IsPicker) menus.Add(new Menu(MenuEnum.Select, IconFont.Check));

            return base.OnGetMenusNav2(menus);
        }

        protected virtual CListVM OnGetContentListVM()
        {
            return null;
        }
        
        protected virtual VM OnGetInfoVM()
        {
            return null;
        }

        private async Task OnEditAsync(string id)
        {
            var pagename = this.PageEditName;
            var title = this.Title1;
            var param = new Param<E>(null, null, new PageEditParam(id, title, "", SaveEnum.Save));
            await this.OnGotoAsync(pagename, param);
        }
        private async Task OnDeleteAsync(string id)
        {
            var db = this.Db;
            var isreadonly = await db.IsReadOnly(id);
            if (isreadonly) this.OnAlert("Data ini bersifat ReadOnly !\nAnda tidak dapat melakukan Hapus/Edit utk data ini.");
            else {
                var isok = await this.OnAlert("Hapus Data", $"Anda yakin ingin hapus data ini ?\nData : {this.CaptionSelecteds}", "Yakin", "Batal");
                if (isok) {
                    var issuccess = await db.Delete(id);
                    if (issuccess) this.OnRefresh();
                }
            }
        }

        public override async void OnMenuSelect(MenuEnum menu)
        {
            switch (menu) {
                case MenuEnum.Add: {
                        this.AddCommand.Execute(null);
                        break;
                    }
                case MenuEnum.Edit:{
                        this.EditCommand.Execute(this.IdSelected);
                        break;
                    }
                case MenuEnum.Delete: {
                        this.DeleteCommand.Execute(this.IdSelected);
                        break;
                    }
                case MenuEnum.Back: {
                        if (this.IsDevicePhone && this.IsViewInfo) this.IsExpandList = true;
                        else this.OnMenuSelect(MenuEnum.Back);
                        break;
                    }

                case MenuEnum.Select: {
                        if (this.PickerSelectedChanged != null) this.PickerSelectedChanged(this.IdSelecteds, this.CaptionSelecteds);
                        await this.OnGoBackAsync();
                        break;
                    }
                default: base.OnMenuSelect(menu);break;
            }
        }
    }
}
