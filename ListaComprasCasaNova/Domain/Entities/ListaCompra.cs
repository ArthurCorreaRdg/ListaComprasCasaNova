using ListaComprasCasaNova.Domain.Enums;
using ListaComprasCasaNova.Domain.Exceptions;

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

    public void AdicionarItem(ItemCompra item)
    {
        if (Itens.Any(itemExistente => string.Equals(
                                            itemExistente.Nome.Trim(), 
                                            item.Nome.Trim(), 
                                            StringComparison.OrdinalIgnoreCase)))
        {
            throw new BusinessException("Não é possível adicionar itens duplicados.");
        }
        Itens.Add(item);
    }
}
