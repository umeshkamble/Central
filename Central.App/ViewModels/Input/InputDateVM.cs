using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Central.App.ViewModels
{
    public class InputDateVM : InputVM<InputDate>
    {
        #region Properties
        public override InputDate Entity
        {
            set {
                if (value is null) return;

                var entity = value;
                base.Entity = entity;

                this.IsRun = false;
                this.Value = entity.Value;
                this.ValueMin = entity.ValueMin;
                this.ValueMax = entity.ValueMax;
                this.IsRun = true;
            }
            get {
                var entity = base.Entity;
                entity.Value = this.Value;
                return entity;
            }
        }

        private DateTime Value_;
        public DateTime Value
        {
            set { this.OnSetProperty(ref Value_, value); }
            get { return Value_; }
        }

        private DateTime ValueMin_;
        public DateTime ValueMin
        {
            set { this.OnSetProperty(ref ValueMin_, ValueMin); }
            get { return ValueMin_; }
        }

        private DateTime ValueMax_;
        public DateTime ValueMax
        {
            set { this.OnSetProperty(ref ValueMax_, ValueMax); }
            get { return ValueMax_; }
        }

        public override bool IsValid
        {
            get { return true; }
        }      
        #endregion Properties

        #region Command
        public Command ValueChangedCommand { get; set; }
        #endregion Command

        #region Event
        public delegate void InputEventHandler(InputDateVM item);
        public event InputEventHandler ValueChanged;
        #endregion Event

        public InputDateVM(InputDate entity) : base(entity) { }
        protected override void OnInitEvent(InputDate entity, PanelEnum panelenum)
        {
            base.OnInitEvent(entity, panelenum);
            this.ValueChangedCommand = new Command(() => this.OnValueChanged());
        }
    
        protected virtual void OnValueChanged()
        {
            if (!this.IsRun) return;
            if (this.ValueChanged != null) this.ValueChanged(this);
        }
    }
}
