using ListaComprasCasaNova.Domain.Enums;
using ListaComprasCasaNova.Domain.Entities;
using ListaComprasCasaNova.Domain.Exceptions;

namespace ListaComprasCasaNova.Tests.Domain.Entities;

public class ItemComprasTests
{
    [Fact]
    public void DeveCriarItemComQuantidadeEmPeso()
    {
        var item = new ItemCompra(
            "Arroz", 
            5, 
            null, 
            CategoriaItem.Alimentacao);

        Assert.Equal("Arroz", item.Nome);
        Assert.Equal(5, item.QuantidadePeso);
        Assert.Null(item.QuantidadeUnidades);
        Assert.Equal(CategoriaItem.Alimentacao, item.Categoria);
    }

    [Fact]
    public void DeveCriarItemComQuantidadeDeUnidades()
    {
        var item = new ItemCompra(
            "Papel Higiênico", 
            null, 
            12, 
            CategoriaItem.Higiene);

        Assert.Equal("Papel Higiênico", item.Nome);
        Assert.Null(item.QuantidadePeso);
        Assert.Equal(12, item.QuantidadeUnidades);
        Assert.Equal(CategoriaItem.Higiene, item.Categoria);
    }

    [Fact]
    public void NaoDeveCriarProdutoComPesoEUnidadesPreenchidosSimultaneamente()
    {
        Assert.Throws<BusinessException>(() => 
            new ItemCompra(
                "Papel Higiênico",
                12,
                5,
                CategoriaItem.Higiene
                )
        );
    }

    [Fact]
    public void DeveCriarItemSemQuantidadeDePesoEUnidades()
    {
        var item = new ItemCompra(
            "Geladeira",
            null,
            null,
            CategoriaItem.Eletronicos
        );

        Assert.Null(item.QuantidadePeso);
        Assert.Null(item.QuantidadeUnidades);
    }

    [Fact]
    public void NaoDeveCriarItemSemNome()
    {
        Assert.Throws<BusinessException>(() =>
            new ItemCompra(
            "",
            5,
            null,
            CategoriaItem.Alimentacao
        )
        );
    }

    [Fact]
    public void NaoDeveCriarItemComQuantidadePesoinvalida()
    {
        Assert.Throws<BusinessException>(() =>
            new ItemCompra(
            "Arroz",
            -5,
            null,
            CategoriaItem.Alimentacao
        )
        );
    }

    [Fact]
    public void NaoDeveCriarItemComQuantidadeUnidadesInvalida()
    {
        Assert.Throws<BusinessException>(() =>
            new ItemCompra(
            "Arroz",
            null,
            -2,
            CategoriaItem.Alimentacao
        )
        );
    }

    [Fact]
    public void NaoDeveCriarItemComNomeComApenasEspacos()
    {
        Assert.Throws<BusinessException>(() =>
            new ItemCompra(
            "     ",
            null,
            5,
            CategoriaItem.Alimentacao
        )
        );        
    }

    [Fact]
    public void DeveAlterarStatusCompradoParaTrue()
    {
        var arroz = new ItemCompra(
            "Arroz",
            5,
            null,
            CategoriaItem.Alimentacao
        );

        arroz.AlterarStatusComprado();

        Assert.True(arroz.Comprado);
    }

        [Fact]
    public void DeveAlterarStatusCompradoParaFalse()
    {
        var arroz = new ItemCompra(
            "Arroz",
            5,
            null,
            CategoriaItem.Alimentacao
        );

        arroz.AlterarStatusComprado();
        arroz.AlterarStatusComprado();

        Assert.False(arroz.Comprado);
    }
}
