

namespace Central.App.ViewModels
{
    public class QRISVM : PanelVM<QRIS>
    {
        #region Properties
        public override QRIS Entity
        {
            set{
                if (value is null) return;
                var entity = value;
                base.Entity = entity;

                this.Id_Bank = entity.Id_Bank;
                this.Nama = entity.Nama;
                this.Deskripsi = entity.Deskripsi;

                this.OnGetBank();
            }
            get {
                var entity = base.Entity;
                entity.Id_Bank = this.Id_Bank;
                entity.Nama = this.Nama;
                entity.Deskripsi = this.Deskripsi;
                return entity;
            }
        }
        
        public InputTextVM InputNamaVM { get; set; }
        public InputTextVM InputDeskripsiVM { get; set; }
        public InputPickerVM InputBankVM { get; set; }

        private string Id_Bank_;
        public string Id_Bank
        {
            set {
                Id_Bank_ = value;
                try { this.InputBankVM.Id = Id_Bank_; } catch { }
            }
            get { try { return this.InputBankVM.Id; } catch { return Id_Bank_; } }
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

        private string NamaBank_;
        public virtual string NamaBank
        {
            set { this.OnSetProperty(ref NamaBank_, value); }
            get { return NamaBank_; }
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

        public override string Caption
        {
            get { return this.Nama; }
        }
        #endregion Properties

        public QRISVM(PanelEnum panelenum) : this(null, panelenum, 1, null) { }
        public QRISVM(QRIS entity, PanelEnum panelenum, int no, ImageSource imagesource) : base(entity,panelenum, no, imagesource) { }
        
        protected override void OnInitInput(QRIS entity, PanelEnum panelenum)
        {
            base.OnInitInput(entity, panelenum);
            if (panelenum == PanelEnum.Edit1) {
                this.InputNamaVM = new InputTextVM(new InputText("Nama QRIS", "", "Cth : Go-Pay, ShopeePay, OVO, dll...") { IsTitleCase = false });
                this.InputDeskripsiVM = new InputTextVM(new InputText("Deskripsi", "", "Deskripsikan qris anda...") { IsTitleCase = false });
                this.InputBankVM = new InputPickerVM(new InputPicker("Pilih Bank", "", "Lokasi transfer", IconFont.Building), nameof(Bank));
            }
        }

        private async void OnGetBank()
        {
            var db = ((BankService)Base.GetDb(nameof(Bank), this.DbName));
            var bank = await db.Get(this.Id_Bank);
            if (bank != null) this.NamaBank = bank.Nama;
        }
    }
}
