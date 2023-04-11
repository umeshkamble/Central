namespace Central.App.Templates;

public partial class InputText1V : InputTextT
{
	public InputText1V()
	{
		InitializeComponent();
	}

    protected override void SetFocus()
    {
        this.entry1.Focus();
        base.SetFocus();
    }
}