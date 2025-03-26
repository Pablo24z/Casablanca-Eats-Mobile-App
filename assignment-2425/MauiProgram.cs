using Microsoft.Extensions.Logging;

namespace assignment_2425
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
                    fonts.AddFont("PalanquinDark-Bold.ttf", "PalanquinBold");
                    fonts.AddFont("PalanquinDark-Medium.ttf", "PalanquinDarkMedium");
                    fonts.AddFont("Palanquin-Medium.ttf", "PalanquinMedium");
                });

#if DEBUG
    		builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
