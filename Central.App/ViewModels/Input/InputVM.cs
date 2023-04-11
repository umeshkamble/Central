using Input = Central.App.Models.Input;

namespace Central.App.ViewModels
{
    public class InputVM<E> : PanelVM<E> where E : Input, IInput
    {
        #region Properties
        public override E Entity
        {
            set {
                if (value is null) return;

                var entity = value;
                base.Entity = entity;

                this.IsRun = false;
                this.TextHint1 = entity.TextHint1;
                this.TextHint2 = entity.TextHint2;
                this.TextHelper = entity.TextHelper;
                this.Icon = entity.Icon;
                this.FontAttributes = FontAttributes.Bold;
                this.IsReadOnly = entity.IsReadOnly;
                this.IsFocus = entity.IsFocus;
                this.IsViewLine = entity.IsViewLine;
                this.IsRun = true;
            }
            get {
                var entity = base.Entity;
                entity.TextHint1 = this.TextHint1;
                entity.TextHint2 = this.TextHint2;
                entity.TextHelper = this.TextHelper;
                entity.Icon = this.Icon;
                entity.IsReadOnly = this.IsReadOnly;
                entity.IsFocus = this.IsFocus;
                return entity;
            }
        }

        private string TextHint1_;
        public string TextHint1
        {
            set {
                TextHint1_ = Base.ToString(value).Trim();
                this.IsViewTextHint1 = TextHint1_ == "" ? false : true;
                this.OnPropertyChanged();
            }
            get { return TextHint1_; }
        }

        private string TextHint2_;
        public string TextHint2
        {
            set
            {
                TextHint2_ = Base.ToString(value).Trim();
                this.IsViewTextHint2 = TextHint2_ == "" ? false : true;
                this.OnPropertyChanged();
            }
            get { return TextHint2_; }
        }

        private string TextHelper_;
        public string TextHelper
        {
            set { this.OnSetProperty(ref TextHelper_, value); }
            get { return TextHelper_; }
        }

        private string Icon_;
        public string Icon
        {
            set {
                Icon_ = Base.ToString(value).Trim();
                this.IsViewIcon = Icon_ == "" ? false : true;
                this.OnPropertyChanged();
            }
            get { return Icon_; }
        }

        private FontAttributes FontAttributes_;
        public FontAttributes FontAttributes
        {
            set { this.OnSetProperty(ref FontAttributes_, value); }
            get { return FontAttributes_; }
        }

        private bool IsFocus_;
        public bool IsFocus
        {
            get { return IsFocus_; }
            set { this.OnSetProperty(ref IsFocus_, value); }
        }

        private bool IsViewTextHint1_;
        public bool IsViewTextHint1
        {
            set { this.OnSetProperty(ref IsViewTextHint1_, value); }
            get { return IsViewTextHint1_; }
        }

        private bool IsViewTextHint2_;
        public bool IsViewTextHint2
        {
            set { this.OnSetProperty(ref IsViewTextHint2_, value); }
            get { return IsViewTextHint2_; }
        }

        private bool IsViewIcon_;
        public bool IsViewIcon
        {
            set { this.OnSetProperty(ref IsViewIcon_, value); }
            get { return IsViewIcon_; }
        }

        private bool IsViewLine_;
        public bool IsViewLine
        {
            set { this.OnSetProperty(ref IsViewLine_, value); }
            get { return IsViewLine_; }
        }

        public bool IsRun { get; set; }

        public override string Caption
        {
            get { return this.TextHint1; }
        }
        #endregion Properties

        public InputVM(E entity) : base(entity) { }
    }
}
