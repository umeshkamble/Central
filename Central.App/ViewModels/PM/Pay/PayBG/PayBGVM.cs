
namespace Central.App.ViewModels
{
    public class PayBGVM : PayVM<PayBG>, IPayBG
    {
        #region Properties
        public override PayBG Entity
        {
            set {
                if (value is null) return;
                var entity = value;
                base.Entity = entity;

                this.Id_CoaPencairan = entity.Id_CoaPencairan;
                this.Id_Bank = entity.Id_Bank;
                this.TglBG = entity.TglBG;
                this.TglJT = entity.TglJT;
                this.NoRekeningPenerima = entity.NoRekeningPenerima;
                this.NamaPenerima = entity.NamaPenerima;
                this.BankPenerima = entity.BankPenerima;
            }
            get {
                var entity = base.Entity;
                entity.Id_CoaPencairan = this.Id_CoaPencairan;
                entity.Id_Bank = this.Id_Bank;
                entity.TglBG = this.TglBG;
                entity.TglJT = this.TglJT;
                entity.NoRekeningPenerima = this.NoRekeningPenerima;
                entity.NamaPenerima = this.NamaPenerima;
                entity.BankPenerima = this.BankPenerima;
                return entity;
            }
        }

        public InputPickerVM InputBankVM { get; set; }
        public InputDateVM InputTglBGVM { get; set; }
        public InputDateVM InputTglJTVM { get; set; }
        public InputTextVM InputNoRekeningPenerimaVM { get; set; }
        public InputTextVM InputNamaPenerimaVM { get; set; }
        public InputTextVM InputBankPenerimaVM { get; set; }

        public string Id_CoaPencairan { get; set; }

        private string Id_Bank_;
        public string Id_Bank
        {
            set {
                Id_Bank_ = value;
                try { this.InputBankVM.Id = Id_Bank_; } catch { }
            }
            get { try { return this.InputBankVM.Id; }catch{ return Id_Bank_; } }
        }

        private DateTime TglBG_;
        public DateTime TglBG
        {
            set {
                TglBG_ = value;
                try { this.InputTglBGVM.Value = TglBG_; } catch { }
                this.OnPropertyChanged();
            }
            get { try { return this.InputTglBGVM.Value; } catch { return TglBG_; } }
        }

        private DateTime TglJT_;
        public DateTime TglJT
        {
            set {
                TglJT_ = value;
                try { this.InputTglJTVM.Value = TglJT_; } catch { }
                this.OnPropertyChanged();
            }
            get { try { return this.InputTglJTVM.Value; } catch { return TglJT_; } }
        }

        private string NoRekeningPenerima_;
        public virtual string NoRekeningPenerima
        {
            set
            {
                NoRekeningPenerima_ = value;
                try { this.InputNoRekeningPenerimaVM.Text = NoRekeningPenerima_; } catch { }
            }
            get { try { return this.InputNoRekeningPenerimaVM.Text; } catch { return NoRekeningPenerima_; } }
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

        private string BankPenerima_;
        public virtual string BankPenerima
        {
            set {
                BankPenerima_ = value;
                try { this.InputBankPenerimaVM.Text = BankPenerima_; } catch { }
            }
            get { try { return this.InputBankPenerimaVM.Text; } catch { return BankPenerima_; } }
        }

        public override bool IsValid
        {
            get {
                var isvalid = base.IsValid;
                if (!isvalid) return isvalid;
                
                if (!this.InputBankVM.IsValid) return false;
                else if (!this.InputTglBGVM.IsValid) return false;
                else if (!this.InputTglJTVM.IsValid) return false;
                else if (!this.InputNoRekeningPenerimaVM.IsValid) return false;
                else if (!this.InputNamaPenerimaVM.IsValid) return false;
                else if(!this.InputBankPenerimaVM.IsValid) return false;
                return true;
            }
        }

        #endregion Properties

        public PayBGVM(PanelEnum panelenum) : this(null, panelenum, 1, null) { }
        public PayBGVM(PayBG entity, PanelEnum panelenum, int no, ImageSource imagesource) : base(entity, panelenum, no, imagesource) { }
        
        protected override void OnInitInput(PayBG entity, PanelEnum panelenum)
        {
            base.OnInitInput(entity, panelenum);
            if (panelenum == PanelEnum.Edit1) {
                this.InputBankVM = new InputPickerVM(new InputPicker("Bank", "Pilih Bank Pencairan", IconFont.Building), nameof(Bank));
                this.InputTglBGVM = new InputDateVM(new InputDate("Tgl. BG", "", "", 0, 0));
                this.InputTglJTVM = new InputDateVM(new InputDate("Tgl. JT", "", "", 0, 0));
                this.InputNoRekeningPenerimaVM = new InputTextVM(new InputText("No. Rekening", "No. Rekening Penerima", "", IconFont.InfoCircle, TextEnum.Text) { IsTitleCase = false });
                this.InputNamaPenerimaVM = new InputTextVM(new InputText("Nama Penerima", "Nama Penerima", "", IconFont.InfoCircle, TextEnum.Text) { IsTitleCase = false });
                this.InputBankPenerimaVM = new InputTextVM(new InputText("Bank Penerima", "Bank Penerima", "", IconFont.InfoCircle, TextEnum.Text) { IsTitleCase = false });
            }
        }
    }
}
