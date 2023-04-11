
namespace Central.App.ViewModels
{
    public class KeywordListVM : PanelListVM<KeywordVM, Keyword>
    {
        #region Properties
        private bool IsViewKeyword_;
        public bool IsViewKeyword
        {
            set { this.OnSetProperty(ref IsViewKeyword_, value); }
            get { return IsViewKeyword_; }
        }
        #endregion Properties

        public KeywordListVM(List<TemplateEnum> ts, SelectionEnum selectionenum, PanelEnum panelenum, bool isviewkeyword) : base(ts, selectionenum, panelenum, nameof(Keyword),false)
        {
            this.IsViewKeyword = isviewkeyword;
        }

        protected override Task<KeywordVM> OnInsertAsync(Keyword entity, PanelEnum panelenum, int no, ImageSource imagesource, KeywordVM item)
        {
            item = new KeywordVM(entity, panelenum, no, imagesource);
            return base.OnInsertAsync(entity, panelenum, no, imagesource, item);
        }
    }
}
