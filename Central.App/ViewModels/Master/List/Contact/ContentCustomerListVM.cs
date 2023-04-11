

namespace Central.App.ViewModels
{
    public class ContentCustomerListVM : ContentContactListVM<CustomerListVM,CustomerVM,Customer>
    {
        public ContentCustomerListVM()  { }
        protected override CustomerListVM OnGetPanelList(List<TemplateEnum> ts)
        {
            var selectionenum = this.SelectionEnum;
            var panelenum = PanelEnum.GridList;
            return new CustomerListVM(ts, selectionenum,panelenum, false);
        }

        protected override void OnFilterSelect(Query<Customer> querycurr, PageFilterV page, PageFilterVM<Customer> vm)
        {
            //-----wajib di override-------//
            page = new PageFilterCustomerV();
            vm = new PageFilterCustomerVM(querycurr);
            vm.Execute += ((query) => {
                var db = (CustomerService)Base.GetDb(nameof(Customer));
                var keyword = db.GetFilterValue(query.Filters, FilterEnum.Keyword);
                var id_city = db.GetFilterValue(query.Filters, FilterEnum.City);

                this.CboId = id_city;
                this.Keyword = keyword;
                this.PanelListVM.LoadCommand.Execute(query);
            });

            base.OnFilterSelect(querycurr, page, vm);
        }

    }
}
