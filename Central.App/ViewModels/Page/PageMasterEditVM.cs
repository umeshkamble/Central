
namespace Central.App.ViewModels
{
    public enum SaveEnum
    {
        Save,
        SaveDraft,
        SaveTemp
    }

    public class PageEditParam
    {
        public string Id { get; set; }
        public string Title1 { get; set; }
        public string Title2 { get; set; }
        public SaveEnum SaveEnum { get; set; }

        public PageEditParam(string id, string title1,string title2, SaveEnum saveenum)
        {
            this.Id = id;
            this.Title1 = title1;
            this.Title2 = title2;
            this.SaveEnum = saveenum;
        }
    }

    
    public interface IPageMasterEditVM<VM, E> where VM : PanelVM<E>
                                              where E : EntityBase
    {
        VM EditVM { get; set; }

        GridLength ContentListWidth { get; set; }
        GridLength ContentEditWidth { get; set; }

        bool IsNew { get; }
        bool IsReadOnly { get; set; }
        bool IsViewList { get; set; }
        bool IsViewListMinimize { get; set; }
        Command LoadByIdCommand { get; set; }
    }

    [QueryProperty(nameof(PageEditParam), nameof(PageEditParam))]
    public class PageMasterEditVM<VM, E> : PageVM<E>, IPageMasterEditVM<VM, E> where VM : PanelVM<E>
                                                                               where E : EntityBase
    {
        #region Properties
        private PageEditParam PageEditParam_;
        public PageEditParam PageEditParam
        {
            set {
                if (value is null) return;

                PageEditParam_ = value;
                this.Id = PageEditParam_.Id;
                this.Title1 = PageEditParam_.Title1;
                this.Title2 = PageEditParam_.Title2;
                this.SaveEnum = PageEditParam_.SaveEnum;

                this.EditVM.LoadByIdCommand.Execute(PageEditParam_.Id);
            }
            get => PageEditParam_;
        }

        /*
        public override E Entity 
        {
            set {
                if (value is null) return;

                var entity = value;
                base.Entity = entity;
                this.EditVM.LoadByEntityCommand.Execute(entity);
            }
            get => this.EditVM.Entity;
        }
        */

        public VM EditVM { get; set; }
        public SaveEnum SaveEnum { get; set; }

        private GridLength ContentListWidth_;
        public GridLength ContentListWidth
        {
            set { this.OnSetProperty(ref ContentListWidth_, value); }
            get { return ContentListWidth_; }
        }

        private GridLength ContentEditWidth_;
        public GridLength ContentEditWidth
        {
            set { this.OnSetProperty(ref ContentEditWidth_, value); }
            get { return ContentEditWidth_; }
        }

        private bool IsViewList_;
        public virtual bool IsViewList
        {
            set { this.OnSetProperty(ref IsViewList_, value); }
            get { return IsViewList_; }
        }

        private bool IsViewEdit_;
        public virtual bool IsViewEdit
        {
            set { this.OnSetProperty(ref IsViewEdit_, value); }
            get { return IsViewEdit_; }
        }

        private bool IsExpandList_;
        public bool IsExpandList
        {
            set {
                IsExpandList_ = value;

                var isviewlist = true;
                var isviewedit = true;
                GridLength width1, width2;
                if (DeviceInfo.Current.Idiom == DeviceIdiom.Phone) {
                    width1 = IsExpandList_ ? new GridLength(0.999, GridUnitType.Star) : new GridLength(0.001, GridUnitType.Star);
                    width2 = IsExpandList_ ? new GridLength(0.001, GridUnitType.Star) : new GridLength(0.999, GridUnitType.Star);

                    isviewlist = IsExpandList_;
                    isviewedit = !IsExpandList_;
                }
                else {
                    width1 = IsExpandList_ ? new GridLength(0.75, GridUnitType.Star) : new GridLength(0.25, GridUnitType.Star);
                    width2 = IsExpandList_ ? new GridLength(0.25, GridUnitType.Star) : new GridLength(0.75, GridUnitType.Star);
                }

                this.ContentListWidth = width1;
                this.ContentEditWidth = width2;

                this.IsViewList = isviewlist;
                this.IsViewEdit = isviewedit;
            }
            get => IsExpandList_;
        }

        private bool IsReadOnly_;
        public bool IsReadOnly
        {
            set {
                IsReadOnly_ = value;
                this.IsViewSave = !IsReadOnly_;
                this.IsViewPrint = (IsReadOnly_ && this.SaveEnum == SaveEnum.Save) ? true : false;
            }
            get { return this.EditVM.IsReadOnly; }
        }

        private bool IsViewSave_;
        public bool IsViewSave
        {
            set {
                IsViewSave_ = value;
                this.MenuListNav2VM.OnVisible(MenuEnum.Save, IsViewSave_);
            }
            get { return IsViewSave_; }
        }

        private bool IsViewPrint_;
        public bool IsViewPrint
        {
            set {
                IsViewPrint_ = value;
                this.MenuListNav2VM.OnVisible(MenuEnum.Print, IsViewPrint_);
            }
            get { return IsViewPrint_; }
        }

        public virtual bool IsViewListMinimize { get; set; }
        private bool IsRun { get; set; }
        
        public override bool IsValid
        {
            get { return this.EditVM.IsValid; }
        }

        public bool IsNew
        {
            get { return this.EditVM.IsNew; }
        }
        #endregion Properties

        #region Command
        public Command LoadByIdCommand { get; set; }
        public Command LoadByEntityCommand { get; set; }
        #endregion Command

        #region Event
        public delegate void EditEventHandler(E entity, bool isnew, SaveEnum saveneum);
        public event EditEventHandler Saved;
        #endregion Event    

        public PageMasterEditVM() : base("","")
        {
            this.SaveEnum = SaveEnum.Save;
            this.IsViewSave = true;
            this.IsViewPrint = false;
            this.IsReadOnly = false;
            this.IsViewListMinimize = false;
            this.IsExpandList = false;
            
            this.EditVM = this.OnGetEditVM(null);
            this.EditVM.MenuSelectedChanged += this.OnMenuSelect;
            this.EditVM.ReadOnlyChanged += ((isreadonly) => this.IsReadOnly = isreadonly);
            this.EditVM.TitleChanged += ((title1, title2) => {
                this.Title2 = title2;
            });
        }

        protected override Task<List<Task>> OnLoadFirstAsync(List<Task> tasks)
        {
            //tasks.Add(this.EditVM.OnLoadAsync());
            return base.OnLoadFirstAsync(tasks);
        }

        protected override List<Menu> OnGetMenusNav2(List<Menu> menus)
        {
            menus.Add(new Menu(MenuEnum.Save, IconFont.Save));
            //menus.Add(new Menu(MenuEnum.Print, IconFont.Print));
            return base.OnGetMenusNav2(menus);
        }

        protected virtual VM OnGetEditVM(VM vm)
        {
            return vm;
        }
        
        public override async void OnMenuSelect(MenuEnum menu)
        {
            switch (menu) {
                case MenuEnum.Save: {
                        await this.OnSave(this.Entity, this.IsNew, this.SaveEnum);
                        break;
                    }
                case MenuEnum.Print: {
                        await this.OnPrint(this.Entity);
                        break;
                    }
                default: base.OnMenuSelect(menu);break;
            }
        }

        private async Task<bool> OnSavePrepare(E entity, bool isnew, SaveEnum saveenum)
        {
            if (!this.IsValid) return false;
            if (saveenum != SaveEnum.SaveTemp) {
                var msg = saveenum == SaveEnum.Save ? "Anda yakin ingin simpan data ini ?" : "Simpan sebagai draft ?";
                var isok = await this.OnAlert("Konfirmasi", msg, "Yakin", "Batal");
                if (!isok) return false;
            }

            return true;
        }

        private async Task<bool> OnSave(E entity, bool isnew, SaveEnum saveenum)
        {
            if (!await this.OnSavePrepare(entity, isnew, saveenum)) return false;

            this.IsBusy = true;
            try {
                entity.IsDraft = saveenum == SaveEnum.Save ? false : true;
                if (saveenum != SaveEnum.SaveTemp){
                    var result = await this.Db.Save(entity, isnew);
                    if (!result.IsSuccess) throw new Exception(result.Message);

                    entity = result.Entity;
                }
            }
            catch (Exception ex) {
                this.OnAlert("Simpan Gagal", ex.Message, "OK");
                return false;
            }

            await this.OnSaveAfter(entity, isnew, saveenum);
            this.IsBusy = false;
            
            return true;
        }

        private async Task<bool> OnSaveAfter(E entity, bool isnew, SaveEnum saveenum)
        {
            if (saveenum == SaveEnum.Save || saveenum == SaveEnum.SaveDraft) {
                this.OnAlert("Konfirmasi", "Data Berhasil di simpan !", "OK");
                await this.OnPrint(entity);
            }

            if (this.Saved != null) {
                //----jika SaveTemp, maka ckp GoBackAsync dengan mengirim null-------//
                this.Saved(entity, isnew, saveenum);
                await this.OnGoBackAsync();
            }
            else {
                //----jika Save & SaveDraft, maka ckp GoBackAsync dengan mengirim id--//
                var param = new Param<E>(null, new PageMasterParam2(entity.Id));
                await this.OnGoBackAsync(param);
            }

            return await Task.FromResult(true);
        }
       
        protected virtual async Task<bool> OnPrint(E entity)
        {
            return await Task.FromResult(true);
        }
    }
}
