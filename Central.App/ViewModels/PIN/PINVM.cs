using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Central.App.ViewModels
{
    public partial class PINVM : PanelVM<PIN>
    {
        #region Properties
        public override PIN Entity
        {
            set{
                if (value is null) return;

                var entity = value;
                base.Entity = entity;

                this.PIN1 = entity.PIN1;
                this.PIN2 = entity.PIN2;
                this.PIN3 = entity.PIN3;
                this.PIN4 = entity.PIN4;
                this.PIN5 = entity.PIN5;
                this.PIN6 = entity.PIN6;
                this.IsOTP = entity.IsOTP;
            }
            get {
                return new PIN() {
                    PIN1 = this.PIN1,
                    PIN2 = this.PIN2,
                    PIN3 = this.PIN3,
                    PIN4 = this.PIN4,
                    PIN5 = this.PIN5,
                    PIN6 = this.PIN6,
                    IsOTP = this.IsOTP
                };
            } 
        }

        public InputTextVM InputPIN1VM { get; set; }
        public InputTextVM InputPIN2VM { get; set; }
        public InputTextVM InputPIN3VM { get; set; }
        public InputTextVM InputPIN4VM { get; set; }
        public InputTextVM InputPIN5VM { get; set; }
        public InputTextVM InputPIN6VM { get; set; }

        private string PIN1_ = "";
        public string PIN1
        {
            set {
                PIN1_ = value;
                this.InputPIN1VM.Text = PIN1_;
            }
            get { return this.InputPIN1VM.Text.Trim(); }
        }

        private string PIN2_ = "";
        public string PIN2
        {
            set
            {
                PIN2_ = value;
                this.InputPIN2VM.Text = PIN2_;
            }
            get { return this.InputPIN2VM.Text.Trim(); }
        }

        private string PIN3_ = "";
        public string PIN3
        {
            set
            {
                PIN3_ = value;
                this.InputPIN3VM.Text = PIN3_;
            }
            get { return this.InputPIN3VM.Text.Trim(); }
        }

        private string PIN4_ = "";
        public string PIN4
        {
            set
            {
                PIN4_ = value;
                this.InputPIN4VM.Text = PIN4_;
            }
            get { return this.InputPIN4VM.Text.Trim(); }
        }

        private string PIN5_ = "";
        public string PIN5
        {
            set
            {
                PIN5_ = value;
                this.InputPIN5VM.Text = PIN5_;
            }
            get { return this.InputPIN5VM.Text.Trim(); }
        }

        private string PIN6_ = "";
        public string PIN6
        {
            set
            {
                PIN6_ = value;
                this.InputPIN6VM.Text = PIN6_;
            }
            get { return this.InputPIN6VM.Text.Trim(); }
        }

        public bool IsOTP { get; set; } = false;

        public override bool IsValid 
        {
            get {
                try {
                    if (!this.InputPIN1VM.IsValid) throw new Exception("");
                    else if (!this.InputPIN2VM.IsValid) throw new Exception("");
                    else if (!this.InputPIN3VM.IsValid) throw new Exception("");
                    else if (!this.InputPIN4VM.IsValid) throw new Exception("");
                    else if (!this.InputPIN5VM.IsValid) throw new Exception("");
                    else if (!this.InputPIN6VM.IsValid) throw new Exception("");
                } 
                catch (Exception ex) {
                    this.OnAlert(ex);
                    return false;
                }

                return base.IsValid;
            }
        }

        public override string Caption
        {
            get { return ""; }
        }
        #endregion Properties

        #region Event
        public delegate void PINEventHandler(PIN pin);
        public event PINEventHandler Completed;
        #endregion Event    

        public PINVM(PIN entity) : base(entity) { }
        protected override void OnInitInput(PIN entity, PanelEnum panelenum)
        {
            base.OnInitInput(entity, panelenum);
            var textenum = TextEnum.PIN;
            if (entity.IsOTP) textenum = TextEnum.OTP;

            this.InputPIN1VM = new InputTextVM(new InputText("", "", "", "", textenum) { MaxLength = 1 });
            this.InputPIN2VM = new InputTextVM(new InputText("", "", "", "", textenum) { MaxLength = 1 });
            this.InputPIN3VM = new InputTextVM(new InputText("", "", "", "", textenum) { MaxLength = 1 });
            this.InputPIN4VM = new InputTextVM(new InputText("", "", "", "", textenum) { MaxLength = 1 });
            this.InputPIN5VM = new InputTextVM(new InputText("", "", "", "", textenum) { MaxLength = 1 });
            this.InputPIN6VM = new InputTextVM(new InputText("", "", "", "", textenum) { MaxLength = 1 });
        }
        protected override void OnInitEvent(PIN entity,PanelEnum panelenum)
        {
            base.OnInitEvent(entity, panelenum);
            this.InputPIN1VM.TextChanged += OnPINChanged;
            this.InputPIN2VM.TextChanged += OnPINChanged;
            this.InputPIN3VM.TextChanged += OnPINChanged;
            this.InputPIN4VM.TextChanged += OnPINChanged;
            this.InputPIN5VM.TextChanged += OnPINChanged;
            this.InputPIN6VM.TextChanged += OnPINChanged;
        }

        public void OnClearPIN()
        {
            this.PIN1 = this.PIN2 = this.PIN3 = this.PIN4 = this.PIN5 = this.PIN6 = "";
        }

        private void OnPINChanged(InputTextVM item)
        {
            if (!this.IsValid) return;
            if (this.Completed != null) this.Completed(this.Entity);
        }
    }
}
