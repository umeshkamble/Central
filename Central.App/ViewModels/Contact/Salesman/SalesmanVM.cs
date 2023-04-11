

namespace Central.App.ViewModels
{
    public class SalesmanVM : ContactVM<Salesman>
    {
        public SalesmanVM(PanelEnum panelenum) : this(null, panelenum, 1, null) { }
        public SalesmanVM(Salesman entity, PanelEnum panelenum, int no, ImageSource imagesource) : base(entity, panelenum, no, imagesource) { }
    }
}
