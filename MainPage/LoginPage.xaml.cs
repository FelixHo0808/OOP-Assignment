using MainPage.ViewModels;

namespace MainPage;

public partial class LoginPage : ContentPage
{
	public LoginPage(LoginPageViewModel loginPageViewModel)
    {
        InitializeComponent();
        this.BindingContext = loginPageViewModel;
    }
}