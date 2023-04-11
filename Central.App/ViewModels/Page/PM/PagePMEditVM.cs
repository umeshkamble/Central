
namespace Central.App.ViewModels
{
    public class PagePMEditVM : PageMasterEditVM<PMVM, PM>
    {
        #region Properties
        private double Bayar_;
        public virtual double Bayar
        {
            set { this.OnSetProperty(ref Bayar_, value); }
            get { return Bayar_; }
        }

        private string Icon2_;
        public virtual string Icon2
        {
            set { this.OnSetProperty(ref Icon2_, value); }
            get { return Icon2_; }
        }
        #endregion Properties

        public PagePMEditVM()  
        {
            this.Icon2 = IconFont.AngleRight;
        }

        protected override PMVM OnGetEditVM(PMVM vm)
        {
            vm = new PMVM(PanelEnum.Edit1);
            vm.PSumChanged += ((psum) => this.Bayar = psum.Bayar);
            return base.OnGetEditVM(vm);
        }
    }
}


