using MeuControle.Interfaces;
using MeuControle.Models;
using SQLite;
namespace MeuControle.Services;
public sealed class LancamentoService : ILancamentoService
{
    private SQLiteAsyncConnection? _conexao;
    private readonly SemaphoreSlim _inicializacao = new(1, 1);
    private async Task<SQLiteAsyncConnection> ObterConexaoAsync()
    {
        if (_conexao is not null) return _conexao;
        await _inicializacao.WaitAsync();
        try
        {
            if (_conexao is null)
            {
                var caminho = Path.Combine(FileSystem.AppDataDirectory, "meucontrole.db3");
                var conexao = new SQLiteAsyncConnection(caminho, SQLiteOpenFlags.ReadWrite | SQLiteOpenFlags.Create | SQLiteOpenFlags.SharedCache);
                await conexao.CreateTableAsync<Lancamento>();
                _conexao = conexao;
            }
            return _conexao;
        }
        finally { _inicializacao.Release(); }
    }
    public async Task<List<Lancamento>> ListarAsync()
    {
        var conexao = await ObterConexaoAsync();
        var lista = await conexao.Table<Lancamento>().ToListAsync();
        return lista.OrderByDescending(x => x.Data).ThenByDescending(x => x.Id).ToList();
    }
    public async Task SalvarAsync(Lancamento lancamento)
    {
        var conexao = await ObterConexaoAsync();
        if (lancamento.Id == 0) await conexao.InsertAsync(lancamento);
        else await conexao.UpdateAsync(lancamento);
    }
    public async Task ExcluirAsync(int id)
    {
        var conexao = await ObterConexaoAsync();
        await conexao.DeleteAsync<Lancamento>(id);
    }
}
