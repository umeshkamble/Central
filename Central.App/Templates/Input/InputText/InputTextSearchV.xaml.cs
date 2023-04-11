using System.Windows.Input;

namespace Central.App.Templates;

public partial class InputTextSearchV : InputTextT
{
    public static readonly BindableProperty PnSearchCommandProperty = BindableProperty.Create(nameof(PnSearchCommand), typeof(ICommand), typeof(InputTextSearchV), null);
    public ICommand PnSearchCommand
    {
        get { return (ICommand)GetValue(PnSearchCommandProperty); }
        set { SetValue(PnSearchCommandProperty, value); }
    }

    public static readonly BindableProperty PnSearchEnterCommandProperty = BindableProperty.Create(nameof(PnSearchEnterCommand), typeof(ICommand), typeof(InputTextSearchV), null);
    public ICommand PnSearchEnterCommand
    {
        get { return (ICommand)GetValue(PnSearchEnterCommandProperty); }
        set { SetValue(PnSearchEnterCommandProperty, value); }
    }

    public static readonly BindableProperty PnSearchDelayCommandProperty = BindableProperty.Create(nameof(PnSearchDelayCommand), typeof(ICommand), typeof(InputTextSearchV), null);
    public ICommand PnSearchDelayCommand
    {
        get { return (ICommand)GetValue(PnSearchDelayCommandProperty); }
        set { SetValue(PnSearchDelayCommandProperty, value); }
    }

    public InputTextSearchV()
	{
		InitializeComponent();
	}

    protected override void SetFocus()
    {
        this.entry1.Focus();
        base.SetFocus();
    }
}