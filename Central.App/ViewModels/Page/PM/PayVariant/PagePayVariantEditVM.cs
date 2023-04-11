
namespace Central.App.ViewModels
{
    public class PagePayVariantEditVM : PageMasterEditVM<PayVariantVM, PayVariant>
    {
        #region Properties
        public override PayVariant Entity 
        {
            set {
                if (value is null) return;
                var entity = value;
                base.Entity = entity;

                this.Nama = entity.Nama;
                this.Total = entity.Total;
            }
            get => base.Entity; 
        }

        private string Nama_;
        public string Nama
        {
            set {
                Nama_ = value;
                this.Title1 = Nama_;
                this.Title2 = "Edit";

                this.OnPropertyChanged();
            }
            get { return Nama_; }
        }

        private double Total_;
        public double Total
        {
            set { this.OnSetProperty(ref Total_, value); }
            get { return Total_; }
        }

        private string Icon2_;
        public string Icon2
        {
            set { this.OnSetProperty(ref Icon2_, value); }
            get { return Icon2_; }
        }
        #endregion Properties

        public PagePayVariantEditVM()
        {
            this.SaveEnum = SaveEnum.SaveTemp;
            this.Icon2 = IconFont.AngleRight;
            this.Title1 = "Tunai";
            this.Title2 = "Edit";
        }

        protected override List<Menu> OnGetMenusNav2(List<Menu> menus)
        {
            menus.Add(new Menu(MenuEnum.Add, IconFont.Plus));
            return base.OnGetMenusNav2(menus);
        }

        public override void OnMenuSelect(MenuEnum menu)
        {
            switch (menu) {
                case MenuEnum.Add: this.EditVM.OnMenuSelect(menu);break;
                default: base.OnMenuSelect(menu);break;
            }
        }

        protected override PayVariantVM OnGetEditVM(PayVariantVM vm)
        {
            vm = new PayVariantVM(PanelEnum.Edit1);
            vm.TotalChanged += ((total) => this.Total = total);
            return base.OnGetEditVM(vm);
        }
    }
}
