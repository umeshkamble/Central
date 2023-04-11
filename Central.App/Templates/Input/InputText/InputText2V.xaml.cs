namespace Central.App.Templates;

public partial class InputText2V : InputTextT
{
	public InputText2V()
	{
		InitializeComponent();
	}

    protected override void SetFocus()
    {
        this.entry1.Focus();
        base.SetFocus();
    }
}