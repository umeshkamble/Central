namespace Central.App.ViewModels
{
    public class VariantGrupListVM : PanelGrupListVM<VariantListVM, VariantVM, Variant>
    {
        #region Properties
        private List<string> VariantItems_;
        public List<string> VariantItems
        {
            set {
                if (value is null) return;

                VariantItems_ = value;
                this.OnVariantSelect(VariantItems_);
            }
            get {
                var variantitems = new List<string>();
                var variants = this.EntitySelecteds;
                foreach (var v in variants) {
                    variantitems.Add(v.Nama);
                }

                return variantitems;
            }
        }
        #endregion Properties

        public VariantGrupListVM(SelectionEnum selectionenum) : base(selectionenum) { }
        public async Task OnLoadByProductAsync(Product p)
        {
            var variants = p.Variants;
            var entitys = new List<Variant>();
            foreach (var v in variants) {
                var id = v.Id;
                foreach (var text in v.VariantItems) {
                    entitys.Add(new Variant() { Id = id, Nama = text });
                }
            }
            await this.OnInsertAsync(entitys, true);
        }

        protected override IEnumerable<IGrouping<string, Variant>> GetGroupBy(List<Variant> entitys)
        {
            return entitys.GroupBy(g => g.Id);
        }

        protected override VariantListVM OnGetPanelList()
        {
            return new VariantListVM(new List<TemplateEnum>() { TemplateEnum.Grid }, this.SelectionEnum, PanelEnum.GridList);
        }

        private async void OnVariantSelect(List<string> variantitems) 
        {
            try {
                var tasks = new List<Task>();
                for (int i = 0; i < variantitems.Count; i++) {
                    var text = variantitems[i];
                    var vmlist = this.Items[i];
                    tasks.Add(this.OnVariantSelect(vmlist, text));
                }
                await Task.WhenAll(tasks);
            }
            catch { }
        }

        private async Task OnVariantSelect(VariantListVM vmlist, string text)
        {
            var vm = vmlist.Items.AsEnumerable().Where(x => x.Nama.Equals(text)).FirstOrDefault();
            if (vm != null) vmlist.OnSelect(vm);
            await Task.FromResult(true);
        }
    }
}


