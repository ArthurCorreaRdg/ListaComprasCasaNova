using ListaComprasCasaNova.Application.Services;
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

}
