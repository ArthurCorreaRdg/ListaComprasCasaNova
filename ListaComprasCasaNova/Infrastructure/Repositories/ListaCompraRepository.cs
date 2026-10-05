using ListaComprasCasaNova.Domain.Entities;

namespace ListaComprasCasaNova.Infrastructure.Repositories;

public class ListaCompraRepository
{
    public void Salvar(ListaCompra listaCompra)
    {
        if(!File.Exists("listas_compras.json"))
        {
            File.WriteAllText("listas_compras.json", "[]");
        }

        var json = File.ReadAllText("listas_compras.json");
        var listas = System.Text.Json.JsonSerializer.
                    Deserialize<List<ListaCompra>>(json) ?? new List<ListaCompra>();

        listaCompra.Id = listas.Count > 0 ? listas.Max(l => l.Id) + 1 : 1;

        listas.Add(listaCompra);
        json = System.Text.Json.JsonSerializer.Serialize(listas);
        File.WriteAllText("listas_compras.json", json);
    }

    public ListaCompra? BuscarPorId(long id)
    {
        // Lógica para buscar a lista de compras pelo ID no banco de dados
        return null; // Retorna null se não encontrar
    }

    public List<ListaCompra> BuscarTodos()
    {
        // Lógica para buscar todas as listas de compras no banco de dados
        return new List<ListaCompra>();
    }
}
