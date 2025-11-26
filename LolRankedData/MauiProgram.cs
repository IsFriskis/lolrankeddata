using LolRankedData.Services;
using LolRankedData.ViewModels;
using LolRankedData.Views;
using Microsoft.Extensions.Logging;

namespace LolRankedData;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        builder
            .UseMauiApp<App>()
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
            });

        // Register services
        builder.Services.AddSingleton<IRiotApiService, RiotApiService>();

        // Register view models
        builder.Services.AddSingleton<MainViewModel>();

        // Register views
        builder.Services.AddSingleton<MainPage>();

#if DEBUG
        builder.Logging.AddDebug();
#endif

        return builder.Build();
    }
}
