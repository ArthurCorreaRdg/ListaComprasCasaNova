using ListaComprasCasaNova.Domain.Enums;
using ListaComprasCasaNova.Domain.Exceptions;

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
    
    public ItemCompra(
        string nome, 
        decimal? quantidadePeso, 
        int? quantidadeUnidades, 
        CategoriaItem categoria)
    {
        if (string.IsNullOrWhiteSpace(nome)) //Verifica (nome == null || nome.Trim() == "")
        {
            throw new BusinessException("Não é possível criar um item sem nome");
        }

        if(quantidadePeso != null && quantidadeUnidades != null)
        {
            throw new BusinessException("Não pode criar item com peso e quantdade.");
        }

        if(quantidadePeso <= 0 || quantidadeUnidades <= 0)
        {
            throw new BusinessException("Não é possível criar item com quantidade menor ou igual a ZERO");
        }

        this.Nome = nome;
        this.QuantidadePeso = quantidadePeso;
        this.QuantidadeUnidades = quantidadeUnidades;
        this.Categoria = categoria;
        Comprado = false;
    }

}
