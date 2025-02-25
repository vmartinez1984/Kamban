using Kamban.Maui.ModelViews;
using Kamban.Maui.Pages;
using Kamban.Maui.Services;
using Microsoft.Extensions.Logging;

namespace Kamban.Maui;

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

#if DEBUG
		builder.Logging.AddDebug();
#endif
        builder.Services.AddHttpClient(string.Empty, client =>
        {
            string url;            
			url = "https://sitio02.vmartinez84.xyz/api/";			
			//url = "https://10.0.2.2:5001/api/"; //Cuando se configuran el local en vs y el maui
            client.BaseAddress = new Uri(url);
        }).ConfigurePrimaryHttpMessageHandler(() => new HttpClientHandler
        {
            ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; }
        });

		builder.Services.AddSingleton<KambanService>();
		builder.Services.AddSingleton<FormularioDeTareaPage>();
		builder.Services.AddSingleton<MainPage>();
		builder.Services.AddSingleton<ListaDeTareasPage>();

        return builder.Build();
	}
}
