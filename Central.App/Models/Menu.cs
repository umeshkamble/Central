

namespace Central.App.Models
{
    public enum MenuEnum
    {
        NoAction,
        Menu,
        Back,
        Close,
        Export,
        Picker,
        Select,
        Scan,

        Add,
        Edit,
        Delete,
        Save,
        Print,
        Filter,
        Note,

        AddTrolly,
        AddVariant,
        AddExpeditionVariant,
        AddBankVariant,
        AddExpenseVariant,
        AddPayVariant,
        AddAddress,
        AddPhone,

        EditRate,
        EditClient,
        EditSuplier,
        EditCustomer,
        EditExpense,
        EditPayCash,
        EditPayBG,
        EditPayCek,
        EditPayTransferManual,
        EditPayTransferQRIS,

        EditDiscount,
        EditPay,
        SelectPay,
        Find,

        Min,
        Max,

        TemplateGrid,
        TemplateList,
        TemplateTable,

        ExpandRight,
        ExpandLeft,
        ExpandTop,
        ExpandBottom,

        CboFilter,
        CboLevelHrg,

        Search,
        SearchEnter,
        SearchDelay,

        PickerProduct,
        PickerProductCategory,
        PickerProductBrand,
        PickerCity,
        PickerSuplier,
        PickerCustomer,
        PickerCustomerCategory,
        PickerSalesman,

        ItemSelect,
        OpenStore
    }

    public interface IMenu
    { 
        MenuEnum MenuEnum { get; set; }
        string Icon { get; set; }
        string Text { get; set; }
    }

    public class Menu : EntityBase, IMenu
    {
        public MenuEnum MenuEnum { get; set; } = MenuEnum.Save;
        public string Icon { get; set; } = IconFont.Save;
        public string Text { get; set; } = "Save";
     
        public Menu(MenuEnum menuenum, string icon) : this(menuenum, icon, "") { }
        public Menu(MenuEnum menuenum, string icon, string text)
        {
            this.MenuEnum = menuenum;
            this.Icon = icon;
            this.Text = text;
        }
    }
}
