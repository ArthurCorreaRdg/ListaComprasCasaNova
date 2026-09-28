using ListaComprasCasaNova.Domain.Enums;
using ListaComprasCasaNova.Domain.Entities;

namespace ListaComprasCasaNova.Tests.Domain.Entities;

public class ListaComprasTests
{
    [Fact]
    public void DeveCriarListaCasaNova()
    {
        var dataCriacao = new DateTime(2026, 9, 28);
        var lista = new ListaCompra
        {
            Id = 1,
            Nome = "Casa Nova",
            Tipo = TipoLista.CasaNova,
            Status = StatusLista.Ativa,
            DataCriacao = dataCriacao
        };

        Assert.Equal(1, lista.Id);
        Assert.Equal("Casa Nova", lista.Nome);
        Assert.Equal(TipoLista.CasaNova, lista.Tipo);
        Assert.Equal(StatusLista.Ativa, lista.Status);
        Assert.Equal(dataCriacao, lista.DataCriacao);

        Assert.Empty(lista.Itens);      
    }

    [Fact]
    public void DeveCriarListaMensal()
    {
        var lista = new ListaCompra
        {
            Id = 2,
            Nome = "Compras Setembro",
            Tipo = TipoLista.Mensal,
            Status = StatusLista.Ativa,
            DataCriacao = new DateTime(2026, 9, 1)
        };

        Assert.Equal(2, lista.Id);
        Assert.Equal("Compras Setembro", lista.Nome);
        Assert.Equal(TipoLista.Mensal, lista.Tipo);
        Assert.Equal(StatusLista.Ativa, lista.Status);
        Assert.Empty(lista.Itens);
    }

    [Fact]
    public void DeveAdicionarItensNaLista()
    {
        var lista = new ListaCompra
        {
            Id = 1,
            Nome = "Compras Setembro",
            Tipo = TipoLista.Mensal,
            Status = StatusLista.Ativa,
            DataCriacao = new DateTime(2026, 9, 1)            
        };

        var arroz = new ItemCompra
        {
            Id = 1,
            Nome = "Arroz",
            QuantidadePeso = 5,
            Categoria = CategoriaItem.Alimentacao            
        };

        var papelHigienico = new ItemCompra
        {
            Id = 2,
            Nome = "Papel Higiênico",
            QuantidadeUnidades = 12,
            Categoria = CategoriaItem.Higiene
        };

        lista.Itens.Add(arroz);
        lista.Itens.Add(papelHigienico);

        Assert.Equal(2, lista.Itens.Count);
        Assert.Contains(arroz, lista.Itens);
        Assert.Contains(papelHigienico, lista.Itens);        
    }
}
