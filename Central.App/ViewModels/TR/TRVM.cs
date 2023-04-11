using Central.Library;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Serializers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Contact = Central.Library.Contact;

namespace Central.App.ViewModels
{
    public class TRVM<H, DVMList, DVM, D, C> : PanelVM<H>, ITR<D> where DVMList : TRDetailListVM<DVM,D>
                                                                  where DVM : TRDetailVM<D>
                                                                  where H : TR<D>
                                                                  where D : TRDetail
                                                                  where C : Contact

    {
        #region Properties
        public override H Entity 
        {
            set {
                if (value is null) return;
                var entity = value;
                base.Entity = entity;

                this.Id_Client = entity.Id_Client;
                this.NamaClient = entity.NamaClient;
                this.NamaOperator = entity.NamaOperator;
                this.BillTo = entity.BillTo;
                this.ShipTo = entity.ShipTo;
                this.Phone = entity.Phone;
                this.Tgl = entity.Tgl;
                this.TglJT = entity.TglJT;
                this.NoFaktur = entity.NoFaktur;
                this.NoReferensi = entity.NoReferensi;
                this.NoFP = entity.NoFP;
                this.Deskripsi = entity.Deskripsi;
                this.TotalTransaksi = entity.TotalTransaksi;
                this.TotalSetor = entity.TotalSetor;
                this.TotalBalance = entity.TotalBalance;
                this.HSum = entity.HSum;
                this.Details = entity.Details;

                try { this.HSumVM.OnHSumChanged(); } catch { }
            }
            get {
                var entity = base.Entity;
                entity.Id_Client = this.Id_Client;
                entity.NamaClient = this.NamaClient;
                entity.NamaOperator = this.NamaOperator;
                entity.BillTo = this.BillTo;
                entity.ShipTo = this.ShipTo;
                entity.Phone = this.Phone;
                entity.Tgl = this.Tgl;
                entity.TglJT = this.TglJT;
                entity.NoFaktur = this.NoFaktur;
                entity.NoReferensi = this.NoReferensi;
                entity.NoFP = this.NoFP;
                entity.Deskripsi = this.Deskripsi;
                entity.TotalTransaksi = this.TotalTransaksi;
                entity.TotalSetor = this.TotalSetor;
                entity.TotalBalance = this.TotalBalance;
                entity.HSum = this.HSum;
                entity.Details = this.Details;
                return entity;
            }
        }
        private PageTRDetailEditV Page { get; set; }
        private PageTRDetailEditVM<DVM,D> VM { get; set; }

        public MenuListVM DetailMenuListVM { get; set; }
        public DVMList DetailListVM { get; set; }
        public InputPickerVM InputClientVM { get; set; }
        public AddressVM BillToVM { get; set; }
        public AddressVM ShipToVM { get; set; }
        public PhoneVM PhoneVM { get; set; }
        public HSumVM HSumVM { get; set; }
        
        private string Id_Client_;
        public virtual string Id_Client 
        {
            set {
                var id = Base.ToString(value);
                Id_Client_ = id;

                try { 
                    this.InputClientVM.Id = id;
                    this.OnClientChanged(id);
                } catch { }
            }
            get {
                try { return this.InputClientVM.Id; } catch { return Id_Client_; }
            }
        }

        private Address BillTo_;
        public virtual Address BillTo 
        {
            set {
                if (value is null) return;

                BillTo_ = value;
                try { this.BillToVM.Entity = BillTo_; } catch { }
            }
            get {
                try { return this.BillToVM.Entity; } catch { return BillTo_; }
            }
        }

        private Address ShipTo_;
        public virtual Address ShipTo 
        {
            set {
                if (value is null) return;
                
                ShipTo_ = value;
                try { this.ShipToVM.Entity = ShipTo_; } catch { }
            }
            get {
                try { return this.ShipToVM.Entity; } catch { return ShipTo_; }
            }
        }

        private Phone Phone_;
        public virtual Phone Phone
        {
            set {
                if (value is null) return;
                
                Phone_ = value;
                try { this.PhoneVM.Entity = Phone_; } catch { }
            }
            get {
                try { return this.PhoneVM.Entity; } catch { return Phone_; }
            }
        }

        private List<D> Details_;
        public virtual List<D> Details
        {
            set {
                if (value is null) return;

                Details_ = value;
                try { this.DetailListVM.InsertCommand.Execute(Details_); } catch { }
            }
            get {
                try { return this.DetailListVM.Entitys; } catch { return Details_; }
            }
        }

        private HSum HSum_;
        public HSum HSum
        {
            set {
                if (value is null) return;

                HSum_ = value;
                try { this.HSumVM.Entity = HSum_; } catch { }
            }
            get {
                try { return this.HSumVM.Entity; } catch { return HSum_; }
            }
        }

        public virtual string NamaClient { get; set; }
        public virtual string NamaOperator { get; set; }
        public virtual DateTime Tgl { get; set; }
        public virtual DateTime TglJT { get; set; }

        private string NoFaktur_;
        public virtual string NoFaktur
        {
            set { this.OnSetProperty(ref NoFaktur_, value); }
            get { return NoFaktur_; }
        }

        public virtual string NoReferensi { get; set; }
        public virtual string NoFP { get; set; }
        public string Deskripsi { get; set; }

        private double TotalTransaksi_;
        public virtual double TotalTransaksi
        {
            set { this.OnSetProperty(ref TotalTransaksi_, value); }
            get { return TotalTransaksi_; }
        }

        private double TotalSetor_;
        public virtual double TotalSetor
        {
            set { this.OnSetProperty(ref TotalSetor_, value); }
            get { return TotalSetor_; }
        }

        private double TotalBalance_;
        public virtual double TotalBalance
        {
            set { this.OnSetProperty(ref TotalBalance_, value); }
            get { return TotalBalance_; }
        }

        protected string ContactEntityName
        {
            get { return typeof(C).Name; }
        }

        protected DVM DetailVM
        {
            get { return this.DetailListVM.ItemSelectedFirst; }
        }

        private bool IsRun { get; set; } = true;
        public override string Caption => this.NoFaktur;
        #endregion Properties

        #region Command
        public Command AddCommand { get; set; }
        #endregion Command

        #region Event
        public delegate void HSumEventHandler(HSum hsum);
        public event HSumEventHandler HSumChanged;

        public delegate void DetailEventHandler(DVM dvm);
        public event DetailEventHandler Add,Edit,Delete;
        #endregion Event  

        public TRVM(H entity, PanelEnum panelenum, int no, ImageSource imagesource) : base(entity,panelenum, no, imagesource) { }
        protected override void OnInitInput(H entity,PanelEnum panelenum)
        {
            base.OnInitInput(entity, panelenum);

            if (panelenum == PanelEnum.Edit1) {
                this.DetailMenuListVM = new MenuListVM(new List<TemplateEnum> { TemplateEnum.T1 }, SelectionEnum.None);
                this.DetailMenuListVM.MenuSelectedChanged += this.OnMenuSelect;
                this.DetailMenuListVM.InsertCommand.Execute(new List<Menu> {
                    new Menu(MenuEnum.Add, IconFont.Plus),
                    new Menu(MenuEnum.Edit, IconFont.Pen),
                    new Menu(MenuEnum.Delete, IconFont.Trash)
                });

                this.HSumVM = new HSumVM(PanelEnum.GridList);
                this.DetailListVM = this.OnGetDetailListVM(panelenum);
                
                this.BillToVM = new AddressVM(PanelEnum.GridList) { Title1 = "Tagih Ke : " };
                this.ShipToVM = new AddressVM(PanelEnum.GridList) { Title1 = "Kirim Ke : " };
                this.PhoneVM = new PhoneVM(PanelEnum.GridList);
                
                var contactentityname = this.ContactEntityName;
                this.InputClientVM = new InputPickerVM(new InputPicker(contactentityname, $"Pilih {contactentityname}", IconFont.AddressBook) { IsViewLine = false }, contactentityname);
            }
        }

        protected override void OnInitEvent(H entity, PanelEnum panelenum)
        {
            base.OnInitEvent(entity,panelenum);

            if (panelenum == PanelEnum.Edit1) {
                this.InputClientVM.IdChanged += ((id) => this.Id_Client = id);

                this.AddCommand = new Microsoft.Maui.Controls.Command<D>((D d) => {
                    this.DetailListVM.InsertByDetailCommand.Execute(d);
                }); 
               
                this.DetailListVM.LoadFinished += (() => this.DetailListVM.OnSelectLast());
                this.DetailListVM.DetailChanged += (() => {
                    var details = this.Details;
                    var idetails = new List<ITRDetail>();
                    foreach (var d in details) {
                        var idetail = (ITRDetail)d;
                        idetails.Add(idetail);
                    }

                    this.HSumVM.LoadByDetailsCommand.Execute(idetails);
                });

                this.HSumVM.HSumChanged += ((hsum) => {
                    this.DetailListVM.HSum = hsum;
                    if (this.HSumChanged != null) this.HSumChanged(hsum);
                });
            }
        }

        public async Task OnEditAsync(string id_product, D detail, bool isnew)
        {
            var hsum = this.HSum;
            var db = (ProductService)Base.GetDb(nameof(Product), this.DbName);
            var p = await db.Get(id_product);
            
            await this.OnEditAsync(p, hsum, detail, isnew);
        }

        protected virtual async Task OnEditAsync(Product p, HSum hsum, D detail, bool isnew)
        {
            if (this.VM is null) {
                //----------utk PageDetailV----------------------------------------//
                this.VM = this.OnGetPageEditVM();
                this.VM.Saved += ((detail, isnew, saveenum) => {
                    if (isnew) this.DetailListVM.InsertOneCommand.Execute(detail);
                    else{
                        var dvm = this.DetailListVM.ItemSelectedFirst;
                        dvm.Entity = detail;
                    }
                    this.DetailListVM.OnDetailChanged();
                });
                this.Page = this.OnGetPageEditV();
                this.Page.BindingContext = this.VM;
            }

            await this.VM.OnLoadAsync(p, hsum, detail, isnew);
            await Shell.Current.Navigation.PushAsync(this.Page);
        }

        public async Task OnDeleteAsync(DVM dvm)
        {
            await this.DetailListVM.OnDeleteAsync(dvm);
        }

        protected virtual PageTRDetailEditV OnGetPageEditV()
        {
            return null;
        }

        protected virtual PageTRDetailEditVM<DVM, D> OnGetPageEditVM()
        {
            return null;
        }

        protected virtual DVMList OnGetDetailListVM(PanelEnum panelenum)
        {
            return null;
        }

        protected virtual async void OnClientChanged(string id) 
        {
            //---hanya akan di jalankan jika di panggil-----------//
            if (!this.IsRun) return;

            this.IsRun = false;
            var nama = "";
            var address = new Address();
            var phone = new Phone();
            
            var dbname = this.DbName;
            var contactentityname = this.ContactEntityName;
            var db = (ContactService<C>)Base.GetDb(contactentityname, dbname);
            var r = await db.Get(id);
            if (r != null) {
                nama = r.Nama;
                address = r.AddressDef;
                phone = r.PhoneDef;
            }

            this.Id_Client = id;
            this.NamaClient = nama;
            this.BillTo = this.ShipTo = address;
            this.Phone = phone;
            this.IsRun = true;
        }

        public override void OnMenuSelect(MenuEnum menu)
        {
            switch (menu) {
                case MenuEnum.Add: {
                        if (this.Add != null) this.Add(null);
                        break;
                    }
                case MenuEnum.Edit: {
                        if (this.Edit != null) this.Edit(this.DetailVM);
                        break;
                    }
                case MenuEnum.Delete: {
                        if (this.Delete != null) this.Delete(this.DetailVM);
                        break;
                    }
                default: base.OnMenuSelect(menu);break;
            }
        }

    }
}
