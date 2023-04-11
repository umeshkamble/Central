

namespace Central.App.ViewModels
{
    public class AddressVM : PanelVM<Address>
    {
        #region Properties
        public override Address Entity 
        {
            set {
                if (value is null) return;
                var entity = value;
                base.Entity = entity;

                this.Alamat = entity.Alamat;
                this.Kelurahan = entity.Kelurahan;
                this.Kecamatan = entity.Kecamatan;
                this.Kota = entity.Kota;
                this.Provinsi = entity.Provinsi;
                this.KodePos = entity.KodePos;
            }
            get {
                var entity = base.Entity;
                entity.Alamat = this.Alamat;
                entity.Kelurahan = this.Kelurahan;
                entity.Kecamatan = this.Kecamatan;
                entity.Kota = this.Kota;
                entity.Provinsi = this.Provinsi;
                entity.KodePos = this.KodePos;
                return entity;
            }
        }

        public InputTextVM InputAlamatVM { get; set; }
        public InputTextVM InputKelurahanVM { get; set; }
        public InputTextVM InputKecamatanVM { get; set; }
        public InputTextVM InputKotaVM { get; set; }
        public InputTextVM InputProvinsiVM { get; set; }
        public InputTextVM InputKodePosVM { get; set; }

        private string Alamat_;
        public string Alamat
        {
            set {
                Alamat_ = value;
                this.InputAlamatVM.Text = Alamat_;
                try { this.InputAlamatVM.Text = Alamat_; } catch { }
                this.OnPropertyChanged();
            }
            get { try { return this.InputAlamatVM.Text.Trim(); } catch { return Alamat_; } }
        }

        private string Kelurahan_;
        public string Kelurahan
        {
            set {
                Kelurahan_ = value;
                this.InputKelurahanVM.Text = Kelurahan_;
                try { this.InputKelurahanVM.Text = Kelurahan_; } catch { }
            }
            get { try { return this.InputKelurahanVM.Text.Trim(); } catch { return Kelurahan_; } }
        }

        private string Kecamatan_;
        public string Kecamatan
        {
            set {
                Kecamatan_ = value;
                this.InputKecamatanVM.Text = Kecamatan_;
                try { this.InputKecamatanVM.Text = Kecamatan_; } catch { }
            }
            get { try { return this.InputKecamatanVM.Text.Trim(); } catch { return Kecamatan_; } }
        }

        private string Kota_;
        public string Kota
        {
            set {
                Kota_ = value;
                this.InputKotaVM.Text = Kota_;
                try { this.InputKotaVM.Text = Kota_; } catch { }
                this.OnPropertyChanged();
            }
            get { try { return this.InputKotaVM.Text.Trim(); } catch { return Kota_; } }
        }

        private string Provinsi_;
        public string Provinsi
        {
            set {
                Provinsi_ = value;
                this.InputProvinsiVM.Text = Provinsi_;
                try { this.InputProvinsiVM.Text = Provinsi_; } catch { }
            }
            get { try { return this.InputProvinsiVM.Text.Trim(); } catch { return Provinsi_; } }
        }

        private string KodePos_;
        public string KodePos
        {
            set {
                KodePos_ = value;
                this.InputKodePosVM.Text = KodePos_;
                try { this.InputKodePosVM.Text = KodePos_; } catch { }
            }
            get { try { return this.InputKodePosVM.Text.Trim(); } catch { return KodePos_; } }
        }

        public override bool IsValid 
        {
            get {
                try {
                    if (!this.InputAlamatVM.IsValid) throw new Exception("");
                    else if (!this.InputKelurahanVM.IsValid) throw new Exception("");
                    else if (!this.InputKecamatanVM.IsValid) throw new Exception("");
                    else if (!this.InputKotaVM.IsValid) throw new Exception("");
                    else if (!this.InputProvinsiVM.IsValid) throw new Exception("");
                    else if (!this.InputKodePosVM.IsValid) throw new Exception("");
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
            get { return this.Alamat; }
        }
        #endregion Properties

        public AddressVM(PanelEnum panelenum) : this(null, panelenum, 1, null) { }
        public AddressVM(Address entity, PanelEnum panelenum, int no, ImageSource imagesource) : base(entity,panelenum, no, imagesource) { }
        protected override void OnInitInput(Address entity, PanelEnum panelenum)
        {
            base.OnInitInput(entity, panelenum);
            if (panelenum == PanelEnum.Edit1){
                this.InputAlamatVM = new InputTextVM(new InputText("Alamat", "Masukkan alamat...", ""));
                this.InputKelurahanVM = new InputTextVM(new InputText("Kelurahan", "Masukkan kelurahan...", ""));
                this.InputKecamatanVM = new InputTextVM(new InputText("Kecamatan", "Masukkan kecamatan...", ""));
                this.InputKotaVM = new InputTextVM(new InputText("Kota", "Masukkan kota...", ""));
                this.InputProvinsiVM = new InputTextVM(new InputText("Provinsi", "Masukkan provinsi...", ""));
                this.InputKodePosVM = new InputTextVM(new InputText("Kode Pos", "Masukkan kode pos...", "") { MaxLength = 5 });
            }
        }

    }
}
