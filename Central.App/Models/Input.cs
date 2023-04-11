using Central.Library;
using DnsClient.Protocol;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Central.App.Models
{
    public enum TextEnum
    { 
        Text,
        Number,
        NumberDecimal,
        Email,
        Phone,
        NPWP,
        Password,
        PIN,
        OTP
    }

    #region Input
    public interface IInput
    {
        string TextHint1 { get; set; }
        string TextHint2 { get; set; }
        string TextHelper { get; set; }
        string Icon { get; set; }

        bool IsViewLine { get; set; }
        bool IsReadOnly { get; set; }
        bool IsFocus { get; set; }
        bool IsValid { get; }
    }

    public class Input : EntityBase, IInput
    {
        public string TextHint1 { get; set; } = "";
        public string TextHint2 { get; set; } = "";
        public string TextHelper { get; set; } = "";
        public string Icon { get; set; } = "";

        public bool IsViewLine { get; set; } = true;
        public bool IsReadOnly { get; set; } = false;
        public bool IsFocus { get; set; } = false;
        public bool IsValid { get; }

        public Input(string texthint1, string texthint2, string texthelper, string icon)
        {
            this.TextHint1 = texthint1;
            this.TextHint2 = texthint2;
            this.TextHelper = texthelper;
            this.Icon = icon;
        }
    }
    #endregion Input

    #region InputText
    public interface IInputText : IInput
    {
        TextEnum TextEnum { get; set; }
        string Text { get; set; }
        int MaxLength { get; set; }
        
        bool IsPassword { get; set; }
        bool IsTitleCase { get; set; }
    }

    public class InputText : Input, IInputText
    {
        #region Properties
        public TextEnum TextEnum { get; set; } = TextEnum.Text;
        public string Text { get; set; } = "";
        public int MaxLength { get; set; } = 300;
        
        public bool IsPassword { get; set; } = false; 
        public bool IsTitleCase { get; set; } = true;
        #endregion properties

        public InputText(string texthint1) : this(texthint1, "", "") { }
        //public InputText(string texthint1, string texthint2) : this(texthint1, texthint2, "") { }
        public InputText(string texthint1, string texthint2, string texthelper) : this(texthint1, texthint2, texthelper, "") { }
        public InputText(string texthint1, string texthint2, string texthelper, string icon) : this(texthint1, texthint2, texthelper, icon, TextEnum.Text) { }
        public InputText(string texthint1, string texthint2, string texthelper, string icon, TextEnum textenum) : base(texthint1, texthint2, texthelper, icon)
        {
            this.TextEnum = textenum;
            if (texthelper.Trim() == "") {
                if (textenum == TextEnum.Number || textenum == TextEnum.NumberDecimal) texthelper = "0";
                else if (textenum == TextEnum.Phone) texthelper = "XXXX-XXXX-XXXX";
                else if (textenum == TextEnum.NPWP) texthelper = "XX.XXX.XXX.X-XXX.XXX";
                else if (textenum == TextEnum.Password) texthelper = "******";
                else if (textenum == TextEnum.Email) texthelper = "Enter Email...";
                else if (textenum == TextEnum.Text) texthelper = "...";
                this.TextHelper = texthelper;
            }
        }
    }
    #endregion InputText

    #region InputDate
    public interface IInputDate : IInput
    {
        DateTime Value { get; set; }
        DateTime ValueMin { get; set; }
        DateTime ValueMax { get; set; }
    }

    public class InputDate : Input, IInputDate
    {
        public DateTime Value { get; set; } = DateTime.Now;
        public DateTime ValueMin { get; set; } = DateTime.Now;
        public DateTime ValueMax { get; set; } = DateTime.Now;

        public InputDate(string texthint1) : this(texthint1, "","") { }
        //public InputDate(string texthint1, string texthint2) : this(texthint1, texthint2, "") { }
        public InputDate(string texthint1, string texthint2, string texthelper) : this(texthint1, texthint2, texthelper, 0, 0) { }
        public InputDate(string texthint1, string texthint2, string texthelper, int min, int max) : base(texthint1, texthint2, texthelper, IconFont.Calendar)
        {
            this.ValueMin = this.Value.AddDays(-min);
            this.ValueMax = this.Value.AddDays(max);
        }
    }
    #endregion InputDate

    #region InputSwitch
    public interface IInputSwitch
    {
        bool IsOn { get; set; }
    }

    public class InputSwitch : Input, IInputSwitch
    {
        public bool IsOn { get; set; } = false;

        public InputSwitch(string texthint1) : this(texthint1, "","") { }
        //public InputSwitch(string texthint1, string texthint2) : this(texthint1, texthint2, "") { }
        public InputSwitch(string texthint1, string texthint2, string texthelper) : this(texthint1, texthint2, texthelper, IconFont.Check) { }
        public InputSwitch(string texthint1, string texthint2, string texthelper, string icon) : this(texthint1, texthint2, texthelper, icon, false) { }
        public InputSwitch(string texthint1, string texthint2, string texthelper, string icon, bool ison) : base(texthint1,texthint2, texthelper, icon)
        {
            this.IsOn = ison;
        }
    }
    #endregion InputSwitch

    #region InputPicker
    public interface IInputPicker
    {
        string Text { get; set; }
    }
    public class InputPicker : Input, IInputPicker
    {
        public string Text { get; set; } = "";

        public InputPicker(string texthint1) : this(texthint1, "","") { }
        //public InputPicker(string texthint1, string texthint2) : this(texthint1, texthint2,"") { }
        public InputPicker(string texthint1, string texthint2, string texthelper) : this(texthint1, texthint2, texthelper, IconFont.Search) { }
        public InputPicker(string texthint1, string texthint2, string texthelper, string icon) : this(texthint1,texthint2, texthelper, icon, "", "") { }
        public InputPicker(string texthint1, string texthint2, string texthelper, string icon, string text, string id) : base(texthint1, texthint2, texthelper, icon)
        {
            this.Id = id;
            this.Text = Base.ToTitleCase(text); 
        }
    }
    #endregion InputPicker

    #region InputRate
    public interface IInputRate
    {
        Rate Rate { get; set; }
    }

    public class InputRate : Input, IInputRate
    {
        public Rate Rate { get; set; } = new Rate();

        public InputRate(string texthint1) : this(texthint1, "", "") { }
        //public InputRate(string texthint1, string texthint2) : this(texthint1, texthint2, "") { }
        public InputRate(string texthint1, string texthint2, string texthelper) : this(texthint1, texthint2, texthelper, IconFont.Percentage) { }
        public InputRate(string texthint1, string texthint2, string texthelper, string icon) : this(texthint1, texthint2, texthelper, icon, new Rate()) { }
        public InputRate(string texthint1, string texthint2, string texthelper, string icon, Rate rate) : base(texthint1, texthint2, texthelper, icon)
        {
            this.Rate = rate;
        }
    }
    #endregion InputRate
}
