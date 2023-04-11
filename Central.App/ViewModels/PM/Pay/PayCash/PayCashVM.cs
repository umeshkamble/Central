
namespace Central.App.ViewModels
{
    public class PayCashVM : PayVM<PayCash>, IPayCash
    {
        public PayCashVM(PanelEnum panelenum) : this(null, panelenum, 1, null) { }
        public PayCashVM(PayCash entity, PanelEnum panelenum, int no, ImageSource imagesource) : base(entity, panelenum, no, imagesource) { }
    }
}
