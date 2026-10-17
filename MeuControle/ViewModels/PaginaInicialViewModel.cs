using System.Collections.ObjectModel;
using System.Globalization;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MeuControle.Interfaces;
using MeuControle.Models;
namespace MeuControle.ViewModels;
public partial class PaginaInicialViewModel : ObservableObject
{
    private readonly ILancamentoService _servico;
    private List<Lancamento> _todos = new();
    private readonly CultureInfo _br = new("pt-BR");
    public ObservableCollection<Lancamento> Lancamentos { get; } = new();
    public List<string> Tipos { get; } = new() { "Despesa", "Receita" };
    public List<string> Categorias { get; } = new() { "Alimentação", "Moradia", "Transporte", "Saúde", "Educação", "Lazer", "Salário", "Freelance", "Outros" };
    public List<string> Filtros { get; } = new() { "Todos", "Receitas", "Despesas" };
    [ObservableProperty] private string descricao = "";
    [ObservableProperty] private string valorTexto = "";
    [ObservableProperty] private string tipoSelecionado = "Despesa";
    [ObservableProperty] private string categoriaSelecionada = "Alimentação";
    [ObservableProperty] private DateTime dataSelecionada = DateTime.Today;
    [ObservableProperty] private string filtroSelecionado = "Todos";
    [ObservableProperty] private string mensagem = "";
    [ObservableProperty] private bool ocupado;
    [ObservableProperty] private bool editando;
    [ObservableProperty] private string tituloFormulario = "Novo lançamento";
    [ObservableProperty] private string saldoFormatado = "R$ 0,00";
    [ObservableProperty] private string receitasFormatadas = "R$ 0,00";
    [ObservableProperty] private string despesasFormatadas = "R$ 0,00";
    [ObservableProperty] private string quantidadeFormatada = "Nenhum lançamento";
    private int _idEdicao;
    public PaginaInicialViewModel(ILancamentoService servico) => _servico = servico;
    partial void OnFiltroSelecionadoChanged(string value) => AplicarFiltro();
    [RelayCommand]
    private async Task CarregarAsync()
    {
        if (Ocupado) return;
        Ocupado = true;
        try
        {
            _todos = await _servico.ListarAsync();
            AtualizarResumo();
            AplicarFiltro();
            Mensagem = "";
        }
        catch (Exception ex) { Mensagem = $"Não foi possível carregar os dados: {ex.Message}"; }
        finally { Ocupado = false; }
    }
    [RelayCommand]
    private async Task SalvarAsync()
    {
        if (Ocupado) return;
        if (string.IsNullOrWhiteSpace(Descricao)) { Mensagem = "Informe uma descrição."; return; }
        if (!decimal.TryParse(ValorTexto?.Trim(), NumberStyles.Number | NumberStyles.AllowCurrencySymbol, _br, out var valor) || valor <= 0 || valor > 999999999m)
        { Mensagem = "Informe um valor válido. Exemplo: 49,90"; return; }
        if (string.IsNullOrWhiteSpace(TipoSelecionado) || string.IsNullOrWhiteSpace(CategoriaSelecionada))
        { Mensagem = "Selecione o tipo e a categoria."; return; }
        Ocupado = true;
        try
        {
            var registro = new Lancamento
            {
                Id = _idEdicao,
                Descricao = Descricao.Trim(),
                Categoria = CategoriaSelecionada,
                Tipo = TipoSelecionado,
                Data = DataSelecionada,
                ValorCentavos = checked((long)decimal.Round(valor * 100m, 0, MidpointRounding.AwayFromZero))
            };
            await _servico.SalvarAsync(registro);
            LimparFormulario();
            _todos = await _servico.ListarAsync();
            AtualizarResumo();
            AplicarFiltro();
            Mensagem = "Lançamento salvo com sucesso!";
        }
        catch (Exception ex) { Mensagem = $"Erro ao salvar: {ex.Message}"; }
        finally { Ocupado = false; }
    }
    [RelayCommand]
    private void Editar(Lancamento? lancamento)
    {
        if (lancamento is null) return;
        _idEdicao = lancamento.Id;
        Descricao = lancamento.Descricao;
        ValorTexto = lancamento.Valor.ToString("0.00", _br);
        TipoSelecionado = lancamento.Tipo;
        CategoriaSelecionada = lancamento.Categoria;
        DataSelecionada = lancamento.Data;
        Editando = true;
        TituloFormulario = "Editar lançamento";
        Mensagem = "Altere os campos e clique em Salvar.";
    }
    [RelayCommand]
    private async Task ExcluirAsync(Lancamento? lancamento)
    {
        if (lancamento is null || Ocupado) return;
        Ocupado = true;
        try
        {
            await _servico.ExcluirAsync(lancamento.Id);
            if (_idEdicao == lancamento.Id) LimparFormulario();
            _todos = await _servico.ListarAsync();
            AtualizarResumo();
            AplicarFiltro();
            Mensagem = "Lançamento excluído.";
        }
        catch (Exception ex) { Mensagem = $"Erro ao excluir: {ex.Message}"; }
        finally { Ocupado = false; }
    }
    [RelayCommand]
    private void CancelarEdicao() { LimparFormulario(); Mensagem = ""; }
    private void LimparFormulario()
    {
        _idEdicao = 0;
        Descricao = "";
        ValorTexto = "";
        TipoSelecionado = "Despesa";
        CategoriaSelecionada = "Alimentação";
        DataSelecionada = DateTime.Today;
        Editando = false;
        TituloFormulario = "Novo lançamento";
    }
    private void AtualizarResumo()
    {
        var receitas = _todos.Where(x => x.Tipo == "Receita").Sum(x => x.ValorCentavos);
        var despesas = _todos.Where(x => x.Tipo == "Despesa").Sum(x => x.ValorCentavos);
        SaldoFormatado = ((receitas - despesas) / 100m).ToString("C2", _br);
        ReceitasFormatadas = (receitas / 100m).ToString("C2", _br);
        DespesasFormatadas = (despesas / 100m).ToString("C2", _br);
    }
    private void AplicarFiltro()
    {
        Lancamentos.Clear();
        var itens = FiltroSelecionado switch
        {
            "Receitas" => _todos.Where(x => x.Tipo == "Receita"),
            "Despesas" => _todos.Where(x => x.Tipo == "Despesa"),
            _ => _todos.AsEnumerable()
        };
        foreach (var item in itens) Lancamentos.Add(item);
        QuantidadeFormatada = Lancamentos.Count == 1 ? "1 lançamento" : $"{Lancamentos.Count} lançamentos";
    }
}
