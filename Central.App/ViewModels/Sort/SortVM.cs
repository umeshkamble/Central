namespace Central.App.ViewModels
{
    public class SortVM : PanelVM<Sort>
    {
        #region Properties
        public override Sort Entity
        {
            set {
                var entity = value;
                base.Entity = entity;

                this.Text = entity.Caption;
            }
            get => base.Entity;
        }

        public string Text { get; set; }
        public override string Caption
        {
            get { return this.Text; }
        }
        #endregion Properties

        public SortVM(Sort entity, PanelEnum panelenum, int no, ImageSource imagesource) : base(entity, panelenum, no, imagesource) { }
    }
}
