using Microsoft.Extensions.Logging;
using CommunityToolkit.Maui;
using Microsoft.Extensions.Configuration;
using System.Reflection;
using CommonPizzaApp.Services;
using CommonPizzaApp.ViewModels;
using CommonPizzaApp.Pages;

namespace CommonPizzaApp
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            var assembly = Assembly.GetExecutingAssembly();

            using var stream = assembly.GetManifestResourceStream("CommonPizzaApp.appsettings.json");

            var config = new ConfigurationBuilder().AddJsonStream(stream).Build();

            builder.Configuration.AddConfiguration(config);
            builder.UseMauiApp<App>().ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
            }).UseMauiCommunityToolkit();


            builder.Services.AddSingleton<PizzaService>();
            builder.Services.AddSingletonWithShellRoute<HomePage,HomeViewModel>(nameof(HomePage));
            builder.Services.AddSingletonWithShellRoute<AllPizzasPage,AllPizzasViewModel>(nameof(AllPizzasPage));
#if DEBUG
            builder.Logging.AddDebug();
#endif
            return builder.Build();
        }
    }
}