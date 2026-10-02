using ListaComprasCasaNova.Domain.Entities;
using ListaComprasCasaNova.Domain.Enums;

namespace ListaComprasCasaNova.Application.Services;

public class ListaCompraService
{
    public ListaCompra CriarLista(string nome, TipoLista tipo)
    {
        return new ListaCompra(nome, tipo);
    }

    public void AdicionarItem(ListaCompra lista, ItemCompra item)
    {
        lista.AdicionarItem(item);
    }

    public void RemoverItem(ListaCompra lista, ItemCompra item)
    {
        lista.RemoverItem(item);
    }

    public void ConcluirLista(ListaCompra lista)
    {
        lista.ConcluirLista();
    }
    
    public void ArquivarLista(ListaCompra lista)
    {
        lista.ArquivarLista();
    }

}
