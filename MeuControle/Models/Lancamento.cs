using SQLite;
namespace MeuControle.Models;
public class Lancamento
{
    [PrimaryKey, AutoIncrement]
    public int Id { get; set; }
    [NotNull]
    public string Descricao { get; set; } = string.Empty;
    [NotNull]
    public string Categoria { get; set; } = string.Empty;
    [NotNull]
    public string Tipo { get; set; } = "Despesa";
    public long ValorCentavos { get; set; }
    public DateTime Data { get; set; } = DateTime.Today;
    [Ignore]
    public decimal Valor => ValorCentavos / 100m;
    [Ignore]
    public string ValorFormatado => (Tipo == "Despesa" ? "− " : "+ ") + Valor.ToString("C2", new System.Globalization.CultureInfo("pt-BR"));
    [Ignore]
    public string DataFormatada => Data.ToString("dd/MM/yyyy");
    [Ignore]
    public Color CorValor => Tipo == "Despesa" ? Color.FromArgb("#FF7B92") : Color.FromArgb("#35D9AD");
}
