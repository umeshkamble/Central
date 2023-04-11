
namespace Central.App.ViewModels
{
    public class PayCekVM : PayVM<PayCek>, IPayCek
    {
        #region Properties
        public override PayCek Entity
        {
            set {
                if (value is null) return;
                var entity = value;
                base.Entity = entity;

                this.Id_CoaPencairan = entity.Id_CoaPencairan;
                this.Id_KasBank = entity.Id_KasBank;
                this.TglCek = entity.TglCek;
                this.NamaPenerima = entity.NamaPenerima;
            }
            get {
                var entity = base.Entity;
                entity.Id_CoaPencairan = this.Id_CoaPencairan;
                entity.Id_KasBank = this.Id_KasBank;
                entity.TglCek = this.TglCek;
                entity.NamaPenerima = this.NamaPenerima;
                return entity;
            }
        }

        public InputPickerVM InputKasBankVM { get; set; }
        public InputDateVM InputTglCekVM { get; set; }
        public InputTextVM InputNamaPenerimaVM { get; set; }

        public string Id_CoaPencairan { get; set; }

        private string Id_KasBank_;
        public string Id_KasBank
        {
            set {
                Id_KasBank_ = value;
                try { this.InputKasBankVM.Id = Id_KasBank_; } catch { }
            }
            get { try { return this.InputKasBankVM.Id; }catch{ return Id_KasBank_; } }
        }

        private DateTime TglCek_;
        public DateTime TglCek
        {
            set {
                TglCek_ = value;
                try { this.InputTglCekVM.Value = TglCek_; } catch { }
                this.OnPropertyChanged();
            }
            get { try { return this.InputTglCekVM.Value; } catch { return TglCek_; } }
        }

        private string NamaPenerima_;
        public virtual string NamaPenerima
        {
            set {
                NamaPenerima_ = value;
                try { this.InputNamaPenerimaVM.Text = NamaPenerima_; } catch { }
            }
            get { try { return this.InputNamaPenerimaVM.Text; } catch { return NamaPenerima_; } }
        }

        public override bool IsValid
        {
            get {
                var isvalid = base.IsValid;
                if (!isvalid) return isvalid;
                
                if (!this.InputKasBankVM.IsValid) return false;
                else if (!this.InputTglCekVM.IsValid) return false;
                else if (!this.InputNamaPenerimaVM.IsValid) return false;
                return true;
            }
        }

        #endregion Properties

        public PayCekVM(PanelEnum panelenum) : this(null, panelenum, 1, null) { }
        public PayCekVM(PayCek entity, PanelEnum panelenum, int no, ImageSource imagesource) : base(entity, panelenum, no, imagesource) { }
        
        protected override void OnInitInput(PayCek entity, PanelEnum panelenum)
        {
            base.OnInitInput(entity, panelenum);
            if (panelenum == PanelEnum.Edit1) {
                this.InputKasBankVM = new InputPickerVM(new InputPicker("Kas/Bank", "Pilih Kas/Bank Pencairan", IconFont.Building), nameof(Bank));
                this.InputTglCekVM = new InputDateVM(new InputDate("Tgl. Cek", "", "", 0, 0));
                this.InputNamaPenerimaVM = new InputTextVM(new InputText("Nama Penerima", "Nama Penerima", "", IconFont.InfoCircle, TextEnum.Text) { IsTitleCase = false });
            }
        }
    }
}
