using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Central.App.Templates
{
    public class PickerEnumV : Picker
    {
        public static readonly BindableProperty EnumTypeProperty =
            BindableProperty.Create(nameof(EnumType), typeof(Type), typeof(PickerEnumV),
                propertyChanged: (bindable, oldValue, newValue) =>
                {
                    PickerEnumV picker = (PickerEnumV)bindable;

                    if (oldValue != null) {
                        picker.ItemsSource = null;
                    }
                    if (newValue != null) {
                        if (!((Type)newValue).GetTypeInfo().IsEnum)
                            throw new ArgumentException("EnumPicker: EnumType property must be enumeration type");

                        picker.ItemsSource = Enum.GetValues((Type)newValue);
                    }
                });

        public Type EnumType
        {
            set => SetValue(EnumTypeProperty, value);
            get => (Type)GetValue(EnumTypeProperty);
        }
    }
}
