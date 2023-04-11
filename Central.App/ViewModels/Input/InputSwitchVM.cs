using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Central.App.ViewModels
{
    public class InputSwitchVM : InputVM<InputSwitch>
    {
        #region Properties
        public override InputSwitch Entity
        {
            set {
                if (value is null) return;

                var entity = value;
                base.Entity = entity;

                this.IsRun = false;
                this.IsOn = entity.IsOn;
                this.IsRun = true;
            }
            get {
                var entity = base.Entity;
                entity.IsOn = this.IsOn;
                return entity;
            }
        }

        private bool IsOn_;
        public bool IsOn
        {
            set { this.OnSetProperty(ref IsOn_, value); }
            get { return IsOn_; }
        }

        public override bool IsValid
        {
            get {
                //---tambahkan jika ada validasi----//
                return true;
            }
        }
        #endregion Properties

        #region Command
        public Command CheckedChangedCommand { get; set; }
        #endregion Command

        #region Event
        public delegate void SwitchEventHandler(bool ison);
        public event SwitchEventHandler CheckedChanged;
        #endregion Event

        public InputSwitchVM(InputSwitch entity) : base(entity) { }
        protected override void OnInitEvent(InputSwitch entity, PanelEnum panelenum)
        {
            base.OnInitEvent(entity,panelenum);
            this.CheckedChangedCommand = new Command(() => this.OnCheckedChanged());
        }
        
        protected virtual void OnCheckedChanged()
        {
            if (!this.IsRun) return;
            if (this.CheckedChanged != null) this.CheckedChanged(this.IsOn);
        }
    }
}
