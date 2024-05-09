using CommunityToolkit.Maui;
using MainPage.Services;
using MainPage.ViewModels;
using MainPage.Views;
using Microsoft.Extensions.Logging;

namespace MainPage
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .UseMauiCommunityToolkit()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

#if DEBUG
    		builder.Services.AddSingleton<HomePage>();
            builder.Services.AddSingleton<LoginPage>();
            builder.Services.AddSingleton<ContactPage>();
            builder.Services.AddSingleton<AboutPage>();

            builder.Services.AddTransient<LoginPageViewModel>();
            builder.Services.AddTransient<ILoginRespository, LoginRepository>();
#endif

            return builder.Build();
        }
    }
}
