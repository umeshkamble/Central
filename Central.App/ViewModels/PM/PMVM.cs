

using MongoDB.Driver.Core.Operations;

namespace Central.App.ViewModels
{
    public class PMVM : PanelVM<PM>, IPM
    {
        #region Properties
        public override PM Entity
        {
            set{
                if (value is null) return;
                var entity = value;
                base.Entity = entity;

                this.Grup = entity.Grup;
                this.Mode = entity.Mode;
                this.Tgl = entity.Tgl;
                this.NoReferensis = entity.NoReferensis;
                this.Nama = entity.Nama;
                this.Deskripsi = entity.Deskripsi;

                this.PSum = entity.PSum;
                this.PayVariants = entity.PayVariants;
                this.PMRefs = entity.PMRefs;
            }
            get {
                var entity = base.Entity;
                entity.Grup = this.Grup;
                entity.Mode = this.Mode;
                entity.Tgl = this.Tgl;
                entity.NoReferensis = this.NoReferensis;
                entity.Nama = this.Nama;
                entity.Deskripsi = this.Deskripsi;

                entity.PSum = this.PSum;
                entity.PayVariants = this.PayVariants;
                entity.PMRefs = this.PMRefs;
                return entity;
            }
        }

        public PayVariantListVM PayVariantList1VM { get; set; }
        public PayVariantListVM PayVariantList2VM { get; set; }
        public PSumVM PSumVM { get; set; }

        private EntityEnum Grup_;
        public EntityEnum Grup
        {
            set { this.OnSetProperty(ref Grup_, value); }
            get { return Grup_; }
        }

        private PMModeEnum Mode_;
        public PMModeEnum Mode
        {
            set { this.OnSetProperty(ref Mode_, value); }
            get { return Mode_; }
        }

        private DateTime Tgl_;
        public DateTime Tgl
        {
            set { this.OnSetProperty(ref Tgl_, value); }
            get { return Tgl_; }
        }

        private string Nama_;
        public string Nama
        {
            set { this.OnSetProperty(ref Nama_, value); }
            get { return Nama_; }
        }

        private string NoReferensis_;
        public string NoReferensis
        {
            set { this.OnSetProperty(ref NoReferensis_, value); }
            get { return NoReferensis_; }
        }

        private string Deskripsi_;
        public string Deskripsi
        {
            set { this.OnSetProperty(ref Deskripsi_, value); }
            get { return Deskripsi_; }
        }

        private PSum PSum_;
        public PSum PSum
        {
            set {
                if (value is null) return;

                PSum_ = value;
                try { this.PSumVM.Entity = PSum_; } catch { }
            }
            get {
                try { return this.PSumVM.Entity; } catch { return PSum_; }
            }
        }

        private List<PayVariant> PayVariants_;
        public List<PayVariant> PayVariants
        {
            set {
                if (value is null) return;
                PayVariants_ = value;

                try {
                    this.PayVariantList1VM.OnSelect(PayVariants_);
                    this.PayVariantList2VM.InsertCommand.Execute(PayVariants_);
                }
                catch { }
            }
            get {
                try { return this.PayVariantList2VM.Entitys; } catch { return PayVariants_; }
            }
        }

        public List<PMRef> PMRefs { get; set; }

        public override bool IsValid 
        {
            get {
                try {
                    //if (!this.InputNamaVM.IsValid) throw new Exception("");
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

        #region Event
        public delegate void PSumEventHandler(PSum psum);
        public event PSumEventHandler PSumChanged;
        #endregion Event  

        public PMVM(PanelEnum panelenum) : this(null, panelenum, 1, null) { }
        public PMVM(PM entity, PanelEnum panelenum, int no, ImageSource imagesource) : base(entity, panelenum, no, imagesource) { }
        protected override async void OnInitInput(PM entity, PanelEnum panelenum)
        {
            base.OnInitInput(entity, panelenum);
            if (panelenum == PanelEnum.Edit1) {
                this.PSumVM = new PSumVM(PanelEnum.GridList); 
                this.PayVariantList1VM = new PayVariantListVM(new List<TemplateEnum> { TemplateEnum.Grid }, SelectionEnum.Multiple, PanelEnum.GridList, false, false);
                this.PayVariantList2VM = new PayVariantListVM(new List<TemplateEnum> { TemplateEnum.List }, SelectionEnum.None, PanelEnum.GridList, false, true);
            }
        }

        protected override void OnInitEvent(PM entity, PanelEnum panelenum)
        {
            base.OnInitEvent(entity,panelenum);

            if (panelenum == PanelEnum.Edit1) {
                //--------------PayVariantList1VM Event-----------------------------//
                this.PayVariantList1VM.SelectedChanged += ((item) => {
                    var pv = item.Entity;
                    var grup = pv.Grup;
                    var id_coa = pv.Id_Coa;
                    var total = this.PSum.Sisa;

                    var pays = new List<Pay>();
                    if (grup == PayGrupEnum.Cash) pays.Add(new PayCash(id_coa, total));
                    else if (grup == PayGrupEnum.Cek) pays.Add(new PayCek(id_coa, total));
                    else if (grup == PayGrupEnum.BG) pays.Add(new PayBG(id_coa, total));
                    else if (grup == PayGrupEnum.Transfer) pays.Add(new PayTransfer(id_coa, total));

                    pv = new PayVariant(pv, pays);
                    this.PayVariantList2VM.InsertOneCommand.Execute(pv);
                });
                this.PayVariantList1VM.UnSelectedChanged += ((item) => {
                    this.PayVariantList2VM.DeleteByNamaCommand.Execute(item.Nama);
                });


                //--------------PayVariantList2VM Event-----------------------------//
                this.PayVariantList2VM.BayarChanged += ((double bayar) => {
                    this.PSum = new PSum(this.PSum, bayar);
                });


                //--------------PSumVM Event-----------------------------//
                this.PSumVM.SplitChanged += ((issplit) => {
                    var vmlist = this.PayVariantList1VM;
                    var count = vmlist.ItemSelectedCount;
                    if (!issplit && count > 1) vmlist.OnClearSelected();
                    vmlist.SelectionEnum = issplit ? SelectionEnum.Multiple : SelectionEnum.Single;
                });

                this.PSumVM.PSumChanged += ((psum) => {
                    if (psum.Sisa < 0) {
                        this.PSum = this.PayVariantList2VM.OnTotalReset(psum);
                        return;
                    }

                    if (this.PSumChanged != null) this.PSumChanged(psum);
                });
            }
        }

        protected override Task<List<Task>> OnLoadFirstAsync(List<Task> tasks)
        {
            if (this.PanelEnum == PanelEnum.Edit1) tasks.Add(this.PayVariantList1VM.OnLoadAllAsync());
            return base.OnLoadFirstAsync(tasks);
        }

        protected override Task OnLoadFinishedAsync()
        {
            this.PSumVM.OnSplitChanged();
            return base.OnLoadFinishedAsync();
        }

        private void OnSplitChanged(bool issplit)
        { 
            
        }
    }
}
