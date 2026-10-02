using System;
using ListaComprasCasaNova.Domain.Entities;
using ListaComprasCasaNova.Domain.Enums;

namespace ListaComprasCasaNova.Application.Services;

public class ListaCompraService
{
    public ListaCompra CriarLista(string nome, TipoLista tipo)
    {
        return new ListaCompra(nome, tipo);
    }
}
