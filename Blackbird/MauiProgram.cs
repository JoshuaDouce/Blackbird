using Blackbird.RazorComponents.Interfaces;
using Blackbird.Services;
using Blackbird.RazorComponents.States;
using Microsoft.Extensions.Logging;
using MudBlazor.Services;

namespace Blackbird;

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
        builder.Services.AddMudServices();
        builder.Services.AddSingleton<IProductService, ProductService>();
        builder.Services.AddScoped<BasketState>();

        // Configure the HttpClient for your Web API
#if DEBUG
        builder.Services.AddTransient<HttpMessageHandler>(provider => new UnsafeHttpClientHandler());
#else
        builder.Services.AddTransient<HttpMessageHandler>(provider => new HttpClientHandler());
#endif

        builder.Services.AddTransient<IProductService, ProductService>();
        builder.Services.AddSingleton(x => new HttpClient(x.GetRequiredService<HttpMessageHandler>())
        {
            BaseAddress = new Uri("https://192.168.0.15:7104")
        });

#if DEBUG
        builder.Services.AddBlazorWebViewDeveloperTools();
		builder.Logging.AddDebug();
#endif

		return builder.Build();
	}
}
