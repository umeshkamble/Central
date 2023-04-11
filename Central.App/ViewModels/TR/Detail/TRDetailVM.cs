using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Central.App.ViewModels
{
    public class TRDetailVM<D> : PanelVM<D>, ITRDetail where D : TRDetail
    {
        #region Properties
        public override D Entity
        {
            set {
                if (value is null) return;

                var entity = value;
                base.Entity = entity;

                this.IsRun = false;
                this.Id_Product = entity.Id_Product;
                this.Id_Variant = entity.Id_Variant;
                this.Id_Warehouse = entity.Id_Warehouse;
                this.No = entity.No;
                this.Nama = entity.Nama;
                this.Note = entity.Note;
                this.Qty = entity.Qty;
                this.Weight = entity.Weight;
                this.Dimension = entity.Dimension;
                this.VariantItems = entity.VariantItems;
                this.Rate = entity.Rate;
                this.DSum = entity.DSum;
                this.IsPPN = entity.IsPPN;
                this.IsViewDetail = true;
                this.IsRun = true;

                this.OnDetailChanged();
            }
            get {
                var entity = base.Entity;
                entity.Id_Product = this.Id_Product;
                entity.Id_Variant = this.Id_Variant;
                entity.Id_Warehouse = this.Id_Warehouse;
                entity.No = this.No;
                entity.Nama = this.Nama;
                entity.Note = this.Note;
                entity.Qty = this.Qty;
                entity.Weight = this.Weight;
                entity.Dimension = this.Dimension;
                entity.Rate = this.Rate;
                entity.DSum = this.DSum;
                entity.VariantItems = this.VariantItems;
                entity.IsPPN = this.IsPPN;
                return entity;
            }
        }

        private Product Product_;
        public Product Product
        {
            set {
                if (value is null) return;
                Product_ = value;

                this.Id_Product = Product_.Id;
                this.LevelHrg = Product_.GetLevelHrg();
            }
            get { return Product_; }
        }

        public ProductWarehouseListVM ProductWarehouseListVM { get; set; }
        public VariantGrupListVM VariantGrupListVM { get; set; }
        public RateListVM RateListVM { get; set; }
        public RateVM RateVM { get; set; }
        
        public MenuVM MenuMinVM { get; set; }
        public MenuVM MenuMaxVM { get; set; }
        public MenuVM MenuNoteVM { get; set; }
        public MenuVM MenuExpandVM { get; set; }

        public InputTextVM InputQtyVM { get; set; }
        public InputTextVM InputNoteVM { get; set; }

        private LevelHrgEnum LevelHrg { get; set; }

        public string Id_Product { get; set; }
        public string Id_Variant { get; set; }
        
        private string Id_Warehouse_;
        public string Id_Warehouse
        {
            set {
                Id_Warehouse_ = value;

                this.OnLoadWarehouse(Id_Warehouse_);
                try { this.ProductWarehouseListVM.OnSelect(Id_Warehouse_); } catch { }
            }
            get {
                try { return this.ProductWarehouseListVM.ItemSelectedFirst.Id; } catch { return Id_Warehouse_; }
            }
        }

        private string Nama_;
        public virtual string Nama
        {
            set { this.OnSetProperty(ref Nama_, value); }
            get { return Nama_; }
        }

        private Rate Rate_;
        public virtual Rate Rate
        {
            set {
                if (value is null) return;
                
                Rate_ = value;
                this.IsViewDiskon = Rate_.IsDiskon;
                
                try { this.RateListVM.Rate = Rate_; } catch { }
                try { this.RateVM.Entity = Rate_; } catch { }

                this.OnPropertyChanged();
                this.OnDetailChanged();
            }
            get {
                try { return this.RateVM.Entity; }
                catch { return Rate_; }
            }
        }

        private string Note_;
        public virtual string Note
        {
            set {
                Note_ = value;
                this.IsViewNote = Note_.Trim() == "" ? false : true;
                this.OnPropertyChanged();

                try { this.InputNoteVM.Text = Base.ToString(Note_); } catch { }
            }
            get {
                try { return this.InputNoteVM.Text; } catch { return Note_; }
            }
        }

        private double Qty_;
        public virtual double Qty
        {
            set {
                Qty_ = value;
                try { this.InputQtyVM.Text = Qty_.ToString(); } catch { }
                
                this.OnPropertyChanged();
                this.OnDetailChanged();
            }
            get {
                try { return Base.ToDouble(this.InputQtyVM.Text.Trim()); } catch { return Qty_; }
            }
        }

        private double Weight_;
        public virtual double Weight
        {
            set { this.OnSetProperty(ref Weight_, value); }
            get { return Weight_; }
        }

        public Dimension Dimension { get; set; }

        private DSum DSum_;
        public virtual DSum DSum
        {
            set { this.OnSetProperty(ref DSum_, value); }
            get { return DSum_; }
        }

        private List<string> VariantItems_;
        public List<string> VariantItems
        {
            set {
                if (value is null) return;
                VariantItems_ = value;

                var count = VariantItems_.Count;
                this.Variant = count > 1 ? Base.ToString(VariantItems_, ',') : "";
                this.IsViewVariant = count > 1 ? true : false;

                try { this.VariantGrupListVM.VariantItems = VariantItems_; } catch { }
            }
            get {
                try { return this.VariantGrupListVM.VariantItems; }
                catch { return VariantItems_; }
            }
        }

        private string Variant_;
        public virtual string Variant
        {
            set { this.OnSetProperty(ref Variant_, value); }
            get { return Variant_; }
        }

        private string Warehouse_;
        public virtual string Warehouse
        {
            set { this.OnSetProperty(ref Warehouse_, value); }
            get { return Warehouse_; }
        }

        private HSum HSum_;
        public HSum HSum
        {
            set {
                if (value is null) return;
                HSum_ = value;

                this.OnDetailChanged();
            }
            get { return HSum_; }
        }

        private double Stok_;
        public virtual double Stok
        {
            set { this.OnSetProperty(ref Stok_, value); }
            get { return Stok_; }
        }

        private bool IsPPN_;
        public bool IsPPN
        {
            set { this.OnSetProperty(ref IsPPN_, value); }
            get { return IsPPN_; }
        }

        private bool IsViewNote_;
        public bool IsViewNote
        {
            set { this.OnSetProperty(ref IsViewNote_, value); }
            get { return IsViewNote_; }
        }

        private bool IsViewNoteInput_;
        public bool IsViewNoteInput
        {
            set {
                IsViewNoteInput_ = value;
                try { if (IsViewNoteInput_) this.InputNoteVM.IsFocus = true; } catch { }
                this.IsViewNote = IsViewNoteInput_ ? false : (this.Note.Trim() == "" ? false : true);
                
                this.OnPropertyChanged();
            }
            get { return IsViewNoteInput_; }
        }

        private bool IsViewVariant_;
        public bool IsViewVariant
        {
            set { this.OnSetProperty(ref IsViewVariant_, value); }
            get { return IsViewVariant_; }
        }

        private bool IsViewDiskon_;
        public bool IsViewDiskon
        {
            set { this.OnSetProperty(ref IsViewDiskon_, value); }
            get { return IsViewDiskon_; }
        }

        private bool IsViewDetail_;
        public bool IsViewDetail
        {
            set {
                IsViewDetail_ = value;
                this.OnPropertyChanged();
            }
            get { return IsViewDetail_; }
        }

        private bool IsRun { get; set; } = true;

        public override string Caption
        {
            get { return this.Nama; }
        }
        #endregion Properties

        
        #region Event
        public delegate void TRDetailEventHandler();
        public event TRDetailEventHandler DetailChanged;
        #endregion Event    

        public TRDetailVM(D entity, PanelEnum panelenum, int no, ImageSource imagesource) : base(entity, panelenum, no, imagesource) { }
        protected override void OnInitInput(D entity, PanelEnum panelenum)
        {
            base.OnInitInput(entity, panelenum);
            if (panelenum == PanelEnum.Edit1 || panelenum == PanelEnum.Edit2) {
                this.InputQtyVM = new InputTextVM(new InputText("","", "Qty", "", TextEnum.NumberDecimal));
                this.InputNoteVM = new InputTextVM(new InputText("", "Catatan...", "","", TextEnum.Text) { IsTitleCase = false });
                this.MenuMinVM = new MenuVM(new Menu(MenuEnum.Min, IconFont.Minus));
                this.MenuMaxVM = new MenuVM(new Menu(MenuEnum.Max, IconFont.Plus));
                this.MenuNoteVM = new MenuVM(new Menu(MenuEnum.Note, IconFont.Pen));
                this.MenuExpandVM = new MenuVM(new Menu(MenuEnum.ExpandBottom, IconFont.ArrowDown));
                this.RateVM = new RateVM(PanelEnum.GridList);

                if (panelenum == PanelEnum.Edit2) {
                    //-----utk tampilan PageTRDetailVM------------//
                    this.RateListVM = new RateListVM(new List<TemplateEnum> { TemplateEnum.Grid }, SelectionEnum.Single, PanelEnum.GridList, true) { Title1 = "Harga" };
                    this.RateListVM.LoadFinished += (() => {
                        this.RateListVM.OnSelect((int)this.LevelHrg);
                    });
                    this.RateListVM.SelectedChanged += ((item) => {
                        //------Jika Rate Custom terpilih, panggil PageRateEditV-------------//
                        if (item.RateMode == RateModeEnum.Custom) item.EditRateCommand.Execute(null);
                        this.Rate = item.Entity;
                    });
                    this.RateListVM.RateChanged += ((rate) => {
                        //------Jika Rate Custom berubah, maka update nilai Rate------------//
                        this.Rate = rate;
                    });
                   
                    this.VariantGrupListVM = new VariantGrupListVM(SelectionEnum.Single) { Title1 = "Varian" };
                    this.VariantGrupListVM.SelectedChanged += (async (item) => {
                        //--------mengambil variantitems yang terpilih---------------//
                        var variantitems = this.VariantGrupListVM.VariantItems;

                        //--------mencari productvariant dari variant yg terpilih----//
                        var db1 = (ProductVariantService)Base.GetDb(nameof(ProductVariant));
                        var productvariants = this.Product.ProductVariants;
                        var pv = await db1.FindAsync(variantitems, productvariants);

                        //--------mencari rates dari productvariant yg terpilih-------//
                        var db2 = (RateService)Base.GetDb(nameof(Rate));
                        var rates = db2.GetRates(pv, false);
                        this.RateListVM.InsertCommand.Execute(rates);

                        this.Id_Variant = pv.Id;
                        this.Stok = Base.ToDouble(Base.GetRandom(3));
                    });

                    this.ProductWarehouseListVM = new ProductWarehouseListVM(new List<TemplateEnum> { TemplateEnum.Grid }, SelectionEnum.Single, PanelEnum.GridList, false) { Title1 = "Gudang" };
                    this.ProductWarehouseListVM.LoadCommand.Execute(null);
                }
            }
        }

        
        protected override void OnInitEvent(D entity,PanelEnum panelenum)
        {
            base.OnInitEvent(entity,panelenum);
            if (panelenum == PanelEnum.Edit1 || panelenum == PanelEnum.Edit2) {
                //-----utk tampilan TRVM & PageTRDetailVM----------------------//
                this.InputQtyVM.TextChanged += ((vm) => this.Qty = this.Qty);
                this.InputNoteVM.TextChanged += ((vm) => this.Note = this.Note);
                this.InputNoteVM.Leave += ((vm) => this.IsViewNoteInput = false);

                this.MenuMinVM.MenuSelectedChanged += this.OnMenuSelect;
                this.MenuMaxVM.MenuSelectedChanged += this.OnMenuSelect;
                this.MenuNoteVM.MenuSelectedChanged += this.OnMenuSelect;
                this.MenuExpandVM.MenuSelectedChanged += this.OnMenuSelect;
            }
        }

        public override void OnSelect()
        {
            var isselected = this.IsSelected;
            base.OnSelect();

            //----cek apakah sebelumnya sudah terselect ? jika ya baru jalankan expand detail----//
            if (isselected) this.IsViewDetail = !this.IsViewDetail;
        }

        public override void OnMenuSelect(MenuEnum menu)
        {
            switch (menu){
                case MenuEnum.Min: {
                        this.Qty--;
                        break;
                    }
                case MenuEnum.Max: {
                        this.Qty++;
                        break;
                    }
                case MenuEnum.Note: {
                        this.IsViewNoteInput = true;
                        break;
                    }
                default: base.OnMenuSelect(menu);break;
            }
        }

        private void OnDetailChanged()
        {
            if (this.PanelEnum == PanelEnum.GridList) return;
            if (!this.IsRun) return;
                
            try {
                this.IsRun = false;
                var db = (SumService)Base.GetDb(nameof(DSum));
                this.DSum = db.GetDSum(this.Qty, this.Rate, this.Weight, this.Dimension, this.HSum, this.IsPPN);
                if (this.DetailChanged != null) this.DetailChanged();
            }
            catch { }
            this.IsRun = true;
        }

        private async void OnLoadWarehouse(string id_warehouse)
        {
            var db = (ProductWarehouseService)Base.GetDb(nameof(ProductWarehouse), this.DbName);
            var r = await db.Get(id_warehouse);
            this.Warehouse = r is null ? "-" : r.Nama;
        }


        public async Task OnLoadAsync(Product p, HSum hsum, D entity, bool isnew)
        {
            this.Product = p;
            await this.VariantGrupListVM.OnLoadByProductAsync(p);
            
            this.HSum = hsum;
            this.Entity = entity;
            this.IsNew = isnew;
        }


    }
}
