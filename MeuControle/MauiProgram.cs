using MeuControle.Interfaces;
using MeuControle.Services;
using MeuControle.ViewModels;
using Microsoft.Extensions.Logging;
namespace MeuControle;
public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        builder.UseMauiApp<App>();
        builder.Services.AddSingleton<ILancamentoService, LancamentoService>();
        builder.Services.AddTransient<PaginaInicialViewModel>();
        builder.Services.AddTransient<MainPage>();
        builder.Services.AddSingleton<AppShell>();
        builder.Services.AddSingleton<App>();

        return builder.Build();
    }
}
