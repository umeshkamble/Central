namespace Central.App.Templates;

public partial class InputText4V : InputTextT
{
	public InputText4V()
	{
		InitializeComponent();
	}

    protected override void SetFocus()
    {
        this.entry1.Focus();
        base.SetFocus();
    }
}