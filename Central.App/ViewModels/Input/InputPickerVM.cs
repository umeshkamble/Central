using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Central.App.ViewModels
{
    public class InputPickerVM : InputVM<InputPicker>
    {
        #region Properties
        public override InputPicker Entity
        {
            set {
                if (value is null) return;

                var entity = value;
                base.Entity = entity;

                this.IsRun = false;
                this.Text = entity.Text;
                this.IsRun = true;
            }
            get {
                var entity = base.Entity;
                entity.Text = this.Text;
                return entity;
            }
        }

        private string Text_;
        public string Text
        {
            set { this.OnSetProperty(ref Text_, value); }
            get { return Text_; }
        }

        private string Icon2_;
        public string Icon2
        {
            set { this.OnSetProperty(ref Icon2_, value); }
            get { return Icon2_; }
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
        public Command PickerChangedCommand { get; set; }
        #endregion Command

        public InputPickerVM(InputPicker entity, string entityname) : base(entity) 
        {
            this.EntityName = entityname;
            this.Icon2 = IconFont.AngleRight;
        }

        protected override async void OnIdChanged()
        {
            base.OnIdChanged();
            if (!this.IsRun) return;

            this.IsRun = false;
            var text = "";
            try {
                var name = this.EntityName;
                var dbname = this.DbName;
                var db = Base.GetDb(name, dbname);

                var ids = Base.ToList(this.Id, ',');
                switch (name)
                {

                    case nameof(Store):
                        {
                            foreach (var id in ids)
                            {
                                var r = await ((StoreService)db).Get(id);
                                if (r is null) continue;

                                if (text != "") text += ", ";
                                text += r.Nama;
                            }
                            break;
                        }

                    case nameof(Kas): {
                            foreach (var id in ids) {
                                var r = await ((KasService)db).Get(id);
                                if (r is null) continue;

                                if (text != "") text += ", ";
                                text += r.Nama;
                            }
                            break;
                        }
                    case nameof(Bank): {
                            foreach (var id in ids) {
                                var r = await ((BankService)db).Get(id);
                                if (r is null) continue;

                                if (text != "") text += ", ";
                                text += r.Nama;
                            }
                            break;
                        }

                    case nameof(QRIS):
                        {
                            foreach (var id in ids)
                            {
                                var r = await ((QRISService)db).Get(id);
                                if (r is null) continue;

                                if (text != "") text += ", ";
                                text += r.Nama;
                            }
                            break;
                        }

                    case nameof(City): {
                            foreach (var id in ids) {
                                var r = await ((CityService)db).Get(id);
                                if (r is null) continue;

                                if (text != "") text += ", ";
                                text += r.Nama;
                            }
                            break;
                        }

                    case nameof(Suplier): {
                            foreach (var id in ids) {
                                var r = await ((SuplierService)db).Get(id);
                                if (r is null) continue;

                                if (text != "") text += ", ";
                                text += r.Nama;
                            }
                            break;
                        }

                    case nameof(Customer): {
                            foreach (var id in ids) {
                                var r = await ((CustomerService)db).Get(id);
                                if (r is null) continue;

                                if (text != "") text += ", ";
                                text += r.Nama;
                            }
                            break;
                        }

                    case nameof(Salesman): {
                            foreach (var id in ids) {
                                var r = await ((SalesmanService)db).Get(id);
                                if (r is null) continue;

                                if (text != "") text += ", ";
                                text += r.Nama;
                            }
                            break;
                        }

                    case nameof(Product):
                        {
                            foreach (var id in ids)
                            {
                                var r = await ((ProductService)db).Get(id);
                                if (r is null) continue;

                                if (text != "") text += ", ";
                                text += r.Nama;
                            }
                            break;
                        }

                    case nameof(ProductBrand):
                        {
                            foreach (var id in ids)
                            {
                                var r = await ((ProductBrandService)db).Get(id);
                                if (r is null) continue;

                                if (text != "") text += ", ";
                                text += r.Nama;
                            }
                            break;
                        }

                    case nameof(ProductCategory):
                        {
                            foreach (var id in ids)
                            {
                                var r = await ((ProductCategoryService)db).Get(id);
                                if (r is null) continue;

                                if (text != "") text += ", ";
                                text += r.Nama;
                            }
                            break;
                        }

                    case nameof(ProductWarehouse):
                        {
                            foreach (var id in ids)
                            {
                                var r = await ((ProductWarehouseService)db).Get(id);
                                if (r is null) continue;

                                if (text != "") text += ", ";
                                text += r.Nama;
                            }
                            break;
                        }



                }

            } catch { }

            this.Text = text;
            this.IsRun = true;
        }


        public override async void OnSelect()
        {
            var name = this.EntityName;
            var selectionenum = SelectionEnum.Single;
            switch (name) {
                case nameof(Store):
                    {
                        var vm = (PageStoreVM)AppShell2.GetVM(name, selectionenum);
                        vm.PickerSelectedChanged -= this.OnPickerSelectedChanged;
                        vm.PickerSelectedChanged += this.OnPickerSelectedChanged;
                        var page1 = (PageStoreV)AppShell2.GetPage(name, vm);

                        await Shell.Current.Navigation.PushAsync(page1);
                        break;
                    }

                case nameof(Kas): {
                        var vm = (PageKasVM)AppShell2.GetVM(name, selectionenum);
                        vm.PickerSelectedChanged -= this.OnPickerSelectedChanged;
                        vm.PickerSelectedChanged += this.OnPickerSelectedChanged;
                        var page1 = (PageKasV)AppShell2.GetPage(name, vm);
                        
                        await Shell.Current.Navigation.PushAsync(page1);
                        break;
                    }
                case nameof(Bank): {
                        var vm = (PageBankVM)AppShell2.GetVM(name, selectionenum);
                        vm.PickerSelectedChanged -= this.OnPickerSelectedChanged;
                        vm.PickerSelectedChanged += this.OnPickerSelectedChanged;
                        var page1 = (PageBankV)AppShell2.GetPage(name, vm);

                        await Shell.Current.Navigation.PushAsync(page1);
                        break;
                    }

                case nameof(QRIS):
                    {
                        var vm = (PageQRISVM)AppShell2.GetVM(name, selectionenum);
                        vm.PickerSelectedChanged -= this.OnPickerSelectedChanged;
                        vm.PickerSelectedChanged += this.OnPickerSelectedChanged;
                        var page1 = (PageQRISV)AppShell2.GetPage(name, vm);

                        await Shell.Current.Navigation.PushAsync(page1);
                        break;
                    }


                case nameof(Suplier): {
                        var vm = (PageSuplierVM)AppShell2.GetVM(name, selectionenum);
                        vm.PickerSelectedChanged -= this.OnPickerSelectedChanged;
                        vm.PickerSelectedChanged += this.OnPickerSelectedChanged;
                        var page1 = (PageSuplierV)AppShell2.GetPage(name, vm);

                        await Shell.Current.Navigation.PushAsync(page1);
                        break;
                    }
                case nameof(Customer): {
                        var vm = (PageCustomerVM)AppShell2.GetVM(name, selectionenum);
                        vm.PickerSelectedChanged -= this.OnPickerSelectedChanged;
                        vm.PickerSelectedChanged += this.OnPickerSelectedChanged;
                        var page1 = (PageCustomerV)AppShell2.GetPage(name, vm);

                        await Shell.Current.Navigation.PushAsync(page1);
                        break;
                    }

                case nameof(Salesman): {
                        var vm = (PageSalesmanVM)AppShell2.GetVM(name, selectionenum);
                        vm.PickerSelectedChanged -= this.OnPickerSelectedChanged;
                        vm.PickerSelectedChanged += this.OnPickerSelectedChanged;
                        var page1 = (PageSalesmanV)AppShell2.GetPage(name, vm);

                        await Shell.Current.Navigation.PushAsync(page1);
                        break;
                    }

                case nameof(Product): {
                        var vm = (PageProductVM)AppShell2.GetVM(name, selectionenum);
                        vm.PickerSelectedChanged -= this.OnPickerSelectedChanged;
                        vm.PickerSelectedChanged += this.OnPickerSelectedChanged;
                        var page1 = (PageProductV)AppShell2.GetPage(name, vm);

                        await Shell.Current.Navigation.PushAsync(page1);
                        break;
                    }

                case nameof(ProductBrand): {
                        var vm = (PageProductBrandVM)AppShell2.GetVM(name, selectionenum);
                        vm.PickerSelectedChanged -= this.OnPickerSelectedChanged;
                        vm.PickerSelectedChanged += this.OnPickerSelectedChanged;
                        var page1 = (PageProductBrandV)AppShell2.GetPage(name, vm);

                        await Shell.Current.Navigation.PushAsync(page1);
                        break;
                    }

                case nameof(ProductCategory): {
                        var vm = (PageProductCategoryVM)AppShell2.GetVM(name, selectionenum);
                        vm.PickerSelectedChanged -= this.OnPickerSelectedChanged;
                        vm.PickerSelectedChanged += this.OnPickerSelectedChanged;
                        var page1 = (PageProductCategoryV)AppShell2.GetPage(name, vm);

                        await Shell.Current.Navigation.PushAsync(page1);
                        break;
                    }

                case nameof(ProductWarehouse): {
                        var vm = (PageProductWarehouseVM)AppShell2.GetVM(name, selectionenum);
                        vm.PickerSelectedChanged -= this.OnPickerSelectedChanged;
                        vm.PickerSelectedChanged += this.OnPickerSelectedChanged;
                        var page1 = (PageProductWarehouseV)AppShell2.GetPage(name, vm);

                        await Shell.Current.Navigation.PushAsync(page1);
                        break;
                    }


            }

            base.OnSelect();
        }

        private void OnPickerSelectedChanged(string idselecteds, string captionselecteds)
        {
            this.IsRun = false;
            this.Id = idselecteds;
            this.Text = captionselecteds;
            this.IsRun = true;
        }

        
    }
}
