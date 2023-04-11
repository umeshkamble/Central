

namespace Central.App.ViewModels
{
    public class RateListVM : PanelListVM<RateVM, Rate>
    {
        #region Properties
        private Rate Rate_;
        public Rate Rate
        {
            set {
                if (value is null) return;
                Rate_ = value;

                //---mencari apakah ada rate yang cocok---------------------------//
                var ismatch = false;
                foreach (var item in this.Items) {
                    if (item.Entity.Compare(Rate_)) {
                        this.OnSelect(item, false);
                        ismatch = true;
                        break;
                    }
                }

                //---jika tidak ketemu, maka anggap sebagai rate custom-----------//
                if (!ismatch) {
                    var item = this.Items.AsEnumerable().Where(x => x.Id.Contains("Custom")).FirstOrDefault();
                    if (item != null) {
                        item.Entity = Rate_;
                        this.OnSelect(item, false);
                    }
                }
            }
            get {
                return this.ItemSelectedFirst.Entity;
            }
        }

        private bool IncCustom { get; set; }
        #endregion Properties

        #region Event
        public delegate void RateEventHandler(Rate rate);
        public event RateEventHandler RateChanged;
        #endregion Event

        public RateListVM(List<TemplateEnum> ts, SelectionEnum selectionenum, PanelEnum panelenum, bool inccustom) : base(ts, selectionenum,panelenum, nameof(Rate), false) 
        {
            this.IncCustom = inccustom;
        }
 
        protected override Task<RateVM> OnInsertAsync(Rate entity,PanelEnum panelenum, int no, ImageSource imagesource, RateVM item)
        {
            item = new RateVM(entity, panelenum, no, imagesource, false);
            item.RateChanged += ((rate) => {
                if (this.RateChanged != null) this.RateChanged(rate);
            });
            return base.OnInsertAsync(entity, panelenum, no, imagesource, item);
        }

        protected override async Task OnLoadFinishedAsync()
        {
            //---ketika load selesai, masukkan entity default----//
            if (this.IncCustom) {
                await this.OnInsertAsync(new Rate {
                    Id = "Custom",
                    Deskripsi = "Custom",
                    RateMode = RateModeEnum.Custom
                });
            }

            await base.OnLoadFinishedAsync();
        }

    }

}
