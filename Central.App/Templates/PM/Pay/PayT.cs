using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Central.App.Templates
{
    public class PayT : PanelV
    {
        public static readonly BindableProperty PnTglProperty = BindableProperty.Create(nameof(PnTgl), typeof(DateTime), typeof(PayT), DateTime.Now);
        public DateTime PnTgl
        {
            get => (DateTime)GetValue(PnTglProperty);
            set => SetValue(PnTglProperty, value);
        }

        public static readonly BindableProperty PnNamaProperty = BindableProperty.Create(nameof(PnNama), typeof(string), typeof(PayT), string.Empty);
        public string PnNama    
        {
            get => (string)GetValue(PnNamaProperty);
            set => SetValue(PnNamaProperty, value);
        }

        public static readonly BindableProperty PnNoReferensiProperty = BindableProperty.Create(nameof(PnNoReferensi), typeof(string), typeof(PayT), string.Empty);
        public string PnNoReferensi
        {
            get => (string)GetValue(PnNoReferensiProperty);
            set => SetValue(PnNoReferensiProperty, value);
        }

        public static readonly BindableProperty PnTotalProperty = BindableProperty.Create(nameof(PnTotal), typeof(double), typeof(PayT), (double)0);
        public double PnTotal
        {
            get => (double)GetValue(PnTotalProperty);
            set => SetValue(PnTotalProperty, value);
        }

        public static readonly BindableProperty PnDeskripsiProperty = BindableProperty.Create(nameof(PnDeskripsi), typeof(string), typeof(PayT), string.Empty);
        public string PnDeskripsi
        {
            get => (string)GetValue(PnDeskripsiProperty);
            set => SetValue(PnDeskripsiProperty, value);
        }

        public static readonly BindableProperty PnDeskripsi2Property = BindableProperty.Create(nameof(PnDeskripsi2), typeof(string), typeof(PayT), string.Empty);
        public string PnDeskripsi2
        {
            get => (string)GetValue(PnDeskripsi2Property);
            set => SetValue(PnDeskripsi2Property, value);
        }
    }
}
