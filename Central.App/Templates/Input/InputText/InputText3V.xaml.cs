namespace Central.App.Templates;

public partial class InputText3V : InputTextT
{
	public InputText3V()
	{
		InitializeComponent();
	}

    protected override void SetFocus()
    {
        this.entry1.Focus();
        base.SetFocus();
    }
}