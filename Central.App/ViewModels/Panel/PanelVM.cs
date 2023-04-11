
using Central.Library;
namespace Central.App.ViewModels
{
    public enum PanelEnum
    { 
        GridList,
        Info,
        Edit1,
        Edit2
    }

    public interface IPanelVM<E> where E : EntityBase
    {
        PanelEnum PanelEnum { get; set; }
        int No { get; set; }
        string Caption { get; }
        ImageSource ImageSource { get; set; }
        
        bool IsSelected { get; set; }
        bool IsVisible { get; set; }
    }

    public class PanelVM<E> : BaseVM<E>, IPanelVM<E> where E : EntityBase
    {
        #region Properties
        public PanelEnum PanelEnum { get; set; } = PanelEnum.GridList;

        public override E Entity
        {
            set {
                if (value is null) return;
                var entity = value;
                base.Entity = entity;

                this.IsNew = this.IsNew;
                this.Title2 = this.IsNew ? "Tambah Baru" : $"Edit - {this.Caption}";
                this.OnReadOnlyChanged();
            }

            get => base.Entity;
        }

        private int No_;
        public virtual int No
        {
            set { this.OnSetProperty(ref No_, value); }
            get { return No_; }
        }

        private ImageSource ImageSource_;
        public ImageSource ImageSource
        {
            set { this.OnSetProperty(ref ImageSource_, value); }
            get { return ImageSource_; }
        }

        private bool IsSelected_;
        public virtual bool IsSelected
        {
            set { this.OnSetProperty(ref IsSelected_, value); }
            get { return IsSelected_; }
        }

        private bool IsVisible_;
        public virtual bool IsVisible
        {
            set { this.OnSetProperty(ref IsVisible_, value); }
            get { return IsVisible_; }
        }

        private bool IsReadOnly_;
        public virtual bool IsReadOnly
        {
            set {
                IsReadOnly_ = value;
                if (this.ReadOnlyChanged != null) this.ReadOnlyChanged(IsReadOnly_);
                this.OnPropertyChanged();
            }
            get { return IsReadOnly_; }
        }

        private bool IsNew_;
        public virtual bool IsNew
        {
            set { IsNew_ = value; }
            get { return Base.ToString(this.Id).Trim() == "" ? true : false; }
        }
        
        public virtual string Caption
        {
            get { return "Not-Set"; }
        }

        #endregion Properties

        #region Command
        public Command LoadByIdCommand { get; set; }
        public Command LoadByEntityCommand { get; set; }
        public Command SelectCommand { get; set; }
        public Command ActionCommand { get; set; }
        #endregion Command

        #region Event
        public delegate void ReadOnlyEventHandler(bool isreadonly);
        public event ReadOnlyEventHandler ReadOnlyChanged;

        public event EventHandler Action, Select;
        #endregion Event

        public PanelVM(E entity) : this(entity, PanelEnum.GridList) { }
        public PanelVM(E entity, PanelEnum panelenum) : this(entity, panelenum, 1, null) { }
        public PanelVM(E entity, PanelEnum panelenum, int no, ImageSource imagesource) 
        {
            this.OnInitInput(entity, panelenum);
            this.OnInitEntity(entity, panelenum, no, imagesource);
            this.OnInitEvent(entity, panelenum);
        }

        protected virtual void OnInitInput(E entity, PanelEnum panelenum) { }
        protected void OnInitEntity(E entity, PanelEnum panelenum, int no, ImageSource imagesource)
        { 
            this.PanelEnum = panelenum;
            this.Entity = entity;
            //this.EntityB = entity;
            this.No = no;
            this.ImageSource = imagesource;
            this.IsVisible = true;
            this.IsReadOnly = false;
            
            this.SelectCommand = new Command(() => this.OnSelect());
            this.ActionCommand = new Command(() => this.OnAction());

            this.LoadByIdCommand = new Microsoft.Maui.Controls.Command<string>(async(string id) => {
                var entity = Base.ToString(id).Trim() == "" ? this.Db.GetNew() : await this.Db.Get(id);
                this.LoadByEntityCommand.Execute(entity);
            });

            this.LoadByEntityCommand = new Microsoft.Maui.Controls.Command<E>((E entity) => {
                this.Entity = entity;

                //this.EntityB = entity;
                //this.LoadAsyncCommand.Execute(null);
                /*
                this.Title2 = this.IsNew ? "Tambah Baru" : $"Edit - {this.Caption}";

                var isreadonly = false;
                if (this.PanelEnum == PanelEnum.Edit1 || this.PanelEnum == PanelEnum.Edit2) {
                    isreadonly = this.IsNew ? false : await this.Db.IsReadOnly(this.Id);
                }
                this.IsReadOnly = isreadonly;
                */
            });
        }
        protected virtual void OnInitEvent(E entity, PanelEnum panelenum) { }

        public virtual void OnSelect()
        {
            if (this.Select != null) this.Select(this);
        }
        public virtual void OnAction()
        {
            if (this.Action != null) this.Action(this);
        }
        public virtual void OnRefresh()
        {
            this.OnPropertyChanged("Entity");
        }

        private async void OnReadOnlyChanged()
        {
            return;
            var isreadonly = false;
            if (this.PanelEnum == PanelEnum.Edit1 || this.PanelEnum == PanelEnum.Edit2) {
                isreadonly = this.IsNew ? false : await this.Db.IsReadOnly(this.Id);
            }
            this.IsReadOnly = isreadonly;
        }
    }
}
