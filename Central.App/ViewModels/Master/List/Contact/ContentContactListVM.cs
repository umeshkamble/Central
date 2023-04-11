

using Contact = Central.Library.Contact;

namespace Central.App.ViewModels
{
    public class ContentContactListVM<CVMList,CVM,C> : ContentListVM<CVMList, CVM, C>
                                                            where CVMList : ContactListVM<CVM,C>
                                                            where CVM : ContactVM<C>
                                                            where C : Contact
    {
        public ContentContactListVM() : base(new List<TemplateEnum>() { TemplateEnum.List, TemplateEnum.Grid }) { }
        protected override async void OnCboChanged(string id)
        {
            string text = id;
            if (id == "Semua") text = id;
            else {
                var db = (CityService)Base.GetDb(nameof(City),this.DbName);
                var result = await db.Get(id);
                if (result != null) text = result.Nama;
            }

            //this.Title = text;
            base.OnCboChanged(id);
        }

    
    }
}
