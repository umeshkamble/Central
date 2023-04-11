namespace Central.App.ViewModels
{
    public class SortListVM : PanelListVM<SortVM, Sort>
    {
        public SortListVM(List<TemplateEnum> ts, SelectionEnum selectionenum) : base(ts, selectionenum, PanelEnum.GridList, nameof(Sort), false) { }
        protected override Task<SortVM> OnInsertAsync(Sort entity, PanelEnum panelenum, int no, ImageSource imagesource, SortVM item)
        {
            item = new SortVM(entity, panelenum, no, imagesource);
            return base.OnInsertAsync(entity, panelenum, no, imagesource, item);
        }
    }
}
