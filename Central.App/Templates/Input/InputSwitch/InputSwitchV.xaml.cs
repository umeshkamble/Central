namespace Central.App.Templates;

public partial class InputSwitchV : InputSwitchT
{
	public InputSwitchV()
	{
		InitializeComponent();
	}

    protected override void SetFocus()
    {
        this.switch1.Focus();
        base.SetFocus();
    }
}