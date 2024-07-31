using Microsoft.Extensions.Logging;
using DemoCRUDnet7.Models;
using DemoCRUDnet7.Services;
using DemoCRUDnet7.Views;
using Microsoft.Maui.Hosting;

namespace DemoCRUDnet7
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
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

            builder.Services.AddScoped<HttpClient>(s => new HttpClient());

            //builder.Services.AddScoped<MainPage>();
            builder.Services.AddScoped<PhotoListPage>();
            builder.Services.AddScoped<PhotoDetailsPage>();
            builder.Services.AddScoped<PhotoAddEditPage>();

            builder.Services.AddSingleton<ICRUDService<Photo>, PhotoFakeDb>();

            //builder.Services.AddScoped<ICRUDService<Photo>, PhotoApiService>();

#if DEBUG
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}