using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Central.App.ViewModels
{
    public class PIListVM : TRListVM<PIVM,PI,PIDetailListVM,PIDetailVM,PIDetail,Suplier>
    {
        public PIListVM(List<TemplateEnum> ts, SelectionEnum selectionenum, PanelEnum panelenum, bool incall) : base(ts, selectionenum, panelenum, incall) { }
        protected override Task<PIVM> OnInsertAsync(PI entity, PanelEnum panelenum, int no, ImageSource imagesource, PIVM item)
        {
            item = new PIVM(entity, panelenum, no, imagesource);
            return base.OnInsertAsync(entity, panelenum, no, imagesource, item);
        }

        protected override async Task OnLoadFinishedAsync()
        {
            //---ketika load selesai, masukkan entity default----//
            if (this.IncAll) {
                await this.OnInsertAsync(new PI {
                    Id = "Semua",
                    NamaClient = "Semua",
                    NoReferensi = "Semua"
                });
            }

            await base.OnLoadFinishedAsync();
        }
    }
}
