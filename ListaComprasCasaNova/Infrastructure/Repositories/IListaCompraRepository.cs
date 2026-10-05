using ListaComprasCasaNova.Domain.Entities;

namespace ListaComprasCasaNova.Infrastructure.Repositories;

public interface IListaCompraRepository
{
    void Salvar(ListaCompra listaCompra);

    ListaCompra? BuscarPorId(long id);

    List<ListaCompra> BuscarTodos();
}
