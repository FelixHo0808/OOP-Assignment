using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MainPage.Models;
using MainPage.Services;
using MainPage.UserControl;
using MainPage.Views;
//using Microsoft.Toolkit.Mvvm.ComponentModel;
//using Microsoft.Toolkit.Mvvm.Input;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace MainPage.ViewModels
{
    public partial class LoginPageViewModel : BaseViewModel
    {
        private readonly ILoginRespository _loginRespository;

        [ObservableProperty]
        private string _userName;

        [ObservableProperty]
        private string _password;

        public LoginPageViewModel(ILoginRespository loginRespository)
        {
            _loginRespository = loginRespository;
        }


        [RelayCommand(AllowConcurrentExecutions = false)]
        public async Task Login()
        {
            if (!string.IsNullOrWhiteSpace(UserName) && !string.IsNullOrWhiteSpace(Password))
            {
                UserInfo userInfo = await _loginRespository.Login(UserName, Password);

                if (Preferences.ContainsKey(nameof(App.UserInfo)))
                {
                    Preferences.Remove(nameof(App.UserInfo));
                }

                string userDetails = JsonConvert.SerializeObject(userInfo);
                Preferences.Set(nameof(App.UserInfo), userDetails);
                App.UserInfo = userInfo;

                AppShell.Current.FlyoutHeader = new FlyOutHeaderControl();

                await Shell.Current.GoToAsync($"//{nameof(HomePage)}");
            }
        }
    }
}
