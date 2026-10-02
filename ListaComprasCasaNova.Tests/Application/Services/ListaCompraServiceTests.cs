using ListaComprasCasaNova.Application.Services;
using ListaComprasCasaNova.Domain.Entities;
using ListaComprasCasaNova.Domain.Enums;

namespace ListaComprasCasaNova.Tests.Application.Services;

public class ListaCompraServiceTests
{

    [Fact]
    public void DeveCriarListaMensal()
    {
        var service = new ListaCompraService();

        var lista = service.CriarLista("Lista Mensal", TipoLista.Mensal);

        Assert.Equal("Lista Mensal", lista.Nome);
        Assert.Equal(TipoLista.Mensal, lista.Tipo);
    }

    [Fact]
    public void DeveAdicionarItemNaLista()
    {
        var service = new ListaCompraService();
        var lista = service.CriarLista("Lista Mensal", TipoLista.Mensal);
        var item = new ItemCompra("Arroz", 2, null, CategoriaItem.Alimentacao);

        service.AdicionarItem(lista, item);

        Assert.Contains(item, lista.Itens);
    }

    [Fact]
    public void DeveRemoverItemDaLista()
    {
        var service = new ListaCompraService();
        var lista = service.CriarLista("Lista Mensal", TipoLista.Mensal);
        var item = new ItemCompra("Arroz", 2, null, CategoriaItem.Alimentacao);

        service.AdicionarItem(lista, item);
        service.RemoverItem(lista, item);

        Assert.DoesNotContain(item, lista.Itens);
    }

    [Fact]
    public void DeveConcluirLista()
    {
        var service = new ListaCompraService();
        var lista = service.CriarLista("Lista Mensal", TipoLista.Mensal);

        service.ConcluirLista(lista);

        Assert.Equal(StatusLista.Concluida, lista.Status);
    }

    [Fact]
    public void DeveArquivarLista()
    {
        var service = new ListaCompraService();
        var lista = service.CriarLista("Lista Mensal", TipoLista.Mensal);

        service.ArquivarLista(lista);

        Assert.Equal(StatusLista.Arquivada, lista.Status);
    }

    
}
