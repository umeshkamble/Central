

namespace Central.App.ViewModels
{
    public class RateVM : PanelVM<Rate>, IRate
    {
        #region Properties
        public override Rate Entity
        {
            set {
                if (value is null) return;
                var entity = value;
                base.Entity = entity;

                this.IsRun2 = false;
                this.RateMode = entity.RateMode;
                this.Unit = entity.Unit;
                this.UnitQty = entity.UnitQty;
                this.HrgNormal = entity.HrgNormal;
                this.DiskonRp = entity.DiskonRp;
                this.Diskon1 = entity.Diskon1;
                this.Diskon2 = entity.Diskon2;
                this.Diskon3 = entity.Diskon3;
                this.HrgPublish = entity.HrgPublish;
                this.TotalDiskonRp = entity.TotalDiskonRp;
                this.TotalDiskon = entity.TotalDiskon;
                this.Deskripsi = entity.Deskripsi;
                this.IsDiskon = entity.IsDiskon;
                this.IsRun2 = true;
            }
            get {
                return new Rate(this.RateMode, this.Unit, this.UnitQty, this.HrgNormal, this.DiskonRp, this.Diskon1, this.Diskon2, this.Diskon3, this.Deskripsi);
            }
        }

        public PageRateEditV Page { get; set; }
        public PageRateEditVM VM { get; set; }

        public InputTextVM InputHrgNormalVM { get; set; }
        public InputTextVM InputDiskonRpVM { get; set; }
        public InputTextVM InputDiskon1VM { get; set; }
        public InputTextVM InputDiskon2VM { get; set; }
        public InputTextVM InputDiskon3VM { get; set; }
        public InputTextVM InputHrgPublishVM { get; set; }

        private double HrgNormal_;
        public double HrgNormal
        {
            set
            {
                HrgNormal_ = value;
                try { this.InputHrgNormalVM.Text = HrgNormal_.ToString(); } catch { }
                this.OnPropertyChanged();
            }
            get { try { return Base.ToDouble(this.InputHrgNormalVM.Text); } catch { return HrgNormal_; } }
        }

        private double DiskonRp_;
        public double DiskonRp
        {
            set {
                DiskonRp_ = value;
                try { this.InputDiskonRpVM.Text = DiskonRp_.ToString(); } catch { }
                this.OnPropertyChanged();
            }
            get { try { return Base.ToDouble(this.InputDiskonRpVM.Text); } catch { return DiskonRp_; } }
        }

        private double Diskon1_;
        public double Diskon1
        {
            set
            {
                Diskon1_ = value;
                try { this.InputDiskon1VM.Text = Diskon1_.ToString(); } catch { }
                this.OnPropertyChanged();
            }
            get { try { return Base.ToDouble(this.InputDiskon1VM.Text); } catch { return Diskon1_; } }
        }

        private double Diskon2_;
        public double Diskon2
        {
            set
            {
                Diskon2_ = value;
                try { this.InputDiskon2VM.Text = Diskon2_.ToString(); } catch { }
                this.OnPropertyChanged();
            }
            get { try { return Base.ToDouble(this.InputDiskon2VM.Text); } catch { return Diskon2_; } }
        }

        private double Diskon3_;
        public double Diskon3
        {
            set
            {
                Diskon3_ = value;
                try { this.InputDiskon3VM.Text = Diskon3_.ToString(); } catch { }
                this.OnPropertyChanged();
            }
            get { try { return Base.ToDouble(this.InputDiskon3VM.Text); } catch { return Diskon3_; } }
        }

        private double HrgPublish_;
        public double HrgPublish
        {
            set {
                HrgPublish_ = value;
                try { this.InputHrgPublishVM.Text = HrgPublish_.ToString(); } catch { }
                this.OnPropertyChanged();
            }
            get { try { return Base.ToDouble(this.InputHrgPublishVM.Text); } catch { return HrgPublish_; } }
        }

        private RateModeEnum RateMode_;
        public virtual RateModeEnum RateMode
        {
            set { this.OnSetProperty(ref RateMode_, value); }
            get { return RateMode_; }
        }

        private string Unit_;
        public virtual string Unit
        {
            set { this.OnSetProperty(ref Unit_, value); }
            get { return Unit_; }
        }

        private double UnitQty_;
        public virtual double UnitQty
        {
            set { this.OnSetProperty(ref UnitQty_, value); }
            get { return UnitQty_; }
        }

        private double TotalDiskonRp_;
        public virtual double TotalDiskonRp
        {
            set { this.OnSetProperty(ref TotalDiskonRp_, value); }
            get { return TotalDiskonRp_; }
        }

        private double TotalDiskon_;
        public virtual double TotalDiskon
        {
            set { this.OnSetProperty(ref TotalDiskon_, value); }
            get { return TotalDiskon_; }
        }

        private string Deskripsi_;
        public virtual string Deskripsi
        {
            set { this.OnSetProperty(ref Deskripsi_, value); }
            get { return Deskripsi_; }
        }

        private bool IsDiskon_;
        public virtual bool IsDiskon
        {
            set { this.OnSetProperty(ref IsDiskon_, value); }
            get { return IsDiskon_; }
        }

        private bool IsRun2 { get; set; }
        public bool IsEditRate { get; set; }
        
        public override bool IsValid 
        {
            get {
                try {
                    if (this.PanelEnum == PanelEnum.GridList) { 
                        if (this.HrgPublish <= 0) throw new Exception("Harga Publish tidak boleh kosong !");
                    }
                    else if (this.PanelEnum == PanelEnum.Edit1){
                        if (!this.InputHrgPublishVM.IsValid) throw new Exception("Harga Publish tidak boleh kosong !");
                    }
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
            get { return this.RateMode.ToString(); }
        }
        #endregion Properties

        #region Command
        public Command EditRateCommand { get; set; }
        #endregion Command

        #region Event
        public delegate void RateEventHandler(Rate rate);
        public event RateEventHandler RateChanged;
        #endregion Event


        public RateVM(PanelEnum panelenum) : this(panelenum, false) { }
        public RateVM(PanelEnum panelenum, bool iseditrate) : this(null, panelenum, 1, null, iseditrate) { }
        public RateVM(Rate entity, PanelEnum panelenum, int no, ImageSource imagesource, bool iseditrate) : base(entity, panelenum, no, imagesource) 
        {
            this.IsEditRate = iseditrate;
        }
        
        protected override void OnInitInput(Rate entity, PanelEnum panelenum)
        {
            base.OnInitInput(entity, panelenum);
            if (panelenum == PanelEnum.GridList) { }
            else if (panelenum == PanelEnum.Edit1) {
                this.InputHrgNormalVM = new InputTextVM(new InputText("H. Normal", "Rp.", "", IconFont.Calculator, TextEnum.NumberDecimal));
                this.InputDiskonRpVM = new InputTextVM(new InputText("Diskon (Rp)", "Rp.", "", IconFont.Calculator, TextEnum.NumberDecimal));
                this.InputDiskon1VM = new InputTextVM(new InputText("Diskon (1)", "%", "", IconFont.Percentage, TextEnum.NumberDecimal));
                this.InputDiskon2VM = new InputTextVM(new InputText("Diskon (2)", "%", "", IconFont.Percentage, TextEnum.NumberDecimal));
                this.InputDiskon3VM = new InputTextVM(new InputText("Diskon (3)", "%", "", IconFont.Percentage, TextEnum.NumberDecimal));
                this.InputHrgPublishVM = new InputTextVM(new InputText("H. Publish", "Rp.", "", IconFont.Calculator, TextEnum.NumberDecimal));
            }
        }

        protected override void OnInitEvent(Rate entity, PanelEnum panelenum)
        {
            base.OnInitEvent(entity, panelenum);
            if (panelenum == PanelEnum.GridList) {
                this.EditRateCommand = new Microsoft.Maui.Controls.Command(async () => {
                    if (this.VM is null) {
                        //----------Utk proses edit diskon faktur------------//
                        this.VM = new PageRateEditVM();
                        this.VM.Saved += ((rate, isnew, saveenum) => {
                            this.Entity = rate;
                            if (this.RateChanged != null) this.RateChanged(rate);
                        });
                        this.Page = new PageRateEditV(this.VM);
                    }

                    this.VM.Entity = this.Entity;
                    await Shell.Current.Navigation.PushAsync(this.Page);
                });

               
            }
            else if (panelenum == PanelEnum.Edit1) {
                this.InputHrgNormalVM.TextChanged += ((item) => this.OnHrgNormalChanged());
                this.InputDiskonRpVM.TextChanged += ((item) => this.OnHrgNormalChanged());
                this.InputDiskon1VM.TextChanged += ((item) => this.OnHrgNormalChanged());
                this.InputDiskon2VM.TextChanged += ((item) => this.OnHrgNormalChanged());
                this.InputDiskon3VM.TextChanged += ((item) => this.OnHrgNormalChanged());
                this.InputHrgPublishVM.TextChanged += ((item) => this.OnHrgPublishChanged());
            }
        }

        private void OnHrgNormalChanged()
        {
            if (!this.IsRun2) return;

            this.IsRun2 = false;
            this.HrgPublish = Base.GetNett(this.HrgNormal, this.DiskonRp, this.Diskon1, this.Diskon2, this.Diskon3);
            this.IsRun2 = true;
        }

        private void OnHrgPublishChanged()
        {
            if (!this.IsRun2) return;

            this.IsRun2 = false;
            this.HrgNormal = this.HrgPublish;
            this.DiskonRp = this.Diskon1 = this.Diskon2 = this.Diskon3 = 0;
            this.IsRun2 = true;
        }

        public override void OnSelect()
        {
            base.OnSelect();
            if (this.PanelEnum == PanelEnum.GridList && this.IsEditRate) {
                this.EditRateCommand.Execute(null);
            }
        }
    }
}
