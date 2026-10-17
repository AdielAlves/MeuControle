namespace MeuControle;

public partial class App : Application
{
    private readonly IServiceProvider _servicos;

    public App(IServiceProvider servicos)
    {
        InitializeComponent();

        _servicos = servicos;
    }

    protected override Window CreateWindow(
        IActivationState? activationState)
    {
        var shell = _servicos.GetRequiredService<AppShell>();

        return new Window(shell);
    }
}
