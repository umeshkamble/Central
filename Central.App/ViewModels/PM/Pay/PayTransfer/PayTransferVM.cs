
namespace Central.App.ViewModels
{
    public class PayTransferVM : PayVM<PayTransfer>, IPayTransfer
    {
        #region Properties
        public override PayTransfer Entity
        {
            set {
                if (value is null) return;
                var entity = value;
                base.Entity = entity;

                this.Id_Bank = entity.Id_Bank;
                this.TglTransfer = entity.TglTransfer;
            }
            get {
                var entity = base.Entity;
                entity.Id_Bank = this.Id_Bank;
                entity.TglTransfer = this.TglTransfer;
                return entity;
            }
        }

        public InputPickerVM InputBankVM { get; set; }
        public InputDateVM InputTglTransferVM { get; set; }

        public InputPickerVM InputKasVM { get; set; }
        public InputPickerVM InputQRISVM { get; set; }


        private string Id_Bank_;
        public string Id_Bank
        {
            set {
                Id_Bank_ = value;
                try { this.InputBankVM.Id = Id_Bank_; } catch { }
            }
            get { try { return this.InputBankVM.Id; }catch{ return Id_Bank_; } }
        }

        private DateTime TglTransfer_;
        public DateTime TglTransfer
        {
            set {
                TglTransfer_ = value;
                try { this.InputTglTransferVM.Value = TglTransfer_; } catch { }
                this.OnPropertyChanged();
            }
            get { try { return this.InputTglTransferVM.Value; } catch { return TglTransfer_; } }
        }

        public override bool IsValid
        {
            get {
                var isvalid = base.IsValid;
                if (!isvalid) return isvalid;
                
                if (!this.InputBankVM.IsValid) return false;
                return true;
            }
        }



        #endregion Properties

        public PayTransferVM(PanelEnum panelenum) : this(null, panelenum, 1, null) { }
        public PayTransferVM(PayTransfer entity, PanelEnum panelenum, int no, ImageSource imagesource) : base(entity, panelenum, no, imagesource) { }
        
        protected override void OnInitInput(PayTransfer entity, PanelEnum panelenum)
        {
            base.OnInitInput(entity, panelenum);
            if (panelenum == PanelEnum.Edit1) {
                this.InputBankVM = new InputPickerVM(new InputPicker("Bank", "Bank (Tujuan)", IconFont.Building), nameof(Bank));
                this.InputTglTransferVM = new InputDateVM(new InputDate("Tgl. Transfer", "", "", 0, 0));


                this.InputKasVM = new InputPickerVM(new InputPicker("Kas", "Kas (Tujuan)", IconFont.Building), nameof(Kas));
                this.InputQRISVM = new InputPickerVM(new InputPicker("QRIS", "QRIS (Tujuan)", IconFont.Building), nameof(QRIS));

            }
        }
    }
}
