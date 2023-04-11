

namespace Central.App.ViewModels
{
    public class PayListVM<PVM,P> : PanelListVM<PVM, P> where PVM : PayVM<P>
                                                        where P : Pay
    {
        public double Total
        {
            get {
                try { 
                    var total = this.Entitys.AsEnumerable().Sum(x => x.Total);
                    return total;
                }
                catch { return 0; }
            }
        }

        #region Event
        public delegate void TotalEventHandler(double total);
        public event TotalEventHandler TotalChanged;
        #endregion Event  

        public PayListVM(List<TemplateEnum> ts, SelectionEnum selectionenum, PanelEnum panelenum, string tname, bool incall) : base(ts, selectionenum, panelenum, tname, incall) { }
        protected override async Task OnLoadFinishedAsync()
        {
            //---ketika load selesai, masukkan entity default----//
            if (this.IncAll) await this.OnInsertAsync(null);
            await base.OnLoadFinishedAsync();
        }

        protected override Task<PVM> OnInsertAsync(P entity, PanelEnum panelenum, int no, ImageSource imagesource, PVM item)
        {
            item.TotalChanged += (() => {
                if (this.TotalChanged != null) this.TotalChanged(this.Total);
            });
            return base.OnInsertAsync(entity, panelenum, no, imagesource, item);
        }

        protected virtual async void OnInsertAllAsync(P p)
        {
            if (p is null) return;
            await this.OnInsertAsync(p);
        }
    }

}
