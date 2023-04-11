

namespace Central.App.ViewModels
{
    public class ProductWarehouseVM : PanelVM<ProductWarehouse>
    {
        #region Properties
        public override ProductWarehouse Entity
        {
            set {
                if (value is null) return;
                var entity = value;
                base.Entity = entity;
           
                this.Nama = entity.Nama;
                this.Deskripsi = entity.Deskripsi;
                
                this.OnGetTotalItem();
            }
            get {
                var entity = base.Entity;
                entity.Nama = this.Nama;
                entity.Deskripsi = this.Deskripsi;
                return entity;
            }
        }

        public InputTextVM InputNamaVM { get; set; }
        public InputTextVM InputDeskripsiVM { get; set; }

        private string Nama_;
        public virtual string Nama
        {
            set {
                Nama_ = value;
                try { this.InputNamaVM.Text = Nama_; } catch { }
                this.OnPropertyChanged();
            }
            get { try { return this.InputNamaVM.Text; } catch { return Nama_; } }
        }

        private string Deskripsi_;
        public virtual string Deskripsi
        {
            set {
                Deskripsi_ = value;
                try { this.InputDeskripsiVM.Text = Deskripsi_; } catch { }
                this.OnPropertyChanged();
            }
            get { 
                try { return this.InputDeskripsiVM.Text; } catch { return Deskripsi_; } }
        }

        private int TotalItem_;
        public virtual int TotalItem
        {
            set { this.OnSetProperty(ref TotalItem_, value); }
            get { return TotalItem_; }
        }

        public override bool IsValid 
        {
            get {
                try {
                    if (!this.InputNamaVM.IsValid) throw new Exception("");
                }
                catch (Exception ex) {
                    if (ex.Message != "") this.OnAlert(ex);
                    return false;
                }
               
                return base.IsValid;
            }    
        }

        public override string Caption => this.Nama;
        #endregion Properties

        public ProductWarehouseVM(PanelEnum panelenum) : this(null, panelenum, 1, null) { }
        public ProductWarehouseVM(ProductWarehouse entity, PanelEnum panelenum, int no, ImageSource imagesource) : base(entity, panelenum, no, imagesource) { }
        
        protected override void OnInitInput(ProductWarehouse entity, PanelEnum panelenum)
        {
            base.OnInitInput(entity, panelenum);
            if (panelenum == PanelEnum.Edit1) {
                this.InputNamaVM = new InputTextVM(new InputText("Nama Gudang","", "Cth : Gdg.1, Gdg.2 dll..") { IsTitleCase = true });
                this.InputDeskripsiVM = new InputTextVM(new InputText("Deskripsi", "", "Deskripsikan gudang ini...") { IsTitleCase = false });
            }
        }

        private void OnGetTotalItem()
        {
            var db = ((ProductWarehouseService)Base.GetDb(nameof(ProductWarehouse), this.DbName));
            this.TotalItem = 0;
            //this.TotalItem = await db.GetSaldoByReferensi(this.Id);
        }
    }
}
