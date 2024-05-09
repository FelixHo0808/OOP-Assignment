using MainPage.Models;

namespace MainPage
{
    public partial class App : Application
    {
        public static UserInfo UserInfo;
        public App()
        {
            InitializeComponent();

            MainPage = new AppShell();
        }
    }
}
