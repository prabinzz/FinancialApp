using FinancialApp.Data;
using Microsoft.Extensions.Logging;

namespace FinancialApp
{
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
                });

            builder.Services.AddMauiBlazorWebView();

#if DEBUG
    		builder.Services.AddBlazorWebViewDeveloperTools();
    		builder.Logging.AddDebug();
#endif
            // builder.Services.AddSingleton<WeatherForecastService>();
            DatabaseInitializer.InitializeDatabase();

            // register user service 
            builder.Services.AddSingleton<UserRepository>(provider =>
                new UserRepository(DatabaseInitializer.GetDatabasePath()));

            builder.Services.AddSingleton<AuthService>(new AuthService());

            return builder.Build();
        }
    }
}
