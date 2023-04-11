
using Contact = Central.Library.Contact;

namespace Central.App.ViewModels
{
    public class PageTREditVM<HVM,H,DVMList,DVM,D,C> : PageMasterEditVM<HVM, H>   where HVM : TRVM<H,DVMList,DVM,D,C>
                                                                                  where H : TR<D>
                                                                                  where DVMList : TRDetailListVM<DVM,D>
                                                                                  where DVM : TRDetailVM<D>
                                                                                  where D : TRDetail
                                                                                  where C : Contact
    {

        #region Properties
        public ContentProductListVM ContentListVM { get; set; }

        private double TotalTransaksi_;
        public virtual double TotalTransaksi
        {
            set { this.OnSetProperty(ref TotalTransaksi_, value); }
            get { return TotalTransaksi_; }
        }

        private string Icon2_;
        public virtual string Icon2
        {
            set { this.OnSetProperty(ref Icon2_, value); }
            get { return Icon2_; }
        }
        #endregion Properties

        public PageTREditVM()  
        {
            this.Icon2 = IconFont.AngleRight;
            this.ContentListVM = new ContentProductListVM();
            this.ContentListVM.MenuSelectedChanged += this.OnMenuSelect;
            this.ContentListVM.SelectedChanged += ((item) => {
                //----jika Device.Phone/Tablet, maka lgs munculkan perintahkan TRVM utk AddDetailCommand----//
                if (this.IsDevicePhone) {
                    this.IsExpandList = false;
                    this.OnMenuSelect(MenuEnum.Add);
                }
            });
            this.ContentListVM.ActionChanged += ((item) => {
                if (this.IsDeviceDesktop) {
                    //---------hanya berlaku utk desktop-------------//
                    this.OnMenuSelect(MenuEnum.Add);
                }
            });
        }

        protected override Task<List<Task>> OnLoadFirstAsync(List<Task> tasks)
        {
            tasks.Add(this.ContentListVM.OnLoadAsync());
            return base.OnLoadFirstAsync(tasks);
        }

        protected override HVM OnGetEditVM(HVM vm)
        {
            vm.HSumChanged += ((hsum) => this.TotalTransaksi = hsum.GrandTotal);
            vm.Add += ((dvm) => {
                this.IsExpandList = true;
            });
            vm.Edit += (async(dvm) => {
                var d = dvm.Entity;
                await this.OnEditAsync(d.Id_Product, d, false);
            });
            vm.Delete += (async (dvm) => {
                var isok = await this.OnAlert("Konfirmasi", $"Anda ingin hapus produk ini ?\nProduk : {dvm.Nama}", "Yakin", "Batal");
                if (!isok) return;

                await this.OnDeleteAsync(dvm);
            });

            return base.OnGetEditVM(vm);
        }

        public override async void OnMenuSelect(MenuEnum menu)
        {
            switch (menu){
                case MenuEnum.Add: {
                        var vm = this.ContentListVM.ItemSelectedFirst;
                        await this.OnEditAsync(vm.Id, null, true);
                        break;
                    }
                default: base.OnMenuSelect(menu);break;
            }
        }

        private async Task OnEditAsync(string id_product, D detail, bool isnew)
        {
            this.IsBusy = true;
            await ((HVM)this.EditVM).OnEditAsync(id_product, detail, isnew);
            this.IsBusy = false;
        }

        private async Task OnDeleteAsync(DVM dvm)
        {
            await ((HVM)this.EditVM).OnDeleteAsync(dvm);
        }
    }
}
