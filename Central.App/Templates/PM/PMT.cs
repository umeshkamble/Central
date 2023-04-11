using System.Globalization;

namespace Central.App.Templates
{
    public class PMT : PanelV
    {
        public static readonly BindableProperty PnGrupProperty = BindableProperty.Create(nameof(PnGrup), typeof(EntityEnum), typeof(PMT), EntityEnum.PI);
        public EntityEnum PnGrup
        {
            get => (EntityEnum)GetValue(PnGrupProperty);
            set => SetValue(PnGrupProperty, value);
        }

        public static readonly BindableProperty PnModeProperty = BindableProperty.Create(nameof(PnMode), typeof(PMModeEnum), typeof(PMT), PMModeEnum.Out);
        public PMModeEnum PnMode
        {
            get => (PMModeEnum)GetValue(PnModeProperty);
            set => SetValue(PnModeProperty, value);
        }

        public static readonly BindableProperty PnTglProperty = BindableProperty.Create(nameof(PnTgl), typeof(DateTime), typeof(PMT), DateTime.Now);
        public DateTime PnTgl
        {
            get => (DateTime)GetValue(PnTglProperty);
            set => SetValue(PnTglProperty, value);
        }

        public static readonly BindableProperty PnNoReferensisProperty = BindableProperty.Create(nameof(PnNoReferensis), typeof(string), typeof(PMT), string.Empty);
        public string PnNoReferensis
        {
            get => (string)GetValue(PnNoReferensisProperty);
            set => SetValue(PnNoReferensisProperty, value);
        }

        public static readonly BindableProperty PnNamaProperty = BindableProperty.Create(nameof(PnNama), typeof(string), typeof(PMT), string.Empty);
        public string PnNama
        {
            get => (string)GetValue(PnNamaProperty);
            set => SetValue(PnNamaProperty, value);
        }

        public static readonly BindableProperty PnDeskripsiProperty = BindableProperty.Create(nameof(PnDeskripsi), typeof(string), typeof(PMT), string.Empty);
        public string PnDeskripsi
        {
            get => (string)GetValue(PnDeskripsiProperty);
            set => SetValue(PnDeskripsiProperty, value);
        }

        public static readonly BindableProperty PnPSumVMProperty = BindableProperty.Create(nameof(PnPSumVM), typeof(object), typeof(PMT), null);
        public object PnPSumVM
        {
            get => (object)GetValue(PnPSumVMProperty);
            set => SetValue(PnPSumVMProperty, value);
        }



    }
}


