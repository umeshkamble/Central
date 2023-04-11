namespace Central.App.ViewModels
{
    public class SortGrupListVM : PanelGrupListVM<SortListVM, SortVM, Sort>
    {
        public SortGrupListVM(SelectionEnum selectionenum) : base(selectionenum) { }
        protected override IEnumerable<IGrouping<string, Sort>> GetGroupBy(List<Sort> entitys)
        {
            return entitys.GroupBy(g => g.Group);
        }

        protected override SortListVM OnGetPanelList()
        {
            return new SortListVM(new List<TemplateEnum>() { TemplateEnum.Grid }, this.SelectionEnum);
        }
    }
}
