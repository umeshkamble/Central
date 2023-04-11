namespace Central.App.Templates
{
    public class InputT : PanelV
    {
     
        public static readonly BindableProperty PnTextHint1Property = BindableProperty.Create(nameof(PnTextHint1), typeof(string), typeof(InputT), string.Empty);
        public string PnTextHint1
        {
            get => (string)GetValue(PnTextHint1Property);
            set => SetValue(PnTextHint1Property, value);
        }

        public static readonly BindableProperty PnTextHint2Property = BindableProperty.Create(nameof(PnTextHint2), typeof(string), typeof(InputT), string.Empty);
        public string PnTextHint2
        {
            get => (string)GetValue(PnTextHint2Property);
            set => SetValue(PnTextHint2Property, value);
        }

        public static readonly BindableProperty PnTextHelperProperty = BindableProperty.Create(nameof(PnTextHelper), typeof(string), typeof(InputT), string.Empty);
        public string PnTextHelper
        {
            get => (string)GetValue(PnTextHelperProperty);
            set => SetValue(PnTextHelperProperty, value);
        }

        public static readonly BindableProperty PnIconProperty = BindableProperty.Create(nameof(PnIcon), typeof(string), typeof(InputT), string.Empty);
        public string PnIcon
        {
            get => (string)GetValue(PnIconProperty);
            set => SetValue(PnIconProperty, value);
        }

        public static readonly BindableProperty PnFontAttributesProperty = BindableProperty.Create(nameof(PnFontAttributes), typeof(FontAttributes), typeof(InputT), FontAttributes.None);
        public FontAttributes PnFontAttributes
        {
            get => (FontAttributes)GetValue(PnFontAttributesProperty);
            set => SetValue(PnFontAttributesProperty, value);
        }

        public static readonly BindableProperty PnViewTextHint1Property = BindableProperty.Create(nameof(PnViewTextHint1), typeof(bool), typeof(InputT), false);
        public bool PnViewTextHint1
        {
            get => (bool)GetValue(PnViewTextHint1Property);
            set => SetValue(PnViewTextHint1Property, value);
        }

        public static readonly BindableProperty PnViewTextHint2Property = BindableProperty.Create(nameof(PnViewTextHint2), typeof(bool), typeof(InputT), false);
        public bool PnViewTextHint2
        {
            get => (bool)GetValue(PnViewTextHint2Property);
            set => SetValue(PnViewTextHint2Property, value);
        }

        public static readonly BindableProperty PnViewIconProperty = BindableProperty.Create(nameof(PnViewIcon), typeof(bool), typeof(InputT), false);
        public bool PnViewIcon
        {
            get => (bool)GetValue(PnViewIconProperty);
            set => SetValue(PnViewIconProperty, value);
        }

        public static readonly BindableProperty PnViewLineProperty = BindableProperty.Create(nameof(PnViewLine), typeof(bool), typeof(InputT), false);
        public bool PnViewLine
        {
            get => (bool)GetValue(PnViewLineProperty);
            set => SetValue(PnViewLineProperty, value);
        }

        public static readonly BindableProperty PnFocusProperty = BindableProperty.Create(nameof(PnFocus), typeof(bool), typeof(InputT), false, propertyChanged: OnFocusChanged);
        public bool PnFocus
        {
            get => (bool)GetValue(PnFocusProperty);
            set => SetValue(PnFocusProperty, value);
        }
        
        private static void OnFocusChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var control = (InputT)bindable;
            var isfocus = (bool)newValue;
            if (isfocus) control.SetFocus();
        }

        protected virtual void SetFocus()
        {

        }
    }
}
