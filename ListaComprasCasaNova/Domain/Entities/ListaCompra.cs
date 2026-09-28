using ListaComprasCasaNova.Domain.Enums;

namespace ListaComprasCasaNova.Domain.Entities;

public class ListaCompra
{
    public long Id { get; set; }
    public string Nome { get; set; } = string.Empty;
    public string? Descricao { get; set; }
    public TipoLista Tipo { get; set; }
    public StatusLista Status { get; set; }
    public DateTime DataCriacao { get; set; }
    public DateTime? DataConclusao{ get; set; }
    public List<ItemCompra> Itens { get; set; } = new();
}
