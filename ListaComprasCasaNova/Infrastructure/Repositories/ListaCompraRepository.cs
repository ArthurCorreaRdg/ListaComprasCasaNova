using ListaComprasCasaNova.Domain.Entities;

namespace ListaComprasCasaNova.Infrastructure.Repositories;

public class ListaCompraRepository : IListaCompraRepository
{
    var caminhoArquivoReal = Path.Combine(Directory.GetCurrentDirectory(), "Data", "listas-compras.json");
    public void Salvar(ListaCompra listaCompra)
    {
        var diretorioRaiz = Directory.GetCurrentDirectory();
        var diretorioData = Path.Combine(diretorioRaiz, "Data");
        var caminhoArquivo = Path.Combine(diretorioData, "listas-compras.json");
        
        Directory.CreateDirectory(diretorioData);

        if(!File.Exists(caminhoArquivo))
        {
            File.WriteAllText(caminhoArquivo, "[]");
        }

        var json = File.ReadAllText(caminhoArquivo);
        var listas = System.Text.Json.JsonSerializer.
                    Deserialize<List<ListaCompra>>(json) ?? new List<ListaCompra>();

        listaCompra.Id = listas.Count > 0 ? listas.Max(l => l.Id) + 1 : 1;

        listas.Add(listaCompra);
        json = System.Text.Json.JsonSerializer.Serialize(listas);
        File.WriteAllText(caminhoArquivo, json);
    }

    public ListaCompra? BuscarPorId(long id)
    {
        var diretorioRaiz = Directory.GetCurrentDirectory();
        var diretorioData = Path.Combine(diretorioRaiz, "Data");
        var caminhoArquivo = Path.Combine(diretorioData, "listas-compras.json");

        if (!File.Exists(caminhoArquivo))
        {
            return null;
        }

        var json = File.ReadAllText(caminhoArquivo);
        var listas = System.Text.Json.JsonSerializer.Deserialize<List<ListaCompra>>(json)
                                    ?? new List<ListaCompra>();

        return listas.FirstOrDefault(l => l.Id == id);
    }

    public List<ListaCompra> BuscarTodas()
    {
        var caminhoArquivo = Path.Combine(Directory.GetCurrentDirectory(), "Data", "listas-compras.json");

        if (!File.Exists(caminhoArquivo))
        {
            return new List<ListaCompra>();
        }   

        var json = File.ReadAllText(caminhoArquivo);
        var listas = System.Text.Json.JsonSerializer.
                    Deserialize<List<ListaCompra>>(json) ?? new List<ListaCompra>();

        return listas;
    }

}
