using System.Windows.Input;
namespace Central.App.Templates;

public partial class PanelV : ContentView
{
    public View Body
    {
        get => ContentBody;
        set => ContentBody.Content = value;
    }

    public static readonly BindableProperty PnBackgroundColorProperty = BindableProperty.Create(nameof(PnBackgroundColor), typeof(Color), typeof(PanelV), null);
    public Color PnBackgroundColor
    {
        get => (Color)GetValue(PnBackgroundColorProperty);
        set => SetValue(PnBackgroundColorProperty, value);
    }

    public static readonly BindableProperty PnBorderColorProperty = BindableProperty.Create(nameof(PnBorderColor), typeof(Color), typeof(PanelV), null);
    public Color PnBorderColor
    {
        get => (Color)GetValue(PnBorderColorProperty);
        set => SetValue(PnBorderColorProperty, value);
    }

    public static readonly BindableProperty PnTextColor1Property = BindableProperty.Create(nameof(PnTextColor1), typeof(Color), typeof(PanelV), null);
    public Color PnTextColor1
    {
        get => (Color)GetValue(PnTextColor1Property);
        set => SetValue(PnTextColor1Property, value);
    }

    public static readonly BindableProperty PnTextColor2Property = BindableProperty.Create(nameof(PnTextColor2), typeof(Color), typeof(PanelV), null);
    public Color PnTextColor2
    {
        get => (Color)GetValue(PnTextColor2Property);
        set => SetValue(PnTextColor2Property, value);
    }

    public static readonly BindableProperty PnTextColor3Property = BindableProperty.Create(nameof(PnTextColor3), typeof(Color), typeof(PanelV), null);
    public Color PnTextColor3
    {
        get => (Color)GetValue(PnTextColor3Property);
        set => SetValue(PnTextColor3Property, value);
    }

    public static readonly BindableProperty PnMarginProperty = BindableProperty.Create(nameof(PnMargin), typeof(Thickness), typeof(PanelV), null);
    public Thickness PnMargin
    {
        get => (Thickness)GetValue(PnMarginProperty);
        set => SetValue(PnMarginProperty, value);
    }

    public static readonly BindableProperty PnPaddingProperty = BindableProperty.Create(nameof(PnPadding), typeof(Thickness), typeof(PanelV), null);
    public Thickness PnPadding
    {
        get => (Thickness)GetValue(PnPaddingProperty);
        set => SetValue(PnPaddingProperty, value);
    }

    public static readonly BindableProperty PnIdProperty = BindableProperty.Create(nameof(PnId), typeof(string), typeof(PanelV), string.Empty);
    public string PnId
    {
        get => (string)GetValue(PnIdProperty);
        set => SetValue(PnIdProperty, value);
    }

    public static readonly BindableProperty PnNoProperty = BindableProperty.Create(nameof(PnNo), typeof(int), typeof(PanelV), 1);
    public int PnNo
    {
        get => (int)GetValue(PnNoProperty);
        set => SetValue(PnNoProperty, value);
    }

    public static readonly BindableProperty PnTitle1Property = BindableProperty.Create(nameof(PnTitle1), typeof(string), typeof(PanelV), string.Empty);
    public string PnTitle1
    {
        get => (string)GetValue(PnTitle1Property);
        set => SetValue(PnTitle1Property, value);
    }

    public static readonly BindableProperty PnTitle2Property = BindableProperty.Create(nameof(PnTitle2), typeof(string), typeof(PanelV), string.Empty);
    public string PnTitle2
    {
        get => (string)GetValue(PnTitle2Property);
        set => SetValue(PnTitle2Property, value);
    }

    public static readonly BindableProperty PnImageSourceProperty = BindableProperty.Create(nameof(PnImageSource), typeof(ImageSource), typeof(PanelV), default(ImageSource));
    public ImageSource PnImageSource
    {
        get => (ImageSource)GetValue(PnImageSourceProperty);
        set => SetValue(PnImageSourceProperty, value);
    }

    public static readonly BindableProperty PnSelectedProperty = BindableProperty.Create(nameof(PnSelected), typeof(bool), typeof(PanelV), false);
    public bool PnSelected
    {
        get => (bool)GetValue(PnSelectedProperty);
        set => SetValue(PnSelectedProperty, value);
    }

    public static readonly BindableProperty PnVisibleProperty = BindableProperty.Create(nameof(PnVisible), typeof(bool), typeof(PanelV), false);
    public bool PnVisible
    {
        get => (bool)GetValue(PnVisibleProperty);
        set => SetValue(PnVisibleProperty, value);
    }

    public static readonly BindableProperty PnReadOnlyProperty = BindableProperty.Create(nameof(PnReadOnly), typeof(bool), typeof(PanelV), false);
    public bool PnReadOnly
    {
        get => (bool)GetValue(PnReadOnlyProperty);
        set => SetValue(PnReadOnlyProperty, value);
    }


    public static readonly BindableProperty PnViewTitle1Property = BindableProperty.Create(nameof(PnViewTitle1), typeof(bool), typeof(PanelV), false);
    public bool PnViewTitle1
    {
        get => (bool)GetValue(PnViewTitle1Property);
        set => SetValue(PnViewTitle1Property, value);
    }

    public static readonly BindableProperty PnViewTitle2Property = BindableProperty.Create(nameof(PnViewTitle2), typeof(bool), typeof(PanelV), false);
    public bool PnViewTitle2
    {
        get => (bool)GetValue(PnViewTitle2Property);
        set => SetValue(PnViewTitle2Property, value);
    }

    public static readonly BindableProperty PnImageStyleProperty = BindableProperty.Create(nameof(PnImageStyle), typeof(Style), typeof(PanelV), null);
    public Style PnImageStyle
    {
        get => (Style)GetValue(PnImageStyleProperty);
        set => SetValue(PnImageStyleProperty, value);
    }

    public static readonly BindableProperty PnSelectCommandProperty = BindableProperty.Create(nameof(PnSelectCommand), typeof(ICommand), typeof(PanelV), null);
    public ICommand PnSelectCommand
    {
        get { return (ICommand)GetValue(PnSelectCommandProperty); }
        set { SetValue(PnSelectCommandProperty, value); }
    }

    public static readonly BindableProperty PnActionCommandProperty = BindableProperty.Create(nameof(PnActionCommand), typeof(ICommand), typeof(PanelV), null);
    public ICommand PnActionCommand
    {
        get { return (ICommand)GetValue(PnActionCommandProperty); }
        set { SetValue(PnActionCommandProperty, value); }
    }

    public PanelV()
	{
		InitializeComponent();
	}
}