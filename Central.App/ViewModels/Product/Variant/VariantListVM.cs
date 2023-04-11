using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Central.App.ViewModels
{
    public class VariantListVM : PanelListVM<VariantVM, Variant>
    {
        #region Properties
        public override bool IsValid
        {
            get {
                try {
                    if (this.ItemCount <= 0) throw new Exception("Anda mesti menambahkan varian terlebih dahulu !");
                }
                catch (Exception ex) {
                    if (ex.Message != "") this.OnLog(ex);
                    return false;
                }
                return base.IsValid;
            }
        }
        #endregion Properties 

        #region Event
        public delegate void VariantEventHandler(VariantVM vm);
        public event VariantEventHandler VariantEdit, VariantDelete;
        #endregion Event

        public VariantListVM(List<TemplateEnum> ts, SelectionEnum selectionenum, PanelEnum panelenum) : base(ts, selectionenum, panelenum, "Variant", false) { }
        protected override Task<VariantVM> OnInsertAsync(Variant entity, PanelEnum panelenum, int no, ImageSource imagesource, VariantVM item)
        {
            item = new VariantVM(entity,panelenum, no, imagesource);
            item.VariantEdit += this.OnVariantEdit;
            item.VariantDelete += this.OnVariantDelete;

            return base.OnInsertAsync(entity, panelenum, no, imagesource, item);
        }

        public void OnVariantEdit(VariantVM vm)
        {
            if (this.VariantEdit != null) this.VariantEdit(vm);
        }

        public void OnVariantDelete(VariantVM vm)
        {
            if (this.VariantDelete != null) this.VariantDelete(vm);
        }

    }
}
