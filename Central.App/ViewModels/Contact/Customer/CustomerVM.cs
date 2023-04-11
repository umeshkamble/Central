
namespace Central.App.ViewModels
{
    public class CustomerVM : ContactVM<Customer>, ICustomer
    {
        #region Properties
        public override Customer Entity
        {
            set {
                if (value is null) return;
                var entity = value;
                base.Entity = entity;

                this.Id_Salesman = entity.Id_Salesman;
                this.LamaJT = entity.LamaJT;
                this.Plafond = entity.Plafond;
                this.NoNPWP = entity.NoNPWP;
            }
            get {
                var entity = base.Entity;
                entity.Id_Salesman = this.Id_Salesman;
                entity.LamaJT = this.LamaJT;
                entity.Plafond = this.Plafond;
                entity.NoNPWP = this.NoNPWP;
                return entity;
            }
        }

        public InputPickerVM InputSalesmanVM { get; set; }
        public InputTextVM InputLamaJTVM { get; set; }
        public InputTextVM InputPlafondVM { get; set; }
        public InputTextVM InputNoNPWPVM { get; set; }

        private string Id_Salesman_;
        public string Id_Salesman
        {
            set {
                Id_Salesman_ = value;
                try { this.InputSalesmanVM.Id = Id_Salesman_; } catch { }
            }
            get { try { return this.InputSalesmanVM.Id; }catch{ return Id_Salesman_; } }
        }

        private int LamaJT_;
        public int LamaJT
        {
            set {
                LamaJT_ = value;
                try { this.InputLamaJTVM.Text = LamaJT_.ToString("#,##0"); } catch { }
                this.OnPropertyChanged();
            }
            get { try { return Base.ToInt(this.InputLamaJTVM.Text); } catch { return LamaJT_; } }
        }

        private double Plafond_;
        public double Plafond
        {
            set {
                Plafond_ = value;
                try { this.InputPlafondVM.Text = Plafond_.ToString("#,##0"); } catch { }
                this.OnPropertyChanged();
            }
            get { try { return Base.ToDouble(this.InputPlafondVM.Text); } catch { return Plafond_; } }
        }

        private string NoNPWP_;
        public virtual string NoNPWP
        {
            set {
                NoNPWP_ = value;
                try { this.InputNoNPWPVM.Text = NoNPWP_; } catch { }
                this.OnPropertyChanged();
            }
            get { try { return this.InputNoNPWPVM.Text; } catch { return NoNPWP_; } }
        }

        public override bool IsValid
        {
            get {
                var isvalid = base.IsValid;
                if (!isvalid) return isvalid;
                
                if (!this.InputLamaJTVM.IsValid) return false;
                else if (!this.InputNoNPWPVM.IsValid) return false;
                return true;
            }
        }

        public string Id_Coa { get; set; }
        public string Password { get; set; }
        public LevelHrgEnum LevelHrg { get; set; }
        #endregion Properties

        public CustomerVM(PanelEnum panelenum) : this(null, panelenum, 1, null) { }
        public CustomerVM(Customer entity, PanelEnum panelenum, int no, ImageSource imagesource) : base(entity, panelenum, no, imagesource) { }
        
        protected override void OnInitInput(Customer entity, PanelEnum panelenum)
        {
            base.OnInitInput(entity, panelenum);
            if (panelenum == PanelEnum.Edit1) {
                this.InputSalesmanVM = new InputPickerVM(new InputPicker("Salesman", "Pilih Salesman", IconFont.Male), nameof(Salesman));
                this.InputLamaJTVM = new InputTextVM(new InputText("Lama JT", "*Lama jatuh tempo bon pelanggan", "", IconFont.Calendar, TextEnum.Number));
                this.InputPlafondVM = new InputTextVM(new InputText("Plafond", "*Jumlah maksimal piutang", "", IconFont.Calculator, TextEnum.NumberDecimal));
                this.InputNoNPWPVM = new InputTextVM(new InputText("No. NPWP", "*Nomor pokok wajib pajak pelanggan", "", IconFont.IdCard, TextEnum.NPWP));
            }
        }
    }
}
