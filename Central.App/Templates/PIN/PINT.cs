using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Central.App.Templates
{
    public class PINT : PanelV
    {
        public static readonly BindableProperty PnInputPIN1VMProperty = BindableProperty.Create(nameof(PnInputPIN1VM), typeof(object), typeof(PINT), null);
        public object PnInputPIN1VM
        {
            get => (object)GetValue(PnInputPIN1VMProperty);
            set => SetValue(PnInputPIN1VMProperty, value);
        }

        public static readonly BindableProperty PnInputPIN2VMProperty = BindableProperty.Create(nameof(PnInputPIN2VM), typeof(object), typeof(PINT), null);
        public object PnInputPIN2VM
        {
            get => (object)GetValue(PnInputPIN2VMProperty);
            set => SetValue(PnInputPIN2VMProperty, value);
        }
        
        public static readonly BindableProperty PnInputPIN3VMProperty = BindableProperty.Create(nameof(PnInputPIN3VM), typeof(object), typeof(PINT), null);
        public object PnInputPIN3VM
        {
            get => (object)GetValue(PnInputPIN3VMProperty);
            set => SetValue(PnInputPIN3VMProperty, value);
        }
        
        public static readonly BindableProperty PnInputPIN4VMProperty = BindableProperty.Create(nameof(PnInputPIN4VM), typeof(object), typeof(PINT), null);
        public object PnInputPIN4VM
        {
            get => (object)GetValue(PnInputPIN4VMProperty);
            set => SetValue(PnInputPIN4VMProperty, value);
        }
        
        public static readonly BindableProperty PnInputPIN5VMProperty = BindableProperty.Create(nameof(PnInputPIN5VM), typeof(object), typeof(PINT), null);
        public object PnInputPIN5VM
        {
            get => (object)GetValue(PnInputPIN5VMProperty);
            set => SetValue(PnInputPIN5VMProperty, value);
        }
        
        public static readonly BindableProperty PnInputPIN6VMProperty = BindableProperty.Create(nameof(PnInputPIN6VM), typeof(object), typeof(PINT), null);
        public object PnInputPIN6VM
        {
            get => (object)GetValue(PnInputPIN6VMProperty);
            set => SetValue(PnInputPIN6VMProperty, value);
        }       
    }
}
