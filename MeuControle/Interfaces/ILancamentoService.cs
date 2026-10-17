using MeuControle.Models;
namespace MeuControle.Interfaces;
public interface ILancamentoService
{
    Task<List<Lancamento>> ListarAsync();
    Task SalvarAsync(Lancamento lancamento);
    Task ExcluirAsync(int id);
}
