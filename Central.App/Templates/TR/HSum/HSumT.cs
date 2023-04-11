using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Central.App.Templates
{
    public class HSumT : PanelV
    {
        public static readonly BindableProperty PnSubTotalProperty = BindableProperty.Create(nameof(PnSubTotal), typeof(double), typeof(HSumT), (double)0);
        public double PnSubTotal
        {
            get => (double)GetValue(PnSubTotalProperty);
            set => SetValue(PnSubTotalProperty, value);
        }

        public static readonly BindableProperty PnDiskonItemProperty = BindableProperty.Create(nameof(PnDiskonItem), typeof(double), typeof(HSumT), (double)0);
        public double PnDiskonItem
        {
            get => (double)GetValue(PnDiskonItemProperty);
            set => SetValue(PnDiskonItemProperty, value);
        }

        public static readonly BindableProperty PnDiskonFakturPersenProperty = BindableProperty.Create(nameof(PnDiskonFakturPersen), typeof(double), typeof(HSumT), (double)0);
        public double PnDiskonFakturPersen
        {
            get => (double)GetValue(PnDiskonFakturPersenProperty);
            set => SetValue(PnDiskonFakturPersenProperty, value);
        }

        public static readonly BindableProperty PnDiskonFakturProperty = BindableProperty.Create(nameof(PnDiskonFaktur), typeof(double), typeof(HSumT), (double)0);
        public double PnDiskonFaktur
        {
            get => (double)GetValue(PnDiskonFakturProperty);
            set => SetValue(PnDiskonFakturProperty, value);
        }

        public static readonly BindableProperty PnPPNProperty = BindableProperty.Create(nameof(PnPPN), typeof(double), typeof(HSumT), (double)0);
        public double PnPPN
        {
            get => (double)GetValue(PnPPNProperty);
            set => SetValue(PnPPNProperty, value);
        }

        public static readonly BindableProperty PnPPNPersenProperty = BindableProperty.Create(nameof(PnPPNPersen), typeof(double), typeof(HSumT), (double)0);
        public double PnPPNPersen
        {
            get => (double)GetValue(PnPPNPersenProperty);
            set => SetValue(PnPPNPersenProperty, value);
        }

        public static readonly BindableProperty PnBiayaProperty = BindableProperty.Create(nameof(PnBiaya), typeof(double), typeof(HSumT), (double)0);
        public double PnBiaya
        {
            get => (double)GetValue(PnBiayaProperty);
            set => SetValue(PnBiayaProperty, value);
        }

        public static readonly BindableProperty PnInputSwitchPpnVMProperty = BindableProperty.Create(nameof(PnInputSwitchPpnVM), typeof(object), typeof(HSumT), null);
        public object PnInputSwitchPpnVM
        {
            get => (object)GetValue(PnInputSwitchPpnVMProperty);
            set => SetValue(PnInputSwitchPpnVMProperty, value);
        }

        public static readonly BindableProperty PnIcon2Property = BindableProperty.Create(nameof(PnIcon2), typeof(object), typeof(HSumT), null);
        public object PnIcon2
        {
            get => (object)GetValue(PnIcon2Property);
            set => SetValue(PnIcon2Property, value);
        }

        public static readonly BindableProperty PnEditDiskonCommandProperty = BindableProperty.Create(nameof(PnEditDiskonCommand), typeof(ICommand), typeof(HSumT), null);
        public ICommand PnEditDiskonCommand
        {
            get { return (ICommand)GetValue(PnEditDiskonCommandProperty); }
            set { SetValue(PnEditDiskonCommandProperty, value); }
        }


        public static readonly BindableProperty PnInputSubTotalVMProperty = BindableProperty.Create(nameof(PnInputSubTotalVM), typeof(object), typeof(HSumT), null);
        public object PnInputSubTotalVM
        {
            get => (object)GetValue(PnInputSubTotalVMProperty);
            set => SetValue(PnInputSubTotalVMProperty, value);
        }

        public static readonly BindableProperty PnInputDiskonFakturPersenVMProperty = BindableProperty.Create(nameof(PnInputDiskonFakturPersenVM), typeof(object), typeof(HSumT), null);
        public object PnInputDiskonFakturPersenVM
        {
            get => (object)GetValue(PnInputDiskonFakturPersenVMProperty);
            set => SetValue(PnInputDiskonFakturPersenVMProperty, value);
        }

        public static readonly BindableProperty PnInputDiskonFakturVMProperty = BindableProperty.Create(nameof(PnInputDiskonFakturVM), typeof(object), typeof(HSumT), null);
        public object PnInputDiskonFakturVM
        {
            get => (object)GetValue(PnInputDiskonFakturVMProperty);
            set => SetValue(PnInputDiskonFakturVMProperty, value);
        }


    }
}
