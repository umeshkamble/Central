
namespace Central.App.ViewModels
{
    public enum TemplateEnum
    {
        Grid,
        List,
        T1,
        T2,
        Info,
        Edit1,
        Edit2
    }

    public enum SelectionEnum
    {
        Single,
        SingleDeselect,
        Multiple,
        None
    }

    public interface IPanelListVM<VM, E> where VM : PanelVM<E> where E : EntityBase
    {
        Query<E> Query { get; set; }
        Query<E> QueryDef { get; set; }
        int CurrentPage { get; set; }

        PanelEnum PanelEnum { get; set; }
        string TemplateName { get; set; }
        DataTemplate Template { get; set; }
        List<TemplateEnum> Templates { get; set; }
        TemplateEnum TemplateSelected { get; set; }

        int TemplateSelectedIndex { get; set; }
        int TemplateSelectedIndexNext { get; set; }

        ObservableCollection<VM> Items { get; set; }
        List<VM> ItemSelecteds { get; }
        VM ItemSelectedFirst { get; set; }
        SelectionEnum SelectionEnum { get; set; }
        List<E> Entitys { get; }
        
        string IdSelected { get; }
        string IdSelecteds { get; }
        string CaptionSelecteds { get; }

        int ItemCount { get; }
        int ItemSelectedCount { get; }
        
        bool IsRefreshing { get; set; }
        bool IsLoadMore { get; set; }
        bool IsLockSelected { get; set; }

        void OnAction(VM item);
        void OnSelect(int index);
        void OnSelect(string id);
        void OnSelect(string id, bool IsRun);
        void OnSelectFirst();
        void OnSelectLast();
        void OnUnSelect(string id);

        void OnClearSelected();
        void OnClearSelected(VM item);
        void OnClearSelected(string id);
        
        void OnTemplateSelectNext();
        Query<E> OnGetQueryCurrent();

        Command RefreshCommand { get; set; }
        Command LoadMoreCommand { get; set; }
        Command InsertCommand { get; set; }
        Command InsertOneCommand { get; set; }
        Command UpdateCommand { get; set; }
        Command DeleteOneCommand { get; set; }
        Command LoadByIdCommand { get; set; }
        Command LoadByKeywordCommand { get; set; }
    }

    public class PanelListVM<VM, E> : BaseVM<E>, IPanelListVM<VM, E> where VM : PanelVM<E> where E : EntityBase
    {
        #region Properties
        public string TemplateName { get; set; }

        public Query<E> Query { get; set; }
        public Query<E> QueryDef { get; set; }

        public int CurrentPage { get; set; } = 1;
        public PanelEnum PanelEnum { get; set; } = PanelEnum.GridList;

        private DataTemplate Template_;
        public DataTemplate Template
        {
            set { this.OnSetProperty(ref Template_, value); }
            get { return Template_; }
        }

        public List<TemplateEnum> Templates { get; set; }

        private TemplateEnum TemplateSelected_;
        public TemplateEnum TemplateSelected
        {
            set {
                TemplateSelected_ = value;
                var templateRes = $"{TemplateName}{TemplateSelected_.ToString()}";

                try { this.Template = (DataTemplate)App.Current.Resources[templateRes];}
                catch (Exception ex) {
                    this.OnLog($"Template not found !!\n{ex.Message}");
                }
            }
            get { return TemplateSelected_; }
        }

        private int TemplateSelectedIndex_;
        public int TemplateSelectedIndex
        {
            set {
                TemplateSelectedIndex_ = value;
                this.TemplateSelected = this.Templates[TemplateSelectedIndex_];
            }
            get { return TemplateSelectedIndex_; }
        }

        public int TemplateSelectedIndexNext { get; set; }

        private ObservableCollection<VM> Items_;
        public ObservableCollection<VM> Items
        {
            set { this.OnSetProperty(ref Items_, value); }
            get { return Items_; }
        }

        public List<VM> ItemSelecteds
        {
            get {
                try { return this.Items.AsEnumerable().Where(x => x.IsSelected).ToList(); }
                catch { }

                return new List<VM>();
            }
        }

        private VM ItemSelectedFirst_;
        public VM ItemSelectedFirst
        {
            set {
                if (value == ItemSelectedFirst_) return;
                ItemSelectedFirst_ = value;

                if (this.IsRun2 && ItemSelectedFirst_ != null) this.OnSelect(ItemSelectedFirst_);
                this.OnPropertyChanged();
                this.IsRun2 = true;
            }
            get {
                try { return this.ItemSelecteds[0]; }
                catch { }

                return null;
            }
        }

        public virtual List<E> Entitys
        {
            get {
                try {
                    return this.Items.AsEnumerable().Select(x => x.Entity).ToList();
                }
                catch { }
                return new List<E>();
            }
        }

        public string IdSelected
        {
            get {
                if (this.ItemSelectedFirst == null) return "";
                return this.ItemSelectedFirst.Id;
            }
        }
        public string IdSelecteds
        {
            get {
                try {
                    var ids = this.ItemSelecteds.AsEnumerable().Select(x => x.Id).ToList();
                    return Base.ToString(ids, ',');
                }
                catch { }
                return "";
            }
        }
        public string CaptionSelecteds
        {
            get {
                try {
                    var captions = this.ItemSelecteds.AsEnumerable().Select(x => x.Caption).ToList();
                    return Base.ToString(captions, ',');
                }
                catch { }
                return "";
            }
        }

        private SelectionEnum SelectionEnum_;
        public SelectionEnum SelectionEnum
        {
            set { this.OnSetProperty(ref SelectionEnum_, value); }
            get { return SelectionEnum_; }
        }

        public int ItemSelectedCount
        {
            get { return this.ItemSelecteds.Count; }
        }

        public int ItemCount
        {
            get { return this.Items.Count; }
        }

        private bool IsRefreshing_;
        public bool IsRefreshing
        {
            set { this.OnSetProperty(ref IsRefreshing_, value); }
            get { return IsRefreshing_; }
        }

        public bool IncAll { get; set; }
        public bool IsLoadMore { get; set; }
        public bool IsLockSelected { get; set; }

        private bool IsRun1 { get; set; }
        private bool IsRun2 { get; set; }
        #endregion Properties

        #region Command
        public Command LoadCommand { get; set; }
        public Command RefreshCommand { get; set; }
        public Command LoadMoreCommand { get; set; }
        public Command InsertCommand { get; set; }
        public Command InsertOneCommand { get; set; }
        public Command UpdateCommand { get; set; }
        public Command DeleteOneCommand { get; set; }
        public Command LoadByIdCommand { get; set; }
        public Command LoadByKeywordCommand { get; set; }
        #endregion Command

        #region Event
        public delegate void ItemEventHandler(VM item);
        public event ItemEventHandler SelectedChanged, UnSelectedChanged, ActionChanged;

        public delegate void PanelListEventHandler();
        public event PanelListEventHandler Clear, Insert, Update, Delete;
        #endregion Event

        public PanelListVM(List<TemplateEnum> ts, SelectionEnum selectionenum, PanelEnum panelenum, string tname, bool incall)
        {
            this.PanelEnum = panelenum;
            this.Templates = ts;
            this.TemplateName = tname;
            this.SelectionEnum = selectionenum;
            this.IncAll = incall;
            this.IsLockSelected = false;
            this.IsRun1 = this.IsRun2 = true;

            this.Items = new ObservableCollection<VM>();
            this.InsertCommand = new Microsoft.Maui.Controls.Command<List<E>>((List<E> entitys) => {
                var tasks = new List<Task> {
                    this.OnInsertAsync(entitys,true)
                };
                this.LoadAsyncCommand.Execute(tasks);
            });
            this.InsertOneCommand = new Microsoft.Maui.Controls.Command<E>((E entity) => {
                var tasks = new List<Task> {
                    this.OnInsertAsync(entity)
                };
                this.LoadAsyncCommand.Execute(tasks);
            });
            this.UpdateCommand = new Microsoft.Maui.Controls.Command<E>((E entity) => {
                var tasks = new List<Task> {
                    this.OnUpdateAsync(entity)
                };
                this.LoadAsyncCommand.Execute(tasks);
            });
            this.DeleteOneCommand = new Microsoft.Maui.Controls.Command<VM>((VM item) => {
                var tasks = new List<Task> {
                    this.OnDeleteAsync(item)
                };
                this.LoadAsyncCommand.Execute(tasks);
            });
            this.RefreshCommand = new Microsoft.Maui.Controls.Command(() => {
                var tasks = new List<Task> {
                    this.OnRefreshAsync()
                };
                this.LoadAsyncCommand.Execute(tasks);
            });
            this.LoadCommand = new Microsoft.Maui.Controls.Command<Query<E>>((Query<E> query) => {
                var tasks = new List<Task> {
                    this.OnLoadAsync(query)
                };
                this.LoadAsyncCommand.Execute(tasks);
            });
            this.LoadMoreCommand = new Microsoft.Maui.Controls.Command(() => {
                var tasks = new List<Task> {
                    this.OnLoadMoreAsync()
                };
                this.LoadAsyncCommand.Execute(tasks);
            });
            this.LoadByIdCommand = new Microsoft.Maui.Controls.Command<string>((string id) => {
                var tasks = new List<Task> {
                    this.OnLoadByIdAsync(id)
                };
                this.LoadAsyncCommand.Execute(tasks);
            });
            this.LoadByKeywordCommand = new Microsoft.Maui.Controls.Command<string>((string keyword) => {
                var tasks = new List<Task> {
                    this.OnLoadByKeywordAsync(keyword)
                };
                this.LoadAsyncCommand.Execute(tasks);
            });

            this.OnTemplateSelectNext(-1);
        }

        public VM OnGetItem(string id)
        {
            return this.Items.AsEnumerable().Where(x => x.Id.Equals(id)).FirstOrDefault();
        }
        public Query<E> OnGetQueryCurrent()
        {
            var filters = this.Query.Filters.ToList();
            var sorts = this.Query.Sorts.ToList();
            var limit = this.QueryDef.Limit;
            var skip = 0;

            return this.Db.GetQuery(filters, sorts, limit, skip);
        }
        public List<TemplateEnum> OnGetTemplateDefs()
        {
            return new List<TemplateEnum>() { TemplateEnum.List, TemplateEnum.Grid };
        }
        public TemplateEnum OnGetTemplateNext()
        {
            return this.Templates[this.TemplateSelectedIndexNext];
        }
        public void OnTemplateSelectNext()
        {
            this.OnTemplateSelectNext(this.TemplateSelectedIndex);
        }
        private void OnTemplateSelectNext(int index)
        {
            int count = this.Templates.Count;
            int indexnext1 = index >= count - 1 ? 0 : index + 1;
            int indexnext2 = indexnext1 >= count - 1 ? 0 : indexnext1 + 1;

            this.TemplateSelectedIndex = indexnext1;
            this.TemplateSelectedIndexNext = indexnext2;
        }

        public void OnClearSelected()
        {
            var items = this.ItemSelecteds;
            foreach (var item in items) {
                this.OnClearSelected(item);
            }
        }
        public void OnClearSelected(string id)
        {
            var item = this.Items.AsEnumerable().Where(x => x.Id == id).FirstOrDefault();
            this.OnClearSelected(item);
        }
        public void OnClearSelected(VM item)
        {
            if (item == null) return;
            this.OnUnSelectedChanged(item);
        }

        public void OnSelect(int index)
        {
            try {
                var id = this.Items[0].Id;
                this.OnSelect(id);
            }
            catch { }
        }
        public void OnSelect(string id)
        {
            this.OnSelect(id, true);
        }
        public void OnSelect(string id, bool isrun)
        {
            id = Base.ToString(id).ToLower().Trim();
            var item = this.OnGetItem(id);
            this.OnSelect(item, isrun);
        }
        public void OnSelect(VM item, bool isrun)
        {
            try {
                this.IsRun1 = isrun;
                if (item is null) throw new Exception();
                this.OnSelect(item);
            }
            catch { }
            this.IsRun1 = true;
        }
        public void OnSelect(VM item)
        {
            if (this.IsLockSelected) return;

            var x = !item.IsSelected;
            if (this.SelectionEnum == SelectionEnum.Single || this.SelectionEnum == SelectionEnum.None) {
                this.OnClearSelected();
                x = true;
            }
            else if (this.SelectionEnum == SelectionEnum.SingleDeselect) {
                this.OnClearSelected();
            }

            if (x) this.OnSelectedChanged(item);
            else this.OnUnSelectedChanged(item);
        }
        public virtual void OnSelectFirst()
        {
            try { this.OnSelect(this.Items[0]); }
            catch (Exception ex)
            {
                this.OnLog(ex);
            }
        }
        public virtual void OnSelectLast()
        {
            try { this.OnSelect(this.Items[this.ItemCount - 1]); }
            catch (Exception ex) { this.OnLog(ex); }
        }

        public void OnUnSelect(string id)
        {
            id = Base.ToString(id).ToLower().Trim();
            var item = this.OnGetItem(id);
            this.OnUnSelect(item);
        }
        public void OnUnSelect(VM item)
        {
            if (item == null) return;
            this.OnUnSelectedChanged(item);
        }
        public void OnAction(VM item)
        {
            this.OnActionChanged(item);
        }

        public virtual void OnSelectedChanged(VM item)
        {
            item.IsSelected = true;

            this.IsRun2 = false;
            this.ItemSelectedFirst = this.ItemSelectedFirst;

            if (!this.IsRun1) return;
            if (this.SelectedChanged != null) this.SelectedChanged(item);
            this.OnLog($"OnSelectedChanged(VM item) : {item.Id}");
        }
        protected void OnUnSelectedChanged(VM item)
        {
            if (!item.IsSelected) return;
            item.IsSelected = false;

            if (!this.IsRun1) return;
            if (this.UnSelectedChanged != null) this.UnSelectedChanged(item);
            this.OnLog($"OnUnSelectedChanged(VM item) : {item.Id}");
        }
        protected void OnActionChanged(VM item)
        {
            this.OnSelect(item);
            if (this.ActionChanged != null) this.ActionChanged(item);

            this.OnLog($"OnActionChanged(VM item) : {item.Id}");
        }

        protected override Task OnLoadBeginAsync()
        {
            this.IsLockSelected = false;
            return base.OnLoadBeginAsync();
        }
        public override Task OnLoadAsync(List<Task> tasks)
        {
            if (tasks.Count == 0) tasks.Add(this.OnLoadAsync(null));
            return base.OnLoadAsync(tasks);
        }
        private async Task OnLoadAsync(Query<E> query)
        {
            if (this.IsRefreshing) return;

            this.IsRefreshing = true;
            this.IsLoadMore = false;

            try {
                this.OnLog($"Load(Query<E> query)");
                this.CurrentPage = 0;
                this.QueryDef = this.Db.GetQueryDef(); 
                this.Query = query is null ? this.QueryDef : query;
                this.OnClear();
                this.OnClearSelected();

                this.IsLoadMore = true;
                await this.OnLoadMoreAsync();
            }
            catch (Exception ex) {
                this.OnLog(ex);
            }
            finally {
                this.IsRefreshing = false;
            }
        }
        private async Task OnLoadMoreAsync()
        {
            if (!this.IsLoadMore) return;
            try {
                this.CurrentPage++;
                var limit = this.QueryDef.Limit;
                var skip = (this.CurrentPage - 1) * limit;
                this.OnLog($"LoadMore() : Page {this.CurrentPage}");

                var entitys = await Db.Get(this.Query.Filter, this.Query.Sort, this.Query.Limit, skip);
                if (entitys is null) throw new Exception("LoadMore() : Entitys is null !");

                this.IsLoadMore = entitys.Count == 0 ? false : true;
                await this.OnInsertAsync(entitys, false);
            }
            catch (Exception ex) {
                this.OnLog(ex);
                this.IsLoadMore = false;
            }
        }
        private async Task OnLoadByIdAsync(string id)
        {
            await this.OnLoadByIdKeywordAsync(id, false);
        }
        private async Task OnLoadByKeywordAsync(string keyword)
        {
            await this.OnLoadByIdKeywordAsync(keyword, true);
        }
        private async Task OnLoadByIdKeywordAsync(string text, bool iskeyword)
        {
            this.OnLog($"OnLoadByIdKeywordAsync(string text, bool iskeyword) : {text} {iskeyword}");

            var db = this.Db;
            var filterDef = iskeyword ? db.GetFilterByKeyword(text) : db.GetFilterById(text);
            var filters = this.QueryDef.Filters.ToList();
            var sorts = this.QueryDef.Sorts.ToList();
            var limit = this.QueryDef.Limit;

            filters.Add(new Filter<E>(FilterEnum.Keyword, filterDef, text));
            var query = db.GetQuery(filters, sorts, limit, 0);
            await this.OnLoadAsync(query);
        }

        private async Task OnRefreshAsync()
        {
            if (this.ItemSelectedCount <= 0) return;
            var id = this.IdSelected;

            var query = this.OnGetQueryCurrent();
            await this.OnLoadAsync(query);
            this.OnSelect(id);
        }

        public async Task OnInsertAsync(E entity)
        {
            await this.OnInsertAsync(new List<E> { entity }, false);
        }
        public async Task OnInsertAsync(List<E> entitys, bool isclear)
        {
            this.OnLog($"Insert(List<E> entitys) : {entitys.Count}");
            if (isclear) this.OnClear();

            var no = this.ItemCount;
            var panelenum = this.PanelEnum;
            var tasks = new List<Task<VM>>();
            foreach (var entity in entitys) {
                no++;
                tasks.Add(this.OnInsertAsync(entity, panelenum, no, null, null));
            }

            if (tasks.Count > 0) {
                var items = await Task.WhenAll(tasks);
                foreach (var item in items) {
                    item.Action += ((vm) => this.OnAction(item));
                    item.Select += ((vm) => this.OnSelect(item));
                    this.OnInsert(item);
                    await this.OnInsertedAsync(item);
                }
            } 
        }
        protected virtual async Task<VM> OnInsertAsync(E entity, PanelEnum panelenum, int no, ImageSource imagesource, VM item)
        {
            try {
                if (item is null) throw new Exception("ERROR : OnInsertAsync(E entity, PanelEnum panelenum, int no, ImageSource imagesource, VM item) belum di override !");
                await item.OnLoadAsync();
            }
            catch (Exception ex) {
                this.OnLog(ex);
            }
            return await Task.FromResult(item);
        }
        protected virtual async Task OnInsertedAsync(VM item)
        {
            await Task.FromResult(true);
        }

        private async Task OnUpdateAsync(E entity)
        {
            this.OnUpdate(entity);
            //this.OnPropertyChanged("Items");
            await Task.FromResult(true);
        }
        public async Task OnDeleteAsync(VM item)
        {
            this.OnDelete(item);

            var no = 1;
            foreach (var vm in this.Items){
                vm.No = no;
                no++;
            }

            await Task.FromResult(true);  
        }

        public virtual void OnClear()
        {
            this.Items.Clear();
            if (this.Clear != null) this.Clear();
        }
        protected virtual void OnInsert(VM item)
        {
            this.Items.Add(item);
            if (this.Insert != null) this.Insert();
        }
        protected virtual void OnUpdate(E entity)
        {
            var item = this.ItemSelectedFirst;
            item.Entity = entity;

            if (this.Update != null) this.Update();
        }
        protected virtual void OnDelete(VM item)
        {
            this.Items.Remove(item);
            if (this.Delete != null) this.Delete();
        }
    }
}
