using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Central.App.ViewModels
{
    public class ProductVariantListVM : PanelListVM<ProductVariantVM, ProductVariant>
    {
        #region Command
        public Command LoadByVariantCommand { get; set; }
        #endregion Command

        public ProductVariantListVM(List<TemplateEnum> ts, SelectionEnum selectionenum, PanelEnum panelenum) : base(ts, selectionenum,panelenum, "ProductVariant", false) 
        {
            this.LoadByVariantCommand = new Microsoft.Maui.Controls.Command<List<Variant>>(async(List<Variant> variants) => await this.OnLoadByVariants(variants));
        }

        private async Task OnLoadByVariants(List<Variant> variants)
        {
            var db = (ProductVariantService)Base.GetDb(nameof(ProductVariant));
            var productvariants = this.Entitys;
            productvariants =  await db.GetCombinationAsync(variants, productvariants);
            
            this.InsertCommand.Execute(productvariants);
        }

        protected override Task<ProductVariantVM> OnInsertAsync(ProductVariant entity, PanelEnum panelenum, int no, ImageSource imagesource, ProductVariantVM item)
        {
            item = new ProductVariantVM(entity, panelenum, no, imagesource);
            return base.OnInsertAsync(entity, panelenum, no, imagesource, item);
        }

    }
}
