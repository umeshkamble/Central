


namespace Central.App.ViewModels
{
    public class PayVariantVM : PanelVM<PayVariant>, IPayVariant
    {
        #region Properties
        public override PayVariant Entity
        {
            set{
                if (value is null) return;
                var entity = value;
                base.Entity = entity;

                this.IsRun = false;
                this.Id_Coa = entity.Id_Coa;
                this.Grup = entity.Grup;
                this.No = entity.No;
                this.Nama = entity.Nama;
                this.Total = entity.Total;
                this.TotalItem = entity.TotalItem;
                this.Ids = entity.Ids;
                this.Pays = entity.Pays;
                this.IsRun = true;

                this.OnChanged();
            }
            get {
                return new PayVariant(this.Grup, this.Nama, this.Id_Coa, this.Pays);
            }
        }

        public PagePayVariantEditV Page { get; set; }
        public PagePayVariantEditVM VM { get; set; }

        public PayCashListVM PayCashListVM { get; set; }
        public PayCekListVM PayCekListVM { get; set; }
        public PayBGListVM PayBGListVM { get; set; }
        public PayTransferListVM PayTransferListVM { get; set; }

        public string Id_Coa { get; set; }
        
        private PayGrupEnum Grup_;
        public PayGrupEnum Grup
        {
            set {
                Grup_ = value;

                this.IsViewCash = this.IsViewCek = this.IsViewBG = this.IsViewTransfer = false;
                if (Grup_ == PayGrupEnum.Cash) this.IsViewCash = true;
                else if (Grup_ == PayGrupEnum.Cek) this.IsViewCek = true;
                else if (Grup_ == PayGrupEnum.BG) this.IsViewBG = true;
                else if (Grup_ == PayGrupEnum.Transfer) this.IsViewTransfer = true;
                this.OnPropertyChanged();
            }
            get { return Grup_; }
        }

        private string Nama_;
        public string Nama
        {
            set { this.OnSetProperty(ref Nama_, value); }
            get { return Nama_; }
        }

        private double Total_;
        public double Total
        {
            set {
                Total_ = value;
                this.OnPropertyChanged();
                this.OnTotalChanged();
            }
            get { return Total_; }
        }

        private int TotalItem_;
        public int TotalItem
        {
            set { this.OnSetProperty(ref TotalItem_, value); }
            get { return TotalItem_; }
        }

        public List<string> Ids { get; set; }
        
        private List<Pay> Pays_;
        public List<Pay> Pays
        {
            set {
                if (value is null) return;
                Pays_ = value;

                try {
                    this.PayCashListVM.OnClear(); this.PayCekListVM.OnClear(); this.PayBGListVM.OnClear(); this.PayTransferListVM.OnClear();
                    switch (this.Grup) {
                        case PayGrupEnum.Cash: {
                                var paycashs = Base.GetList<Pay, PayCash>(Pays_);
                                this.PayCashListVM.InsertCommand.Execute(paycashs);
                                break;
                            }
                        case PayGrupEnum.Cek: {
                                var payceks = Base.GetList<Pay, PayCek>(Pays_);
                                this.PayCekListVM.InsertCommand.Execute(payceks);
                                break;
                            }
                        case PayGrupEnum.BG: {
                                var paybgs = Base.GetList<Pay, PayBG>(Pays_);
                                this.PayBGListVM.InsertCommand.Execute(paybgs); 
                                break;
                            }
                        case PayGrupEnum.Transfer: {
                                var paytransfers = Base.GetList<Pay, PayTransfer>(Pays_);
                                this.PayTransferListVM.InsertCommand.Execute(paytransfers); 
                                break;
                            }
                    }
                } 
                catch { }
            }
            get {
                try {
                    var pays = new List<Pay>();
                    switch (this.Grup) {
                        case PayGrupEnum.Cash: {
                                var paycashs = this.PayCashListVM.Entitys;
                                pays = Base.GetList<PayCash, Pay>(paycashs);
                                break;
                            }
                        case PayGrupEnum.Cek: {
                                var payceks = this.PayCekListVM.Entitys;
                                pays = Base.GetList<PayCek, Pay>(payceks);
                                break;
                            }
                        case PayGrupEnum.BG: {
                                var paybgs = this.PayBGListVM.Entitys;
                                pays = Base.GetList<PayBG, Pay>(paybgs);
                                break;
                            }
                        case PayGrupEnum.Transfer: {
                                var paytransfers = this.PayTransferListVM.Entitys;
                                pays = Base.GetList<PayTransfer, Pay>(paytransfers);
                                break;
                            }
                    }
                    return pays;

                } catch { return Pays_; }
            }
        }

        private bool IsViewCash_;
        public bool IsViewCash
        {
            set { this.OnSetProperty(ref IsViewCash_, value); }
            get { return IsViewCash_; }
        }

        private bool IsViewCek_;
        public bool IsViewCek
        {
            set { this.OnSetProperty(ref IsViewCek_, value); }
            get { return IsViewCek_; }
        }

        private bool IsViewBG_;
        public bool IsViewBG
        {
            set { this.OnSetProperty(ref IsViewBG_, value); }
            get { return IsViewBG_; }
        }

        private bool IsViewTransfer_;
        public bool IsViewTransfer
        {
            set { this.OnSetProperty(ref IsViewTransfer_, value); }
            get { return IsViewTransfer_; }
        }

        public string Icon2 { get; set; } = IconFont.AngleRight;
        private bool IsRun { get; set; }
        private bool IsEditPay { get; set; }

        public override string Caption
        {
            get { return this.Nama; }
        }
        #endregion Properties

        #region Command
        public Command EditPayCommand { get; set; }
        #endregion Command

        #region Event
        public delegate void TotalEventHandler(double total);
        public event TotalEventHandler TotalChanged;

        public delegate void PayVariantEventHandler();
        public event PayVariantEventHandler Changed;
        #endregion Event

        public PayVariantVM(PanelEnum panelenum) : this(null, panelenum, 1, null, false) { }
        public PayVariantVM(PayVariant entity, PanelEnum panelenum, int no, ImageSource imagesource, bool iseditpay) : base(entity, panelenum, no, imagesource) 
        {
            this.IsEditPay = iseditpay;
        }
        
        protected override void OnInitInput(PayVariant entity, PanelEnum panelenum)
        {
            base.OnInitInput(entity, panelenum);
            if (panelenum == PanelEnum.GridList) {
                this.EditPayCommand = new Microsoft.Maui.Controls.Command(async () => {
                    if (this.VM is null) {
                        //----------Utk proses edit pay variant------------//
                        this.VM = new PagePayVariantEditVM();
                        this.VM.Saved += ((pv, isnew, saveenum) => {
                            this.Entity = pv;
                        });
                        this.Page = new PagePayVariantEditV(this.VM);
                    }

                    this.VM.Entity = this.Entity;
                    await Shell.Current.Navigation.PushAsync(this.Page);
                });
            }
            else if (panelenum == PanelEnum.Edit1) {
                this.PayCashListVM = new PayCashListVM(new List<TemplateEnum> { TemplateEnum.Edit1 }, SelectionEnum.None, PanelEnum.Edit1, false);
                this.PayCekListVM = new PayCekListVM(new List<TemplateEnum> { TemplateEnum.Edit1 }, SelectionEnum.None, PanelEnum.Edit1, false);
                this.PayBGListVM = new PayBGListVM(new List<TemplateEnum> { TemplateEnum.Edit1 }, SelectionEnum.None, PanelEnum.Edit1, false);
                this.PayTransferListVM = new PayTransferListVM(new List<TemplateEnum> { TemplateEnum.Edit1 }, SelectionEnum.None, PanelEnum.Edit1, false);
            }
        }

        protected override void OnInitEvent(PayVariant entity, PanelEnum panelenum)
        {
            base.OnInitEvent(entity, panelenum);
            if (panelenum == PanelEnum.Edit1) {
                if (this.Grup == PayGrupEnum.Cash) this.PayCashListVM.TotalChanged += ((total) => this.Total = total);
                else if (this.Grup == PayGrupEnum.Cek) this.PayCekListVM.TotalChanged += ((total) => this.Total = total);
                else if (this.Grup == PayGrupEnum.BG) this.PayBGListVM.TotalChanged += ((total) => this.Total = total);
                else if (this.Grup == PayGrupEnum.Transfer) this.PayTransferListVM.TotalChanged += ((total) => this.Total = total);
            }
        }

        public override void OnMenuSelect(MenuEnum menu)
        {
            switch (menu) {
                case MenuEnum.Add: {
                        if (this.Grup == PayGrupEnum.Cash) this.PayCashListVM.InsertOneCommand.Execute(new PayCash(this.Id_Coa, 0));
                        else if (this.Grup == PayGrupEnum.Cek) this.PayCekListVM.InsertOneCommand.Execute(new PayCek(this.Id_Coa, 0));
                        else if (this.Grup == PayGrupEnum.BG) this.PayBGListVM.InsertOneCommand.Execute(new PayBG(this.Id_Coa, 0));
                        else if (this.Grup == PayGrupEnum.Transfer) this.PayTransferListVM.InsertOneCommand.Execute(new PayTransfer(this.Id_Coa, 0));
                        break;
                    }
                default: base.OnMenuSelect(menu);break;
            }
        }

        public void OnChanged()
        {
            if (!this.IsRun) return;
            if (this.Changed != null) this.Changed();
        }

        public override void OnRefresh()
        {
            this.Entity = this.Entity;
            base.OnRefresh();
        }

        private void OnTotalChanged()
        {
            if (this.TotalChanged != null) this.TotalChanged(this.Total);
        }

        public override void OnSelect()
        {
            base.OnSelect();
            if (this.PanelEnum == PanelEnum.GridList && this.IsEditPay) {
                this.EditPayCommand.Execute(null);
            }
        }

    }
}
