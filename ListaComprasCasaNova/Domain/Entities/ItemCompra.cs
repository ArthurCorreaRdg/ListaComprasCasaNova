using ListaComprasCasaNova.Domain.Enums;

namespace ListaComprasCasaNova.Domain.Entities;

public class ItemCompra
{
    public long Id { get; set; }
    public string Nome { get; set; } = string.Empty;
    public decimal? QuantidadePeso { get; set; }
    public int? QuantidadeUnidades { get; set; }
    public CategoriaItem Categoria { get; set; }
    public bool Comprado { get; set; }
    public string? Observacao { get; set; }
    
}
