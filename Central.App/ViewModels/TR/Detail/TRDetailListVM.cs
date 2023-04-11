

namespace Central.App.ViewModels
{
    public class TRDetailListVM<DVM,D> : PanelListVM<DVM, D> where DVM : TRDetailVM<D>
                                                             where D : TRDetail
    {

        #region Properties
        private HSum HSum_;
        public HSum HSum
        {
            set {
                if (value is null) return;
                
                //------perubahan HSum akan mempengaruhi perhitungan details-----//
                HSum_ = value;
                foreach (var vm in this.Items) {
                    vm.HSum = HSum_;
                }
            }
            get { return HSum_; }
        }
        #endregion Properties

        #region Command
        public Command LoadByDetailsCommand { get; set; }
        public Command InsertByDetailCommand { get; set; }
        #endregion Command

        #region Event
        public delegate void DetailEventHandler();
        public event DetailEventHandler DetailChanged;
        #endregion Event   

        public TRDetailListVM(List<TemplateEnum> ts, SelectionEnum selectionenum, PanelEnum panelenum, bool incall) : base(ts, selectionenum, panelenum, typeof(D).Name, incall)
        {
            this.LoadByDetailsCommand = new Microsoft.Maui.Controls.Command<List<D>>((List<D> details) => {
                this.InsertCommand.Execute(details);
            });

            this.InsertByDetailCommand = new Microsoft.Maui.Controls.Command<D>((D d) => {
                var item = this.Items.AsEnumerable().Where(x => x.Id_Product.Equals(d.Id_Product) &&
                                                                x.Id_Variant.Equals(d.Id_Variant) &&
                                                                x.Id_Warehouse.Equals(d.Id_Warehouse) &&
                                                                x.Rate.Compare(d.Rate)).FirstOrDefault();
                if (item is null) {
                    d.No = this.ItemCount + 1;
                    this.InsertOneCommand.Execute(d);
                }
                else {
                    this.OnSelect(item);
                    item.Qty += d.Qty;
                }
            });
        }

        protected override Task OnInsertedAsync(DVM item)
        {
            item.DetailChanged += (() => this.OnDetailChanged());
            return base.OnInsertedAsync(item);
        }

        public void OnDetailChanged()
        {
            if (this.DetailChanged != null) this.DetailChanged();
        }
    }

}
