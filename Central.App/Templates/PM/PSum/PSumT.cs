using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Central.App.Templates
{
    public class PSumT : PanelV
    {
        public static readonly BindableProperty PnTagihanProperty = BindableProperty.Create(nameof(PnTagihan), typeof(double), typeof(PSumT), (double)0);
        public double PnTagihan
        {
            get => (double)GetValue(PnTagihanProperty);
            set => SetValue(PnTagihanProperty, value);
        }

        public static readonly BindableProperty PnPointProperty = BindableProperty.Create(nameof(PnPoint), typeof(double), typeof(PSumT), (double)0);
        public double PnPoint
        {
            get => (double)GetValue(PnPointProperty);
            set => SetValue(PnPointProperty, value);
        }

        public static readonly BindableProperty PnPromoProperty = BindableProperty.Create(nameof(PnPromo), typeof(double), typeof(PSumT), (double)0);
        public double PnPromo
        {
            get => (double)GetValue(PnPromoProperty);
            set => SetValue(PnPromoProperty, value);
        }

        public static readonly BindableProperty PnBayarProperty = BindableProperty.Create(nameof(PnBayar), typeof(double), typeof(PSumT), (double)0);
        public double PnBayar
        {
            get => (double)GetValue(PnBayarProperty);
            set => SetValue(PnBayarProperty, value);
        }

        public static readonly BindableProperty PnSisaProperty = BindableProperty.Create(nameof(PnSisa), typeof(double), typeof(PSumT), (double)0);
        public double PnSisa
        {
            get => (double)GetValue(PnSisaProperty);
            set => SetValue(PnSisaProperty, value);
        }

        public static readonly BindableProperty PnKembalianProperty = BindableProperty.Create(nameof(PnKembalian), typeof(double), typeof(PSumT), (double)0);
        public double PnKembalian
        {
            get => (double)GetValue(PnKembalianProperty);
            set => SetValue(PnKembalianProperty, value);
        }

        public static readonly BindableProperty PnSplitProperty = BindableProperty.Create(nameof(PnSplit), typeof(bool), typeof(PSumT), false);
        public bool PnSplit
        {
            get => (bool)GetValue(PnSplitProperty);
            set => SetValue(PnSplitProperty, value);
        }

        public static readonly BindableProperty PnIncludePointProperty = BindableProperty.Create(nameof(PnIncludePoint), typeof(bool), typeof(PSumT), false);
        public bool PnIncludePoint
        {
            get => (bool)GetValue(PnIncludePointProperty);
            set => SetValue(PnIncludePointProperty, value);
        }

        public static readonly BindableProperty PnPromoTextProperty = BindableProperty.Create(nameof(PnPromoText), typeof(string), typeof(PSumT), string.Empty);
        public string PnPromoText
        {
            get => (string)GetValue(PnPromoTextProperty);
            set => SetValue(PnPromoTextProperty, value);
        }

        public static readonly BindableProperty PnInputSwitchSplitVMProperty = BindableProperty.Create(nameof(PnInputSwitchSplitVM), typeof(object), typeof(PSumT), null);
        public object PnInputSwitchSplitVM
        {
            get => (object)GetValue(PnInputSwitchSplitVMProperty);
            set => SetValue(PnInputSwitchSplitVMProperty, value);
        }

        public static readonly BindableProperty PnInputSwitchPointVMProperty = BindableProperty.Create(nameof(PnInputSwitchPointVM), typeof(object), typeof(PSumT), null);
        public object PnInputSwitchPointVM
        {
            get => (object)GetValue(PnInputSwitchPointVMProperty);
            set => SetValue(PnInputSwitchPointVMProperty, value);
        }

        public static readonly BindableProperty PnInputPromoVMProperty = BindableProperty.Create(nameof(PnInputPromoVM), typeof(object), typeof(PSumT), null);
        public object PnInputPromoVM
        {
            get => (object)GetValue(PnInputPromoVMProperty);
            set => SetValue(PnInputPromoVMProperty, value);
        }
    }
}
