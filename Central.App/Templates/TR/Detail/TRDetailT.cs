using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Central.App.Templates
{
    public class TRDetailT : PanelV
    {
        public static readonly BindableProperty PnNamaProperty = BindableProperty.Create(nameof(PnNama), typeof(string), typeof(TRDetailT), string.Empty);
        public string PnNama
        {
            get => (string)GetValue(PnNamaProperty);
            set => SetValue(PnNamaProperty, value);
        }

        public static readonly BindableProperty PnHrgNormalProperty = BindableProperty.Create(nameof(PnHrgNormal), typeof(double), typeof(TRDetailT), (double)0);
        public double PnHrgNormal
        {
            get => (double)GetValue(PnHrgNormalProperty);
            set => SetValue(PnHrgNormalProperty, value);
        }

        public static readonly BindableProperty PnHrgPublishProperty = BindableProperty.Create(nameof(PnHrgPublish), typeof(double), typeof(TRDetailT), (double)0);
        public double PnHrgPublish
        {
            get => (double)GetValue(PnHrgPublishProperty);
            set => SetValue(PnHrgPublishProperty, value);
        }

        public static readonly BindableProperty PnTotalDiskonProperty = BindableProperty.Create(nameof(PnTotalDiskon), typeof(double), typeof(TRDetailT), (double)0);
        public double PnTotalDiskon
        {
            get => (double)GetValue(PnTotalDiskonProperty);
            set => SetValue(PnTotalDiskonProperty, value);
        }

        public static readonly BindableProperty PnStokProperty = BindableProperty.Create(nameof(PnStok), typeof(double), typeof(TRDetailT), (double)0);
        public double PnStok
        {
            get => (double)GetValue(PnStokProperty);
            set => SetValue(PnStokProperty, value);
        }

        public static readonly BindableProperty PnUnitProperty = BindableProperty.Create(nameof(PnUnit), typeof(string), typeof(TRDetailT), string.Empty);
        public string PnUnit
        {
            get => (string)GetValue(PnUnitProperty);
            set => SetValue(PnUnitProperty, value);
        }

        public static readonly BindableProperty PnDeskripsiProperty = BindableProperty.Create(nameof(PnDeskripsi), typeof(string), typeof(TRDetailT), string.Empty);
        public string PnDeskripsi
        {
            get => (string)GetValue(PnDeskripsiProperty);
            set => SetValue(PnDeskripsiProperty, value);
        }

        public static readonly BindableProperty PnVariantProperty = BindableProperty.Create(nameof(PnVariant), typeof(string), typeof(TRDetailT), string.Empty);
        public string PnVariant
        {
            get => (string)GetValue(PnVariantProperty);
            set => SetValue(PnVariantProperty, value);
        }

        public static readonly BindableProperty PnNoteProperty = BindableProperty.Create(nameof(PnNote), typeof(string), typeof(TRDetailT), string.Empty);
        public string PnNote
        {
            get => (string)GetValue(PnNoteProperty);
            set => SetValue(PnNoteProperty, value);
        }

        public static readonly BindableProperty PnTotalWeightProperty = BindableProperty.Create(nameof(PnTotalWeight), typeof(double), typeof(TRDetailT), (double)0);
        public double PnTotalWeight
        {
            get => (double)GetValue(PnTotalWeightProperty);
            set => SetValue(PnTotalWeightProperty, value);
        }

        public static readonly BindableProperty PnTotalVolumeProperty = BindableProperty.Create(nameof(PnTotalVolume), typeof(double), typeof(TRDetailT), (double)0);
        public double PnTotalVolume
        {
            get => (double)GetValue(PnTotalVolumeProperty);
            set => SetValue(PnTotalVolumeProperty, value);
        }

        public static readonly BindableProperty PnWarehouseProperty = BindableProperty.Create(nameof(PnWarehouse), typeof(string), typeof(TRDetailT), string.Empty);
        public string PnWarehouse
        {
            get => (string)GetValue(PnWarehouseProperty);
            set => SetValue(PnWarehouseProperty, value);
        }

        public static readonly BindableProperty PnQtyProperty = BindableProperty.Create(nameof(PnQty), typeof(double), typeof(TRDetailT), (double)0);
        public double PnQty
        {
            get => (double)GetValue(PnQtyProperty);
            set => SetValue(PnQtyProperty, value);
        }

        public static readonly BindableProperty PnHrgProperty = BindableProperty.Create(nameof(PnHrg), typeof(double), typeof(TRDetailT), (double)0);
        public double PnHrg
        {
            get => (double)GetValue(PnHrgProperty);
            set => SetValue(PnHrgProperty, value);
        }

        public static readonly BindableProperty PnTotalProperty = BindableProperty.Create(nameof(PnTotal), typeof(double), typeof(TRDetailT), (double)0);
        public double PnTotal
        {
            get => (double)GetValue(PnTotalProperty);
            set => SetValue(PnTotalProperty, value);
        }

        public static readonly BindableProperty PnDiskonProperty = BindableProperty.Create(nameof(PnDiskon), typeof(double), typeof(TRDetailT), (double)0);
        public double PnDiskon
        {
            get => (double)GetValue(PnDiskonProperty);
            set => SetValue(PnDiskonProperty, value);
        }

        public static readonly BindableProperty PnViewNoteProperty = BindableProperty.Create(nameof(PnViewNote), typeof(bool), typeof(TRDetailT), false);
        public bool PnViewNote
        {
            get => (bool)GetValue(PnViewNoteProperty);
            set => SetValue(PnViewNoteProperty, value);
        }

        public static readonly BindableProperty PnViewNoteInputProperty = BindableProperty.Create(nameof(PnViewNoteInput), typeof(bool), typeof(TRDetailT), false);
        public bool PnViewNoteInput
        {
            get => (bool)GetValue(PnViewNoteInputProperty);
            set => SetValue(PnViewNoteInputProperty, value);
        }

        public static readonly BindableProperty PnViewVariantProperty = BindableProperty.Create(nameof(PnViewVariant), typeof(bool), typeof(TRDetailT), false);
        public bool PnViewVariant
        {
            get => (bool)GetValue(PnViewVariantProperty);
            set => SetValue(PnViewVariantProperty, value);
        }

        public static readonly BindableProperty PnViewDetailProperty = BindableProperty.Create(nameof(PnViewDetail), typeof(bool), typeof(TRDetailT), false);
        public bool PnViewDetail
        {
            get => (bool)GetValue(PnViewDetailProperty);
            set => SetValue(PnViewDetailProperty, value);
        }

        public static readonly BindableProperty PnViewDiskonProperty = BindableProperty.Create(nameof(PnViewDiskon), typeof(bool), typeof(TRDetailT), false);
        public bool PnViewDiskon
        {
            get => (bool)GetValue(PnViewDiskonProperty);
            set => SetValue(PnViewDiskonProperty, value);
        }

        public static readonly BindableProperty PnViewPPNProperty = BindableProperty.Create(nameof(PnViewPPN), typeof(bool), typeof(TRDetailT), false);
        public bool PnViewPPN
        {
            get => (bool)GetValue(PnViewPPNProperty);
            set => SetValue(PnViewPPNProperty, value);
        }

        public static readonly BindableProperty PnInputQtyVMProperty = BindableProperty.Create(nameof(PnInputQtyVM), typeof(object), typeof(TRDetailT), null);
        public object PnInputQtyVM
        {
            get => (object)GetValue(PnInputQtyVMProperty);
            set => SetValue(PnInputQtyVMProperty, value);
        }

        public static readonly BindableProperty PnInputNoteVMProperty = BindableProperty.Create(nameof(PnInputNoteVM), typeof(object), typeof(TRDetailT), null);
        public object PnInputNoteVM
        {
            get => (object)GetValue(PnInputNoteVMProperty);
            set => SetValue(PnInputNoteVMProperty, value);
        }

        public static readonly BindableProperty PnMenuMinVMProperty = BindableProperty.Create(nameof(PnMenuMinVM), typeof(object), typeof(TRDetailT), null);
        public object PnMenuMinVM
        {
            get => (object)GetValue(PnMenuMinVMProperty);
            set => SetValue(PnMenuMinVMProperty, value);
        }

        public static readonly BindableProperty PnMenuMaxVMProperty = BindableProperty.Create(nameof(PnMenuMaxVM), typeof(object), typeof(TRDetailT), null);
        public object PnMenuMaxVM
        {
            get => (object)GetValue(PnMenuMaxVMProperty);
            set => SetValue(PnMenuMaxVMProperty, value);
        }

        public static readonly BindableProperty PnMenuNoteVMProperty = BindableProperty.Create(nameof(PnMenuNoteVM), typeof(object), typeof(TRDetailT), null);
        public object PnMenuNoteVM
        {
            get => (object)GetValue(PnMenuNoteVMProperty);
            set => SetValue(PnMenuNoteVMProperty, value);
        }

        public static readonly BindableProperty PnMenuExpandVMProperty = BindableProperty.Create(nameof(PnMenuExpandVM), typeof(object), typeof(TRDetailT), null);
        public object PnMenuExpandVM
        {
            get => (object)GetValue(PnMenuExpandVMProperty);
            set => SetValue(PnMenuExpandVMProperty, value);
        }

        public static readonly BindableProperty PnVariantGrupListVMProperty = BindableProperty.Create(nameof(PnVariantGrupListVM), typeof(object), typeof(TRDetailT), null);
        public object PnVariantGrupListVM
        {
            get => (object)GetValue(PnVariantGrupListVMProperty);
            set => SetValue(PnVariantGrupListVMProperty, value);
        }

        public static readonly BindableProperty PnRateListVMProperty = BindableProperty.Create(nameof(PnRateListVM), typeof(object), typeof(TRDetailT), null);
        public object PnRateListVM
        {
            get => (object)GetValue(PnRateListVMProperty);
            set => SetValue(PnRateListVMProperty, value);
        }

        public static readonly BindableProperty PnRateVMProperty = BindableProperty.Create(nameof(PnRateVM), typeof(object), typeof(TRDetailT), null);
        public object PnRateVM
        {
            get => (object)GetValue(PnRateVMProperty);
            set => SetValue(PnRateVMProperty, value);
        }

        public static readonly BindableProperty PnProductWarehouseListVMProperty = BindableProperty.Create(nameof(PnProductWarehouseListVM), typeof(object), typeof(TRDetailT), null);
        public object PnProductWarehouseListVM
        {
            get => (object)GetValue(PnProductWarehouseListVMProperty);
            set => SetValue(PnProductWarehouseListVMProperty, value);
        }

    }
}
