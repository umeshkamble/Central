

namespace Central.App.ViewModels
{
    public class ProductVM : PanelVM<Product>
    {
        #region Properties
        public override Product Entity
        {
            set {
                if (value is null) return;

                var entity = value;
                entity.SetLevelHrg(LevelHrgEnum.HrgApp);
                base.Entity = entity;

                this.Id_Kategori = entity.Id_Kategori;
                this.Id_Brand = entity.Id_Brand;
                this.Id_Suplier = entity.Id_Suplier;
                this.NoItem = entity.NoItem;
                this.Nama = entity.Nama;
                this.Deskripsi = entity.Deskripsi;

                this.Variants = entity.Variants;
                this.ProductVariants = entity.ProductVariants;
                this.ProductVariant = entity.ProductVariant;
                this.Rate = entity.Rate;
                this.IsPPN = entity.IsPPN;   
            }
            get {
                var entity = base.Entity;
                entity.Id_Kategori = this.Id_Kategori;
                entity.Id_Brand = this.Id_Brand;
                entity.Id_Suplier = this.Id_Suplier;
                entity.NoItem = this.NoItem;
                entity.Nama = this.Nama;
                entity.Deskripsi = this.Deskripsi;

                entity.Variants = this.Variants;
                entity.ProductVariants = this.ProductVariants;
                entity.IsPPN = this.IsPPN;
                return entity;
            }
        }

        public PageVariantEditV Page { get; set; }
        public PageVariantEditVM VM { get; set; }

        public RateVM RateVM { get; set; }
        public InputTextVM InputNoItemVM { get; set; }
        public InputTextVM InputNamaVM { get; set; }
        public InputSwitchVM InputSwitchPPNVM { get; set; }
        public InputPickerVM InputKategoriVM { get; set; }
        public InputPickerVM InputBrandVM { get; set; }
        public InputPickerVM InputSuplierVM { get; set; }
        public InputTextVM InputDeskripsiVM { get; set; }

        public MenuListVM VariantMenuListVM { get; set; }
        public VariantListVM VariantListVM { get; set; }
        public ProductVariantListVM ProductVariantListVM { get; set; }

        private string Id_Kategori_;
        public string Id_Kategori
        {
            set {
                Id_Kategori_ = value;
                try { this.InputKategoriVM.Id = Id_Kategori_; } catch { };
            }
            get { try { return this.InputKategoriVM.Id; } catch { return Id_Kategori_; } }
        }
 
        private string Id_Brand_;
        public string Id_Brand
        {
            set {
                Id_Brand_ = value;
                try { this.InputBrandVM.Id = Id_Brand_; } catch { };
            }
            get { try { return this.InputBrandVM.Id; } catch { return Id_Brand_; } }
        }

        private string Id_Suplier_;
        public string Id_Suplier
        {
            set
            {
                Id_Suplier_ = value;
                try { this.InputSuplierVM.Id = Id_Suplier_; } catch { };
            }
            get { try { return this.InputSuplierVM.Id; } catch { return Id_Suplier_; } }
        }

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

        private string NoItem_;
        public virtual string NoItem
        {
            set {
                NoItem_ = value;
                try { this.InputNoItemVM.Text = NoItem_; } catch { }
                this.OnPropertyChanged();
            }
            get { try { return this.InputNoItemVM.Text; } catch { return NoItem_; } }
        }

        private string Deskripsi_;
        public virtual string Deskripsi
        {
            set {
                Deskripsi_ = value;
                try { this.InputDeskripsiVM.Text = Deskripsi_; } catch { }
                this.OnPropertyChanged();
            }
            get { try { return this.InputDeskripsiVM.Text; } catch { return Deskripsi_; } }
        }

        private List<Variant> Variants_;
        public List<Variant> Variants
        {
            set {
                if (value is null) return;

                Variants_ = value;
                try { this.VariantListVM.InsertCommand.Execute(Variants_); } catch { }
            }
            get {
                try { return this.VariantListVM.Entitys; } catch { return Variants_; }
            }
        }

        private List<ProductVariant> ProductVariants_;
        public List<ProductVariant> ProductVariants
        {
            set {
                if (value is null) return;

                ProductVariants_ = value;
                try { this.ProductVariantListVM.InsertCommand.Execute(ProductVariants_); } 
                catch (Exception ex) { this.OnLog(ex); }
            }
            get {
                try { return this.ProductVariantListVM.Entitys; } catch { return ProductVariants_; }
            }
        }

        private ProductVariant ProductVariant_;
        public virtual ProductVariant ProductVariant
        {
            set { this.OnSetProperty(ref ProductVariant_, value); }
            get { return ProductVariant_; }
        }

        private Rate Rate_;
        public virtual Rate Rate
        {
            set {
                if (value is null) return;

                Rate_ = value;
                try { this.RateVM.LoadByEntityCommand.Execute(Rate_); } catch { }
                this.OnPropertyChanged();
            }
            get { try { return this.RateVM.Entity; } catch { return Rate_; } }
        }

        public string Kemasan { get; set; }
        public string KemasanDetail { get; set; }
        public bool IsService { get; set; }

        private bool IsPPN_;
        public bool IsPPN
        {
            set {
                IsPPN_ = value;
                try { this.InputSwitchPPNVM.IsOn = IsPPN_; } catch { }
                this.OnPropertyChanged();
            }
            get {
                try { return this.InputSwitchPPNVM.IsOn; } catch { return IsPPN_; }
            }
        }

        public override bool IsValid
        {
            get {
                try {
                    if (!this.InputNamaVM.IsValid) throw new Exception("");
                    else if (!this.InputNoItemVM.IsValid) throw new Exception("");
                    else if (!this.VariantListVM.IsValid) throw new Exception("");
                    else if (!this.ProductVariantListVM.IsValid) throw new Exception("");
                }
                catch (Exception ex) {
                    if (ex.Message != "") this.OnAlert(ex);
                    return false;
                }

                return base.IsValid;
            }
        }
        
        public override string Caption
        {
            get { return this.Nama; }
        }
        #endregion Properties

        private bool IsFirst { get; set; } = true;

        public ProductVM(PanelEnum panelenum) : base(null, panelenum, 1, null) { }
        public ProductVM(Product entity, PanelEnum panelenum, int no, ImageSource imagesource) : base(entity, panelenum, no, imagesource) { }
        
        protected override void OnInitInput(Product entity, PanelEnum panelenum)
        {
            base.OnInitInput(entity, panelenum);
            
            if (panelenum == PanelEnum.GridList || panelenum == PanelEnum.Info) {
                this.RateVM = new RateVM(PanelEnum.GridList);
            }
            else if (panelenum == PanelEnum.Edit1) {
                this.InputNoItemVM = new InputTextVM(new InputText("No. Item", "No. Item produk...","") { IsTitleCase = false });
                this.InputNamaVM = new InputTextVM(new InputText("Nama Produk", "Tuliskan nama lengkap produk...", "") { IsTitleCase = true });
                this.InputDeskripsiVM = new InputTextVM(new InputText("Deskripsi", "Deskripsikan merk ini...", "") { IsTitleCase = false });

                this.InputSwitchPPNVM = new InputSwitchVM(new InputSwitch("Barang PPN ?", "Tentukan status ppn utk produk ini.", "", IconFont.Percentage, true));
                this.InputKategoriVM = new InputPickerVM(new InputPicker("Kategori", "Pilih kategori", "", IconFont.Certificate), nameof(ProductCategory));
                this.InputBrandVM = new InputPickerVM(new InputPicker("Merk", "Pilih merk", "", IconFont.Heart), nameof(ProductBrand));
                this.InputSuplierVM = new InputPickerVM(new InputPicker("Suplier", "Pilih suplier", "", IconFont.User), nameof(Suplier));

                this.ProductVariantListVM = new ProductVariantListVM(new List<TemplateEnum> { TemplateEnum.Edit1 }, SelectionEnum.None, PanelEnum.Edit1);

                this.VariantMenuListVM = new MenuListVM(new List<TemplateEnum>() { TemplateEnum.T1 }, SelectionEnum.None);
                this.VariantMenuListVM.MenuSelectedChanged += this.OnMenuSelect;
                this.VariantMenuListVM.InsertCommand.Execute(new List<Menu> {
                    new Menu(MenuEnum.AddVariant,IconFont.Plus)
                });

                this.VariantListVM = new VariantListVM(new List<TemplateEnum> { TemplateEnum.Info }, SelectionEnum.None, PanelEnum.Info);
                this.VariantListVM.VariantEdit += ((vm) => {
                    //----panggil PageVariantEditV--------//
                    this.OnVariantEdit(vm.Entity);
                });
                this.VariantListVM.VariantDelete += (async (vm) => {
                    //----delete one variant--------------------//
                    await this.VariantListVM.OnDeleteAsync(vm);
                    this.OnVariantChanged();
                });
            }
        }

        private void OnVariantChanged()
        {
            //---jika terjadi penambahan,edit,dan hapus variant, maka perlu load ulang productvariants...//
            this.ProductVariantListVM.LoadByVariantCommand.Execute(this.Variants);
        }

        private async void OnVariantEdit(Variant variant)
        {
            if (this.VM is null) {
                this.VM = new PageVariantEditVM();
                this.VM.Saved += ((variant, isnew, saveenum) => {
                    if (isnew) this.VariantListVM.InsertOneCommand.Execute(variant);
                    else {
                        var id = variant.Id;
                        var vm = this.VariantListVM.OnGetItem(id);
                        if (vm != null) vm.Entity = variant;
                    }
                    this.OnVariantChanged();
                });
                this.Page = new PageVariantEditV(this.VM);
            }

            this.VM.Entity = variant;
            await Shell.Current.Navigation.PushAsync(this.Page);
        }

        public override void OnMenuSelect(MenuEnum menu)
        {
            switch (menu) {
                case MenuEnum.AddVariant: {
                        //----panggil PageVariantEditV--------//
                        this.OnVariantEdit(new Variant());
                        break; 
                    }
                default: base.OnMenuSelect(menu);break;
            }
        }

    }
}
