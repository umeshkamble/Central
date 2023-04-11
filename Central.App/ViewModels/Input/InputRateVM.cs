using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Central.App.ViewModels
{
    public class InputRateVM : InputVM<InputRate>
    {
        #region Properties
        public override InputRate Entity
        {
            set {
                if (value is null) return;

                var entity = value;
                base.Entity = entity;

                this.IsRun = false;
                this.Rate = entity.Rate;
                this.IsRun = true;
            }
            get {
                var entity = base.Entity;
                entity.Rate = this.Rate;
                return entity;
            }
        }

        public RateVM RateVM { get; set; }

        private Rate Rate_;
        public Rate Rate
        {
            set {
                if (value is null) return;

                Rate_ = value;
                this.RateVM.Entity = Rate_;
            }
            get { return this.RateVM.Entity; }
        }

        public override bool IsValid
        {
            get {
                if (!this.RateVM.IsValid) return false;
                return true;
            }
        }
        #endregion Properties

        #region Event
        public delegate void RateEventHandler(Rate rate);
        public event RateEventHandler RateChanged;
        #endregion Event

        public InputRateVM(InputRate entity) : base(entity) { }
        protected override void OnInitInput(InputRate entity, PanelEnum panelenum)
        {
            base.OnInitInput(entity, panelenum);
            this.RateVM = new RateVM(PanelEnum.GridList, true);
            this.RateVM.RateChanged += ((rate) => {
                if (this.RateChanged != null) this.RateChanged(rate);
            });
        }
        
        protected virtual void OnRateChanged()
        {
            if (!this.IsRun) return;
            if (this.RateChanged != null) this.RateChanged(this.Rate);
        }
    }
}
