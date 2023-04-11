
using Microsoft.Maui;

namespace Central.App.ViewModels
{
    public class InputTextVM : InputVM<InputText>
    {
        #region Properties
        public override InputText Entity
        {
            set {
                if (value is null) return;

                var entity = value;
                base.Entity = entity;

                this.IsRun = false;
                this.TextEnum = entity.TextEnum;
                this.Text = entity.Text;
                this.MaxLength = entity.MaxLength;
                this.IsTitleCase = entity.IsTitleCase;
                this.IsRun = true;
            }
            get {
                var entity = base.Entity;
                entity.TextEnum = this.TextEnum;
                entity.Text = this.Text;
                entity.MaxLength = this.MaxLength;
                entity.IsTitleCase = this.IsTitleCase;
                return entity;
            }
        }

        private TextEnum TextEnum_;
        public TextEnum TextEnum
        {
            set {
                TextEnum_ = value;

                var ta = TextAlignment.Start;
                var kb = Keyboard.Default;
                var ispassword = false;
                
                if (TextEnum_ == TextEnum.Number || TextEnum_ == TextEnum.NumberDecimal) {
                    ta = TextAlignment.End;
                    kb = Keyboard.Numeric;
                }
                else if (TextEnum_ == TextEnum.PIN || TextEnum_ == TextEnum.OTP) {
                    if (TextEnum_ == TextEnum.PIN) ispassword = true;
                    ta = TextAlignment.Center;
                    kb = Keyboard.Numeric;
                }
                else if (TextEnum_ == TextEnum.Email) kb = Keyboard.Email;
                else if (TextEnum_ == TextEnum.Phone) kb = Keyboard.Telephone;
                else if (TextEnum_ == TextEnum.NPWP) kb = Keyboard.Numeric;
                else if (TextEnum_ == TextEnum.Password) ispassword = true;

                this.TextAlignment = ta;
                this.Keyboard = kb;
                this.IsPassword = ispassword;
            }
            get {
                return TextEnum_;
            }
        }

        private string Text_;
        public string Text
        {
            set {
                string t = Base.ToString(value);
                if (this.IsFocus) {
                    if (this.TextEnum == TextEnum.Number || this.TextEnum == TextEnum.NumberDecimal) {
                        var val = Base.ToDouble(t);
                        t = val == 0 ? "" : val.ToString();
                    }
                    else if (this.TextEnum == TextEnum.Phone) t = t.Replace("-", "").Replace(" ","").Trim();
                    else if (this.TextEnum == TextEnum.Text) t = value;
                }
                else {
                    switch (this.TextEnum) {
                        case TextEnum.Number: t = Base.ToDouble(t).ToString("#,##0"); break;
                        case TextEnum.NumberDecimal: t = Base.ToDouble(t).ToString("#,##0.###"); break;
                        case TextEnum.Phone: t = Base.ToPhoneNumber(t); break;
                        case TextEnum.NPWP: t = Base.ToNPWP(t);break;
                        case TextEnum.Text: {
                                if (this.IsTitleCase) t = Base.ToTitleCase(t);
                                break;
                            }
                    }
                }

                Text_ = t;
                this.OnPropertyChanged();
            }
            get { return Text_; }
        }

        private TextAlignment TextAlignment_;
        public TextAlignment TextAlignment
        {
            set { this.OnSetProperty(ref TextAlignment_, value); }
            get { return TextAlignment_; }
        }

        private Keyboard Keyboard_;
        public Keyboard Keyboard
        {
            set { this.OnSetProperty(ref Keyboard_, value); }
            get { return Keyboard_; }
        }

        private int TextLength_;
        public int TextLength
        {
            set { this.OnSetProperty(ref TextLength_, value); }
            get { return Text.Length; }
        }

        private int MaxLength_;
        public int MaxLength
        {
            set { this.OnSetProperty(ref MaxLength_, value); }
            get { return MaxLength_; }
        }

        private bool IsPassword_;
        public bool IsPassword
        {
            set { this.OnSetProperty(ref IsPassword_, value); }
            get { return IsPassword_; }
        }

        private bool IsTitleCase_;
        public bool IsTitleCase
        {
            set { this.OnSetProperty(ref IsTitleCase_, value); }
            get { return IsTitleCase_; }
        }

        public override bool IsValid
        {
            get {
                try {
                    var text = this.Text.Trim();
                    var textenum = this.TextEnum;
                    var textlen = this.TextLength;

                    if (textenum == TextEnum.Number || textenum == TextEnum.NumberDecimal) {
                        var value = Base.ToDouble(text);
                        if (textenum == TextEnum.Number && value <= 0) throw new Exception("");
                        else if (textenum == TextEnum.NumberDecimal && value == 0) throw new Exception();
                    }
                    else if (textenum == TextEnum.Phone && textlen < 11) throw new Exception("");
                    else if (textenum == TextEnum.NPWP && textlen != 20) throw new Exception("");
                    else if (textenum == TextEnum.Password || textenum == TextEnum.PIN || textenum == TextEnum.OTP || textenum == TextEnum.Text) {
                        if (text == "") throw new Exception();
                    }
                }
                catch {
                    this.IsFocus = true;
                    return false;
                }
                return base.IsValid;
            }
        }
        #endregion Properties

        #region Command
        public Command TextChangedCommand { get; set; }
        public Command EnterCommand { get; set; }
        public Command LeaveCommand { get; set; }
        #endregion Command

        #region Event
        public delegate void InputEventHandler(InputTextVM item);
        public event InputEventHandler TextChanged, Enter, Leave;
        #endregion Event

        public InputTextVM(InputText entity) : base(entity) { }
        protected override void OnInitEvent(InputText entity, PanelEnum panelenum)
        {
            base.OnInitEvent(entity, panelenum);
            this.TextChangedCommand = new Command(() => this.OnTextChanged());
            this.EnterCommand = new Command(() => this.OnEnter());
            this.LeaveCommand = new Command(() => this.OnLeave());
        }
        
        protected virtual void OnTextChanged()
        {
            if (!this.IsRun) return;
            if (this.TextChanged != null) this.TextChanged(this);
        }

        protected virtual void OnEnter()
        {
            this.IsFocus = true;
            if (!this.IsRun) return;

            this.OnRefreshText();
            if (this.Enter != null) this.Enter(this);
        }

        protected virtual void OnLeave()
        {
            this.IsFocus = false;
            if (!this.IsRun) return;

            this.OnRefreshText();
            if (this.Leave != null) this.Leave(this);
        }

        public void OnRefreshText()
        {
            this.IsRun = false;
            this.Text = this.Text;
            this.IsRun = true;
        }

    }
}
