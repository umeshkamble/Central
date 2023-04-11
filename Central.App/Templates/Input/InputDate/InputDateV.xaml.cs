namespace Central.App.Templates;

public partial class InputDateV : InputDateT
{
	public InputDateV()
	{
		InitializeComponent();
	}

    protected override void SetFocus()
    {
        this.date1.Focus();
        base.SetFocus();
    }
}