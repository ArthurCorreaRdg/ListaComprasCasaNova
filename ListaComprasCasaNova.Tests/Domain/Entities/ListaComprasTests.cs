using ListaComprasCasaNova.Domain.Enums;
using ListaComprasCasaNova.Domain.Entities;
using ListaComprasCasaNova.Domain.Exceptions;

namespace ListaComprasCasaNova.Tests.Domain.Entities;

public class ListaComprasTests
{
    [Fact]
    public void DeveCriarListaCasaNova()
    {
        var lista = new ListaCompra(
            "Casa Nova",
            TipoLista.CasaNova
        );

        Assert.Equal("Casa Nova", lista.Nome);
        Assert.Equal(TipoLista.CasaNova, lista.Tipo);
        Assert.Equal(StatusLista.Ativa, lista.Status);
        Assert.Equal(DateTime.Today, lista.DataCriacao);

        Assert.Empty(lista.Itens);      
    }

    [Fact]
    public void DeveCriarListaMensal()
    {
        var lista = new ListaCompra(
            "Compras Setembro",
            TipoLista.Mensal
        );

        Assert.Equal("Compras Setembro", lista.Nome);
        Assert.Equal(TipoLista.Mensal, lista.Tipo);
        Assert.Equal(StatusLista.Ativa, lista.Status);
        Assert.Equal(DateTime.Today, lista.DataCriacao);
        Assert.Empty(lista.Itens);
    }

    [Fact]
    public void NaoDeveCriarListaSemNome()
    {
        Assert.Throws<BusinessException>(() =>
            new ListaCompra(
                "",
                TipoLista.Mensal
            ));
    }

    [Fact]
    public void DeveAdicionarItensNaLista()
    {
        var lista = new ListaCompra(
            "Compras Setembro",
            TipoLista.Mensal
        );

        var arroz = new ItemCompra(
            "Arroz",
            5,
            null,
            CategoriaItem.Alimentacao
            );

        var papelHigienico = new ItemCompra(
            "Papel Higiênico",
            null,
            12,
            CategoriaItem.Higiene
            );

        lista.Itens.Add(arroz);
        lista.Itens.Add(papelHigienico);

        Assert.Equal(2, lista.Itens.Count);
        Assert.Contains(arroz, lista.Itens);
        Assert.Contains(papelHigienico, lista.Itens);        
    }

    [Fact]
    public void NaoDeveAdicionarItemAListaQuandoDuplicado()
    {
        var listaCompra = new ListaCompra(
            "Lista Duplicada",
            TipoLista.Mensal
            );

        var arroz = new ItemCompra(
            "Arroz",
            5,
            null,
            CategoriaItem.Alimentacao
            );

        var outroArroz = new ItemCompra(
            "arroz",
            10,
            null,
            CategoriaItem.Alimentacao
            );

        listaCompra.AdicionarItem(arroz);

        Assert.Throws<BusinessException>(()=> listaCompra.AdicionarItem(outroArroz));
    }

}
