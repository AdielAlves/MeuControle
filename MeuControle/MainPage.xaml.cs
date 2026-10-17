using MeuControle.ViewModels;
namespace MeuControle;
public partial class MainPage : ContentPage
{
    private readonly PaginaInicialViewModel _viewModel;
    public MainPage(PaginaInicialViewModel viewModel)
    {
        InitializeComponent();
        _viewModel = viewModel;
        BindingContext = viewModel;
    }
    protected override async void OnAppearing()
    {
        base.OnAppearing();
        await _viewModel.CarregarCommand.ExecuteAsync(null);
    }
}
