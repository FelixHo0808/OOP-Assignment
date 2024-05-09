using MainPage.Models;
using MainPage.Services;
using MainPage.ViewModels;
using MainPage.Views;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace MainPage.ViewModels
{
    public partial class BaseViewModel : ObservableObject
    {

        [ObservableProperty]
        public bool _isBusy;
        [ObservableProperty]
        public string _title;
    }
}
