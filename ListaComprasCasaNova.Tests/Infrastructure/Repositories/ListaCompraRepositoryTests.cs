
using ListaComprasCasaNova.Domain.Entities;
using ListaComprasCasaNova.Domain.Enums;
using ListaComprasCasaNova.Infrastructure.Repositories;

namespace ListaComprasCasaNova.Tests.Infrastructure.Repositories;

public class ListaCompraRepositoryTests
{
    [Fact]
    public void TestarSalvarListaCompra()
    {
        var listaCompra = new ListaCompra("Lista de Compras", TipoLista.Mensal);
        var repository = new ListaCompraRepository();

        repository.Salvar(listaCompra);
        var listaRecuperada = repository.BuscarPorId(listaCompra.Id);

        Assert.True(listaCompra.Id > 0);
        Assert.Equal(listaCompra.Id, listaRecuperada.Id);
        Assert.Equal("Lista de Compras", listaRecuperada.Nome);
    }
}
