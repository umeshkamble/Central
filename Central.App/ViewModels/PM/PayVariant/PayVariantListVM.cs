

namespace Central.App.ViewModels
{
    public class PayVariantListVM : PanelListVM<PayVariantVM, PayVariant>
    {
        #region Properties
        public double Bayar
        {
            get { return this.Items.AsEnumerable().Sum(x => x.Total); }
        }

        private bool IsEditPay { get; set; } = false;
        private bool IsRun { get; set; } = true;
        #endregion Properties

        #region Command
        public Command DeleteByNamaCommand { get; set; }
        #endregion Command

        #region Event
        public delegate void PayVariantEventHandler(double bayar);
        public event PayVariantEventHandler BayarChanged;
        #endregion Event

        public PayVariantListVM(List<TemplateEnum> ts, SelectionEnum selectionenum, PanelEnum panelenum, bool incall, bool iseditpay) : base(ts, selectionenum, panelenum, nameof(PayVariant), incall) 
        {
            this.IsEditPay = iseditpay;
            this.DeleteByNamaCommand = new Microsoft.Maui.Controls.Command<string>((string nama) => {
                var item = this.Items.AsEnumerable().Where(x => x.Nama.Equals(nama)).FirstOrDefault();
                if (item != null) this.DeleteOneCommand.Execute(item);
            });
        }

        public async Task OnLoadAllAsync()
        {
            var entitys = await ((PayVariantService)this.Db).GetAllAsync();
            await this.OnInsertAsync(entitys, true);
        }

        public void OnSelect(List<PayVariant> pvs)
        { 
            this.OnClearSelected();
            foreach (var pv in pvs) {
                this.OnSelect(pv.Id, false);
            }
        }

        protected override Task<PayVariantVM> OnInsertAsync(PayVariant entity, PanelEnum panelenum, int no, ImageSource imagesource, PayVariantVM item)
        {
            var iseditpay = this.IsEditPay;
            var nama = entity.Nama.Replace(" ", "").Replace("-", "").ToLower().Trim();
            if (nama.Contains("kas") || nama == "bg" || nama == "cek") nama = "kas";
            imagesource = $"{nama}.png";

            item = new PayVariantVM(entity, panelenum, no, imagesource, iseditpay);
            item.Changed += (() => this.OnBayarChanged());
            return base.OnInsertAsync(entity, panelenum, no, imagesource, item);
        }

        public override void OnClear()
        {
            base.OnClear();
            this.OnBayarChanged();
        }
        protected override void OnInsert(PayVariantVM item)
        {
            base.OnInsert(item);
            this.OnBayarChanged();
        }
        protected override void OnUpdate(PayVariant entity)
        {
            base.OnUpdate(entity);
            this.OnBayarChanged();
        }
        protected override void OnDelete(PayVariantVM item)
        {
            base.OnDelete(item);
            this.OnBayarChanged();
        }
        protected void OnBayarChanged()
        {
            if (!this.IsRun) return;
            if (this.BayarChanged != null) this.BayarChanged(this.Bayar);
        }

        public PSum OnTotalReset(PSum psum)
        {
            this.IsRun = false;
            psum = new PSum(psum, 0); var sisa = psum.Sisa;
            psum = new PSum(psum, sisa);
            for (int i = 0; i < this.Items.Count; i++) {
                var item = this.Items[i];
                var pays = item.Pays;

                foreach (var pay in pays) {
                    pay.Total = i == 0 ? sisa : 0;
                }

                item.OnRefresh();
            }
            this.IsRun = true;
            return psum;
        }
        
        protected override async Task OnLoadFinishedAsync()
        {
            //---ketika load selesai, masukkan entity default----//
            if (this.IncAll){
                await this.OnInsertAsync(new PayVariant { 
                    Id = "Semua",
                    Nama = "Semua"
                });
            }

            await base.OnLoadFinishedAsync();
        }
    }

}
