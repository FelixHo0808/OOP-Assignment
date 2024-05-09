namespace MainPage.UserControl;

public partial class FlyOutHeaderControl : ContentView
{
	public FlyOutHeaderControl()
	{
		InitializeComponent();
		if(App.UserInfo != null)
		{
			lblUserName.Text = "Logged in as: " + App.UserInfo.UserName;
			lblUserEmail.Text = App.UserInfo.UserName;//Set Email From API
		}
	}
}