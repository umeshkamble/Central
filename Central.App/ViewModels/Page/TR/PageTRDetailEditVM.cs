
namespace Central.App.ViewModels
{

    public class PageTRDetailEditVM<DVM,D> : PageMasterEditVM<DVM, D> where DVM : TRDetailVM<D>
                                                                      where D : TRDetail
    {

      

        #region Properties
        private string Icon_;
        public virtual string Icon
        {
            set { this.OnSetProperty(ref Icon_, value); }
            get { return Icon_; }
        }
        #endregion Properties

        #region Command
        public Command SaveCommand { get; set; }
        #endregion Command

        public PageTRDetailEditVM()
        {
            this.Icon = IconFont.ArrowCircleRight;
            this.SaveEnum = SaveEnum.SaveTemp;
            this.SaveCommand = new Command(() => this.OnMenuSelect(MenuEnum.Save));
        }

        public async Task OnLoadAsync(Product p, HSum hsum, D entity, bool isnew)
        {
            this.Title1 = p.Nama;
            this.Title2 = "Trolly";
            await this.EditVM.OnLoadAsync(p, hsum, entity, isnew);
        }
    }
}
