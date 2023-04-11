using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Threading.Tasks.Sources;

namespace Central.App.ViewModels
{
    public static class TaskExtensions
    {
        private static readonly Dictionary<WeakReference<Task>, object> TaskNames = new Dictionary<WeakReference<Task>, object>();

        public static void Tag(this Task pTask, object pTag)
        {
            if (pTask == null) return;
            var weakReference = ContainsTask(pTask);
            if (weakReference == null) {
                weakReference = new WeakReference<Task>(pTask);
            }
            TaskNames[weakReference] = pTag;
        }

        public static object Tag(this Task pTask)
        {
            var weakReference = ContainsTask(pTask);
            if (weakReference == null) return null;
            return TaskNames[weakReference];
        }

        private static WeakReference<Task> ContainsTask(Task pTask)
        {
            foreach (var kvp in TaskNames.ToList()) {
                var weakReference = kvp.Key;

                Task taskFromReference;
                if (!weakReference.TryGetTarget(out taskFromReference)) {
                    TaskNames.Remove(weakReference); //Keep the dictionary clean.
                    continue;
                }

                if (pTask == taskFromReference) {
                    return weakReference;
                }
            }
            return null;
        }
    }

    public class Param<E> where E : EntityBase
    { 
        public Dictionary<string, object> Parameters { get; set; }

        public Param() : this(null, null) { }
        public Param(E entity) : this(null, null, null, entity) { }
        public Param(PageMasterParam1 pagemasterparam1) : this(pagemasterparam1, null) { }
        public Param(PageMasterParam1 pagemasterparam1, PageMasterParam2 pagemasterparam2) : this(pagemasterparam1, pagemasterparam2, null) { }
        public Param(PageMasterParam1 pagemasterparam1, PageMasterParam2 pagemasterparam2, PageEditParam pageeditparam) : this(pagemasterparam1, pagemasterparam2, pageeditparam, null) { }
        public Param(PageMasterParam1 pagemasterparam1, PageMasterParam2 pagemasterparam2, PageEditParam pageeditparam, E entity)
        {
            this.Parameters = new Dictionary<string, object> {
                [nameof(PageMasterParam1)] = pagemasterparam1,
                [nameof(PageMasterParam2)] = pagemasterparam2,
                [nameof(PageEditParam)] = pageeditparam,
                ["Entity"] = entity
            };
        }
    }

    public interface IBaseVM<E> where E : EntityBase
    {
        E Entity { get; set; }
        Service<E> Db { get; }
        string Id { get; set; }
        string Title1 { get; set; }
        string Title2 { get; set; }

        bool IsBusy { get; set; }
        bool IsNotBusy { get; }

        Task OnGoBackAsync();
        Task OnGotoAsync(string pagename);
        Task OnGotoAsync(string pagename, E entity);
        Task OnGotoAsync(string pagename, Param<E> param);

        Command LoadAsyncCommand { get; set; }
        Command BackCommand { get; set; }
    }

    [QueryProperty("Entity", "Entity")]
    public class BaseVM<E> : IBaseVM<E>, INotifyPropertyChanged where E : EntityBase
    {
        #region Properties
        public Service<E> Db { get; set; }

        protected E EntityB { get; set; }

        private E Entity_ = null;
        public virtual E Entity
        {
            set {
                if (value is null) return;

                Entity_ = value;
                this.Id = Entity_.Id;
            }
            get {
                var id = Base.ToString(this.Id).Trim();
                var entity = Entity_;
                entity.Id = id == "" ? null : id;
                return entity;
            }
        }

        private string Id_;
        public virtual string Id
        {
            set {
                if (Id_ == value) return;

                Id_ = Base.ToString(value).Trim();
                this.OnIdChanged();
            }
            get { return Id_; }
        }

        private string Title1_ = "";
        public virtual string Title1
        {
            set {
                Title1_ = value;
                this.OnPropertyChanged();
                this.OnTitleChanged();
            }
            get { return Title1_; }
        }

        private string Title2_ = "";
        public virtual string Title2
        {
            set {
                Title2_ = value;
                this.OnPropertyChanged();
                this.OnTitleChanged();
            }
            get { return Title2_; }
        }

        public bool IsViewTitle1
        {
            get { return this.Title1.Trim() == "" ? false : true; }
        }
        public bool IsViewTitle2
        {
            get { return this.Title2.Trim() == "" ? false : true; }
        }

        protected string BaseName { get; set; }
        protected string EntityName { get; set; }
        protected string DbName { get; set; }
        private bool IsFirstLoad { get; set; }
        public bool IsNotBusy => !this.IsBusy;

        private bool IsBusy_ = false;
        public virtual bool IsBusy
        {
            set { this.OnSetProperty(ref IsBusy_, value); }
            get { return IsBusy_; }
        }

        public bool IsAppShell1
        {
            get { return App.Current.MainPage is AppShell1 ? true : false; }
        }


        public bool IsDevicePhone
        {
            get {
                if (DeviceInfo.Current.Idiom == DeviceIdiom.Phone) return true;
                return false;
            }
        }

        public bool IsDevicePhoneOrTablet
        {
            get {
                if (DeviceInfo.Current.Idiom == DeviceIdiom.Phone || DeviceInfo.Current.Idiom == DeviceIdiom.Tablet) return true;
                return false;
            }
        }

        public bool IsDeviceDesktop
        {
            get {
                if (DeviceInfo.Current.Idiom == DeviceIdiom.Desktop) return true;
                return false;
            }
        }

        public virtual bool IsValid
        {
            get { return true; }
        }
        #endregion Properties

        #region Event
        public event PropertyChangedEventHandler PropertyChanged;
        public delegate void EventHandler(BaseVM<E> vm);

        public delegate void MenuEventHandler(MenuEnum menu);
        public event MenuEventHandler MenuSelectedChanged;

        public delegate void IdEventHandler(string id);
        public event IdEventHandler IdChanged;

        public delegate void TitleEventHandler(string title1, string title2);
        public event TitleEventHandler TitleChanged;

        public delegate void LoadEventHandler();
        public event LoadEventHandler LoadBegin, LoadFinished;
        #endregion Event  

        #region Command
        public Command LoadAsyncCommand { get; set; }
        public Command BackCommand { get; set; }
        #endregion Command  

        public BaseVM()
        {
            this.IsFirstLoad = true;
            this.BaseName = this.GetType().Name;
            this.EntityName = typeof(E).Name;
            this.DbName = this.IsAppShell1 ? "" : AppShell2.DbName;

            try {
                var entityname = this.EntityName.ToLower();
                if (entityname.Contains("menu") || entityname.Contains("input") || entityname == "pin" || entityname == "variant" || entityname == "phone" || entityname == "address") throw new Exception();
                this.Db = (Service<E>)Base.GetDb(this.EntityName, this.DbName);
            }
            catch {
                this.Db = null;
            }

            this.BackCommand = new Command(async () => await this.OnGoBackAsync());
            this.LoadAsyncCommand = new Microsoft.Maui.Controls.Command<List<Task>>(async (List<Task> tasks) => {
                if (tasks is null) await this.OnLoadAsync();
                else await this.OnLoadAsync(tasks);
            });
        }

        public virtual async Task OnLoadAsync()
        {
            await this.OnLoadAsync(new List<Task>());
        }
        public virtual async Task OnLoadAsync(List<Task> tasks)
        {
            try {
                await this.OnLoadBeginAsync();

                //-----------tasks for custom------------------------------//
                if (tasks.Count > 0) {
                    //await this.OnLogTasks(tasks, "TaskGeneral"); 
                    await Task.WhenAll(tasks);
                }

                //-----------tasks for firstload---------------------------//
                if (this.IsFirstLoad) {
                    this.IsFirstLoad = false;
                    var tasks1 = await this.OnLoadFirstAsync(new List<Task>());
                    if (tasks1.Count > 0) {
                        //await this.OnLogTasks(tasks1,"TaskFirst"); 
                        await Task.WhenAll(tasks1);
                    }
                }

                //-----------tasks for binding entity---------------------//
                if (this.EntityB != null) {
                    var tasks2 = new List<Task> { this.OnLoadEntityAsync() };
                    await Task.WhenAll(tasks2);
                    
                    //await this.OnLogTasks(tasks2,"TaskEntity");
                    this.EntityB = null;
                }

                await this.OnLoadFinishedAsync();
            }
            catch (Exception ex) {
                this.OnLog(ex);
            }
        }
        private async Task OnLogTasks(List<Task> tasks, string taskname) 
        {
            foreach (var t in tasks) {
                this.OnLog($"{taskname}=====>{t.Tag()}");
            }
            await Task.FromResult(true);
        }
        
        protected virtual async Task<List<Task>> OnLoadFirstAsync(List<Task> tasks)
        {
            return await Task.FromResult(tasks);
        }
        protected virtual async Task OnLoadBeginAsync()
        {
            //this.OnLog("OnLoadBeginAsync");
            
            this.IsBusy = true;
            if (this.LoadBegin != null) this.LoadBegin();
            await Task.FromResult(true);
        }
        protected virtual async Task OnLoadFinishedAsync()
        {
            //this.OnLog("OnLoadFinishedAsync");

            this.IsBusy = false;
            if (this.LoadFinished != null) this.LoadFinished();
            await Task.FromResult(true);
        }

        private async Task<bool> OnLoadEntityAsync()
        {
            this.Entity = this.EntityB;
            return await Task.FromResult(true);
        }

        public virtual async Task OnGoBackAsync()
        {
            await this.OnGoBackAsync(new Param<E>());
        }
        public virtual async Task OnGoBackAsync(Param<E> param)
        {
            await this.OnGotoAsync("..", param);
        }
        public virtual async Task OnGotoAsync(string pagename)
        {
            await this.OnGotoAsync(pagename, new Param<E>());
        }
        public virtual async Task OnGotoAsync(string pagename, E entity)
        {
            //---masih salah waktu ada pengiriman parameter Entity, tdk ter-eksekusi--//
            await this.OnGotoAsync(pagename, new Param<E>(entity));
        }
        public virtual async Task OnGotoAsync(string pagename, Param<E> param)
        {
            await Shell.Current.GoToAsync(pagename, true, param.Parameters);
        }

        public void OnAlert(Exception ex)
        {
            this.OnAlert(ex.Message);
        }
        public void OnAlert(string msg)
        {
            this.OnAlert(msg, "Informasi", "OK");
        }
        public async void OnAlert(string msg, string title, string btn)
        {
            if (msg.Trim() == "") return;
            await Application.Current.MainPage.DisplayAlert(title, msg, btn);
        }
        public async Task<bool> OnAlert(string msg, string title, string btn1, string btn2)
        {
            return await Application.Current.MainPage.DisplayAlert(title, msg, btn1, btn2);
        }

        public void OnLog(Exception ex)
        {
            var msg = $"Error.{ex.Message}";
            this.OnLog(msg);
        }
        public void OnLog(string msg)
        {
            msg = $"{this.BaseName}.{msg}";
            Debug.WriteLine($"Info => {msg}");
        }
        
        public virtual void OnMenuSelect(MenuEnum menu)
        {
            if (this.MenuSelectedChanged != null) this.MenuSelectedChanged(menu);
        }
        private void OnTitleChanged()
        {
            if (this.TitleChanged != null) this.TitleChanged(this.Title1, this.Title2);
        }
        protected virtual void OnIdChanged()
        {
            if (this.IdChanged != null) this.IdChanged(this.Id);
        }
        public void OnSetTitle(string title)
        {
            this.OnSetTitle(title, "");
        }
        public void OnSetTitle(string title1, string title2)
        {
            this.Title1 = title1;
            this.Title2 = title2;
        }
        protected bool OnSetProperty<T>(ref T backingStore, T value, [CallerMemberName] string propertyName = "", Action onChanged = null)
        {
            if (EqualityComparer<T>.Default.Equals(backingStore, value)) return false;

            backingStore = value;
            onChanged?.Invoke();
            this.OnPropertyChanged(propertyName);
            return true;
        }
        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        protected async Task<Account> OnLoginAsync(string emailphone, string password, string id_account)
        {
            try {
                var db = (AccountService)Base.GetDb(nameof(Account));
                var account = await db.Login(emailphone, password, id_account);
                if (account is null) throw new Exception("Login gagal !");

                //---------GoTo Marketplace---------------------------------------------------------------//
                if (Preferences.ContainsKey(nameof(Base.Account))) Preferences.Remove(nameof(Base.Account));
                var text = JsonConvert.SerializeObject(account);
                Preferences.Set(nameof(Base.Account), text);
                Base.Account = account;

                var param = new Param<E>(new PageMasterParam1("Store", Base.Account.Nama, false, SelectionEnum.None));
                await this.OnGotoAsync($"//{nameof(PageStoreV)}_", param);
                return Base.Account;
            }
            catch (Exception ex) {
                this.OnAlert(ex);
                return null;
            }
        }
        protected async Task OnLogoutAsync()
        {
            if (Preferences.ContainsKey(nameof(Base.Account))) Preferences.Remove(nameof(Base.Account));
            Base.Logout();

            await this.OnGotoAsync($"//{nameof(PageLoginV)}_");
        }
    }
}
