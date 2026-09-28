using ListaComprasCasaNova.Domain.Enums;
using ListaComprasCasaNova.Domain.Entities;

namespace ListaComprasCasaNova.Tests.Domain.Entities;

public class ItemComprasTests
{
    [Fact]
    public void DeveCriarItemComQuantidadeEmPeso()
    {
        var item = new ItemCompra
        {
            Id = 1,
            Nome = "Arroz",
            QuantidadePeso = 5,
            Categoria = CategoriaItem.Alimentacao,
            Comprado = false
        };

        Assert.Equal(1, item.Id);
        Assert.Equal("Arroz", item.Nome);
        Assert.Equal(5, item.QuantidadePeso);
        Assert.Null(item.QuantidadeUnidades);
        Assert.Equal(CategoriaItem.Alimentacao, item.Categoria);
        Assert.False(item.Comprado);
    }

    [Fact]
    public void DeveCriarItemComQuantidadeDeUnidades()
    {
        var item = new ItemCompra
        {
            Id = 2,
            Nome = "Papel Higiênico",
            QuantidadeUnidades = 12,
            Categoria = CategoriaItem.Higiene,
            Comprado = false
        };

        Assert.Equal(2, item.Id);
        Assert.Equal("Papel Higiênico", item.Nome);
        Assert.Null(item.QuantidadePeso);
        Assert.Equal(12, item.QuantidadeUnidades);
        Assert.Equal(CategoriaItem.Higiene, item.Categoria);
        Assert.False(item.Comprado);
    }
}
