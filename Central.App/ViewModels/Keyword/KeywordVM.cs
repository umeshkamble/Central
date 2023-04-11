namespace Central.App.ViewModels
{
    public class KeywordVM : PanelVM<Keyword>
    {
        #region Properties
        public override Keyword Entity 
        {
            set {
                var entity = value;
                base.Entity = entity;

                this.Text = entity.Text;
            }
            get => base.Entity; 
        }

        private string Text_;
        public string Text
        {
            set { this.OnSetProperty(ref Text_, value); }
            get { return Text_; }
        }

        public override string Caption
        {
            get { return this.Text; }
        }
        #endregion Properties

        public KeywordVM(Keyword entity, PanelEnum panelenum, int no, ImageSource imagesource) : base(entity,panelenum, no, imagesource) { }
    }
}
