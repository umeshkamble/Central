

namespace Central.App.ViewModels
{
    public interface IPanelGrupListVM<VMList, VM, E>   where VMList : PanelListVM<VM, E>
                                                       where VM : PanelVM<E>
                                                       where E : EntityBase
    {
        ObservableCollection<VMList> Items { get; set; }
        List<E> Entitys { get; }
        List<E> EntitySelecteds { get; set; }

        int ItemCount { get; }
        int ItemSelectedCount { get; }

        SelectionEnum SelectionEnum { get; set; }
        int TotalFinished { get; set; }
        bool IsRefreshing { get; set; }

        Command InsertCommand { get; set; }
    }

    public class PanelGrupListVM<VMList, VM, E> : BaseVM<E>, IPanelGrupListVM<VMList,VM, E>  where VMList : PanelListVM<VM, E>
                                                                                            where VM : PanelVM<E>
                                                                                            where E : EntityBase
    {
        public ObservableCollection<VMList> Items { get; set; }
        
        public List<E> Entitys
        {
            get{
                try{
                    var entitys = new List<E>();
                    foreach (var item in this.Items) {
                        entitys.AddRange(item.Entitys);
                    }
                    return entitys;
                }
                catch { }
                return new List<E>();
            }
        }

        private List<E> EntitySelecteds_;
        public List<E> EntitySelecteds
        {
            set {
                if (value is null) return;
                
                EntitySelecteds_ = value;
                var items = this.Items;
                foreach (var entity in EntitySelecteds_) {
                    var id = entity.Id;
                    foreach (var item in items) {
                        item.OnSelect(id);
                    }
                }
            }
            get {
                var entitys = new List<E>();
                var itemselecteds = this.Items.AsEnumerable().Select(x => x.ItemSelecteds).ToList();
                foreach (var item in itemselecteds) {
                    var items = item.AsEnumerable().Select(x => x.Entity).ToList();
                    entitys.AddRange(items);
                }
                return entitys;
            }
        }
        
        public SelectionEnum SelectionEnum { get; set; }
        public int TotalFinished { get; set; }
        public int ItemCount
        {
            get { return this.Items.Count; }
        }
        public int ItemSelectedCount
        {
            get { return this.EntitySelecteds.Count; }
        }
        public bool IsRefreshing { get; set; }

        #region Command
        public Command LoadCommand { get; set; }
        public Command InsertCommand { get; set; }
        #endregion Command

        #region Event
        public delegate void ItemEventHandler(VM item);
        public event ItemEventHandler SelectedChanged, UnSelectedChanged;
        #endregion Event

        public PanelGrupListVM(SelectionEnum selectionenum)
        {
            this.SelectionEnum = selectionenum;
            this.Items = new ObservableCollection<VMList>();
            this.InsertCommand = new Microsoft.Maui.Controls.Command<List<E>>((List<E> entitys) => {
                var tasks = new List<Task> {
                    this.OnInsertAsync(entitys, true)
                };
                this.LoadAsyncCommand.Execute(tasks);
            });
        }

        protected virtual IEnumerable<IGrouping<string, E>> GetGroupBy(List<E> entitys)
        {
            return entitys.GroupBy(g => g.Id);
        }

        protected virtual VMList OnGetPanelList()
        {
            return null;
        }

        public async Task OnInsertAsync(List<E> entitys, bool isclear)
        {
            if (this.IsRefreshing) return;
            if (isclear) this.Items.Clear();
            this.IsRefreshing = true;
            
            try{
                this.OnLog($"Insert(List<E> entitys) : {entitys.Count}");
                var grups = this.GetGroupBy(entitys);
                var count = grups.Count();

                var results = new List<List<E>>();
                foreach (var g in grups){
                    string id = g.Key;
                    this.OnLog($"- Grup : {id}");

                    var r = new List<E>();
                    foreach (var e in g){
                        this.OnLog($"- Item : {e.Id}");
                        r.Add(e);
                    }

                    var vmlist = this.OnGetPanelList();
                    vmlist.SelectedChanged += ((item) => this.OnSelectedChanged(item));
                    vmlist.UnSelectedChanged += ((item) => this.OnUnSelectedChanged(item));
                    this.Items.Add(vmlist);

                    results.Add(r);
                }

                var tasks = new List<Task>();
                var items = this.Items;

                for (int i = 0; i < items.Count; i++) {
                    var item = items[i];
                    tasks.Add(item.OnInsertAsync(results[i], true));
                }

                if (tasks.Count > 0) await Task.WhenAll(tasks);
            }
            catch (Exception ex) {
                this.OnLog(ex);
            }

            finally {
                this.IsRefreshing = false;
            }
        }

        protected virtual void OnSelectedChanged(VM item)
        {
            if (this.ItemSelectedCount < this.ItemCount) return;
            if (this.SelectedChanged != null) this.SelectedChanged(item);
            this.OnLog($"OnSelectedChanged(VM item) : {item.Id}");
        }

        protected virtual void OnUnSelectedChanged(VM item)
        {
            if (this.UnSelectedChanged != null) this.UnSelectedChanged(item);
            this.OnLog($"OnUnSelectedChanged(VM item) : {item.Id}");
        }
    }
}
