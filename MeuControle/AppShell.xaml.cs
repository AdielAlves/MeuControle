namespace MeuControle;
public partial class AppShell : Shell
{
    public AppShell(MainPage pagina)
    {
        InitializeComponent();
        Items.Add(new ShellContent { Title = "Início", Route = "inicio", Content = pagina });
    }
}
