using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Central.App.Templates
{
    public class ProductVariantT : PanelV
    {
        public static readonly BindableProperty PnInputVariantVMProperty = BindableProperty.Create(nameof(PnInputVariantVM), typeof(object), typeof(ProductVariantT), null);
        public object PnInputVariantVM
        {
            get => (object)GetValue(PnInputVariantVMProperty);
            set => SetValue(PnInputVariantVMProperty, value);
        }

        public static readonly BindableProperty PnInputQtyVMProperty = BindableProperty.Create(nameof(PnInputQtyVM), typeof(object), typeof(ProductVariantT), null);
        public object PnInputQtyVM
        {
            get => (object)GetValue(PnInputQtyVMProperty);
            set => SetValue(PnInputQtyVMProperty, value);
        }

        public static readonly BindableProperty PnInputRateEceranVMProperty = BindableProperty.Create(nameof(PnInputRateEceranVM), typeof(object), typeof(ProductVariantT), null);
        public object PnInputRateEceranVM
        {
            get => (object)GetValue(PnInputRateEceranVMProperty);
            set => SetValue(PnInputRateEceranVMProperty, value);
        }

        public static readonly BindableProperty PnInputRateAppVMProperty = BindableProperty.Create(nameof(PnInputRateAppVM), typeof(object), typeof(ProductVariantT), null);
        public object PnInputRateAppVM
        {
            get => (object)GetValue(PnInputRateAppVMProperty);
            set => SetValue(PnInputRateAppVMProperty, value);
        }

        public static readonly BindableProperty PnInputRateModalVMProperty = BindableProperty.Create(nameof(PnInputRateModalVM), typeof(object), typeof(ProductVariantT), null);
        public object PnInputRateModalVM
        {
            get => (object)GetValue(PnInputRateModalVMProperty);
            set => SetValue(PnInputRateModalVMProperty, value);
        }

        public static readonly BindableProperty PnInputNoBarcodeVMProperty = BindableProperty.Create(nameof(PnInputNoBarcodeVM), typeof(object), typeof(ProductVariantT), null);
        public object PnInputNoBarcodeVM
        {
            get => (object)GetValue(PnInputNoBarcodeVMProperty);
            set => SetValue(PnInputNoBarcodeVMProperty, value);
        }

        public static readonly BindableProperty PnInputWeightVMProperty = BindableProperty.Create(nameof(PnInputWeightVM), typeof(object), typeof(ProductVariantT), null);
        public object PnInputWeightVM
        {
            get => (object)GetValue(PnInputWeightVMProperty);
            set => SetValue(PnInputWeightVMProperty, value);
        }

        public static readonly BindableProperty PnInputDimensionPVMProperty = BindableProperty.Create(nameof(PnInputDimensionPVM), typeof(object), typeof(ProductVariantT), null);
        public object PnInputDimensionPVM
        {
            get => (object)GetValue(PnInputDimensionPVMProperty);
            set => SetValue(PnInputDimensionPVMProperty, value);
        }

        public static readonly BindableProperty PnInputDimensionLVMProperty = BindableProperty.Create(nameof(PnInputDimensionLVM), typeof(object), typeof(ProductVariantT), null);
        public object PnInputDimensionLVM
        {
            get => (object)GetValue(PnInputDimensionLVMProperty);
            set => SetValue(PnInputDimensionLVMProperty, value);
        }

        public static readonly BindableProperty PnInputDimensionTVMProperty = BindableProperty.Create(nameof(PnInputDimensionTVM), typeof(object), typeof(ProductVariantT), null);
        public object PnInputDimensionTVM
        {
            get => (object)GetValue(PnInputDimensionTVMProperty);
            set => SetValue(PnInputDimensionTVMProperty, value);
        }
    }
}
