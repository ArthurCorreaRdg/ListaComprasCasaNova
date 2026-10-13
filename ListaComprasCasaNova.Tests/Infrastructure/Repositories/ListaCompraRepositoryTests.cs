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
        var caminhoArquivo = Path.Combine(Directory.GetCurrentDirectory(), "Data", "listas-compras.json");
        
        Assert.True(File.Exists(caminhoArquivo));
    }

    [Fact]
    public void DeveVerificarDadosSalvos()
    {
        var listaCompra = new ListaCompra("Lista de Compras", TipoLista.Mensal);
        var repository = new ListaCompraRepository();

        repository.Salvar(listaCompra);

        var caminhoArquivo = Path.Combine(Directory.GetCurrentDirectory(), "Data", "listas-compras.json");
        var json = File.ReadAllText(caminhoArquivo);
        var listas = System.Text.Json.JsonSerializer.Deserialize<List<ListaCompra>>(json);

        Assert.NotNull(listas);
        Assert.Contains(listas, l => l.Nome == "Lista de Compras" && l.Tipo == TipoLista.Mensal);
    }

    [Fact]
    public void DeveBuscarListaExistentePorId()
    {
        var listaCompra = new ListaCompra("Lista de Compras", TipoLista.Mensal);
        var repository = new ListaCompraRepository();

        repository.Salvar(listaCompra);
        var listaBuscada = repository.BuscarPorId(listaCompra.Id);

        Assert.NotNull(listaBuscada);
        Assert.Equal(listaCompra.Id, listaBuscada?.Id);
        Assert.Equal(listaCompra.Nome, listaBuscada?.Nome);
        Assert.Equal(listaCompra.Tipo, listaBuscada?.Tipo);
    }

    [Fact]
    public void DeveRetornarNullParaListaInexistente()
    {
        var repository = new ListaCompraRepository();
        var listaBuscada = repository.BuscarPorId(9999);

        Assert.Null(listaBuscada);
    }

    [Fact]
    public void DeveBuscarTodasAsListas()
    {
        var listaCompra = new ListaCompra("Lista de Compras", TipoLista.Mensal);
        var repository = new ListaCompraRepository();

        repository.Salvar(listaCompra);
        var todasListas = repository.BuscarTodas();

        Assert.NotEmpty(todasListas);
        Assert.Contains(todasListas, l => l.Nome == "Lista de Compras" && l.Tipo == TipoLista.Mensal);
    }

    [Fact]
    public void DeveRetornarListaVaziaQuandoNaoExistiremListas()
    {
        var repository = new ListaCompraRepository();
        var caminhoArquivo = Path.Combine(Directory.GetCurrentDirectory(), "Data", "listas-compras.json");

        File.Delete(caminhoArquivo);

        Assert.Empty(repository.BuscarTodas());
    }

    [Fact]
    public void DeveRetornarColecaoVaziaQuandoExistirListaVazia()
    {
        var repository = new ListaCompraRepository();
        var caminhoArquivo = Path.Combine(Directory.GetCurrentDirectory(), "Data", "listas-compras.json");

        Directory.CreateDirectory(Path.GetDirectoryName(caminhoArquivo)!);
        File.WriteAllText(caminhoArquivo, "[]");

        Assert.Empty(repository.BuscarTodas());
    }

    [Fact]
    public void DeveVerificarGeracaoAutomaticaDeId()
    {
        var listaCompra1 = new ListaCompra("Lista 1", TipoLista.Mensal);
        var listaCompra2 = new ListaCompra("Lista 2", TipoLista.Mensal);
        var repository = new ListaCompraRepository();

        repository.Salvar(listaCompra1);
        repository.Salvar(listaCompra2);

        Assert.NotEqual(listaCompra1.Id, listaCompra2.Id);
        Assert.True(listaCompra2.Id > listaCompra1.Id);
    }
}
