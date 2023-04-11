using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Central.App.Templates
{
    public class VariantT : PanelV
    {
        public static readonly BindableProperty PnNamaProperty = BindableProperty.Create(nameof(PnNama), typeof(string), typeof(VariantT), string.Empty);
        public string PnNama
        {
            get => (string)GetValue(PnNamaProperty);
            set => SetValue(PnNamaProperty, value);
        }

        public static readonly BindableProperty PnDeskripsiProperty = BindableProperty.Create(nameof(PnDeskripsi), typeof(string), typeof(VariantT), string.Empty);
        public string PnDeskripsi
        {
            get => (string)GetValue(PnDeskripsiProperty);
            set => SetValue(PnDeskripsiProperty, value);
        }

        public static readonly BindableProperty PnInputVMProperty = BindableProperty.Create(nameof(PnInputVM), typeof(object), typeof(VariantT), null);
        public object PnInputVM
        {
            get => (object)GetValue(PnInputVMProperty);
            set => SetValue(PnInputVMProperty, value);
        }

        public static readonly BindableProperty PnInputNamaVMProperty = BindableProperty.Create(nameof(PnInputNamaVM), typeof(object), typeof(VariantT), null);
        public object PnInputNamaVM
        {
            get => (object)GetValue(PnInputNamaVMProperty);
            set => SetValue(PnInputNamaVMProperty, value);
        }

        public static readonly BindableProperty PnInputDeskripsiVMProperty = BindableProperty.Create(nameof(PnInputDeskripsiVM), typeof(object), typeof(VariantT), null);
        public object PnInputDeskripsiVM
        {
            get => (object)GetValue(PnInputDeskripsiVMProperty);
            set => SetValue(PnInputDeskripsiVMProperty, value);
        }
    }
}
