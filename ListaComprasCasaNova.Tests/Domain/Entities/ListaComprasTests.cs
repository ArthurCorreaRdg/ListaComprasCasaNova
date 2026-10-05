using ListaComprasCasaNova.Domain.Enums;
using ListaComprasCasaNova.Domain.Entities;
using ListaComprasCasaNova.Domain.Exceptions;

namespace ListaComprasCasaNova.Tests.Domain.Entities;

public class ListaComprasTests
{
    [Fact]
    public void DeveCriarListaCasaNova()
    {
        var lista = new ListaCompra(
            "Casa Nova",
            TipoLista.CasaNova
        );

        Assert.Equal("Casa Nova", lista.Nome);
        Assert.Equal(TipoLista.CasaNova, lista.Tipo);
        Assert.Equal(StatusLista.Ativa, lista.Status);
        Assert.Equal(DateTime.Today, lista.DataCriacao);

        Assert.Empty(lista.Itens);      
    }

    [Fact]
    public void DeveCriarListaMensal()
    {
        var lista = new ListaCompra(
            "Compras Setembro",
            TipoLista.Mensal
        );

        Assert.Equal("Compras Setembro", lista.Nome);
        Assert.Equal(TipoLista.Mensal, lista.Tipo);
        Assert.Equal(StatusLista.Ativa, lista.Status);
        Assert.Equal(DateTime.Today, lista.DataCriacao);
        Assert.Empty(lista.Itens);
    }

    [Fact]
    public void NaoDeveCriarListaSemNome()
    {
        Assert.Throws<BusinessException>(() =>
            new ListaCompra(
                "",
                TipoLista.Mensal
            ));
    }

    [Fact]
    public void DeveAdicionarItensNaLista()
    {
        var lista = new ListaCompra(
            "Compras Setembro",
            TipoLista.Mensal
        );

        var arroz = new ItemCompra(
            "Arroz",
            5,
            null,
            CategoriaItem.Alimentacao
            );

        var papelHigienico = new ItemCompra(
            "Papel Higiênico",
            null,
            12,
            CategoriaItem.Higiene
            );

        lista.AdicionarItem(arroz);
        lista.AdicionarItem(papelHigienico);

        Assert.Equal(2, lista.Itens.Count);
        Assert.Contains(arroz, lista.Itens);
        Assert.Contains(papelHigienico, lista.Itens);        
    }

    [Fact]
    public void NaoDeveAdicionarItemNuloALista()
    {
        var lista = new ListaCompra(
            "ListaComItemNulo",
            TipoLista.Mensal
        );

        Assert.Throws<BusinessException>(()=> lista.AdicionarItem(null));
    }

    [Fact]
    public void NaoDeveAdicionarItemAListaQuandoDuplicado()
    {
        var listaCompra = new ListaCompra(
            "Lista Duplicada",
            TipoLista.Mensal
            );

        var arroz = new ItemCompra(
            "Arroz",
            5,
            null,
            CategoriaItem.Alimentacao
            );

        var outroArroz = new ItemCompra(
            "arroz",
            10,
            null,
            CategoriaItem.Alimentacao
            );

        listaCompra.AdicionarItem(arroz);

        Assert.Throws<BusinessException>(()=> listaCompra.AdicionarItem(outroArroz));
    }

    [Fact]
    public void DeveRemoverItemDaLista()
    {
        var lista = new ListaCompra(
            "ListaParaRemoverItem",
            TipoLista.Mensal
        );

        var arroz = new ItemCompra(
            "Arroz",
            5,
            null,
            CategoriaItem.Alimentacao
        );

        var feijao = new ItemCompra(
            "Feijão",
            2,
            null,
            CategoriaItem.Alimentacao
        );

        lista.AdicionarItem(arroz);
        lista.AdicionarItem(feijao);
        lista.RemoverItem(arroz);

        Assert.Single(lista.Itens);
        Assert.Contains(feijao, lista.Itens);
        Assert.DoesNotContain(arroz, lista.Itens);
    }

    [Fact]
    public void NaoDeveRemoverItemNulo()
    {
        var lista = new ListaCompra(
            "ListaDeRemoçaoDoItemNulo",
            TipoLista.Mensal
        );
        Assert.Throws<BusinessException>(() => lista.RemoverItem(null));
    }

    [Fact]
    public void NaoDeveRemoverItemInexistente()
    {
        var lista = new ListaCompra(
            "ListaDeRemoçaoDoItemInexistente",
            TipoLista.Mensal
        );

        var arroz = new ItemCompra(
            "Arroz",
            5,
            null,
            CategoriaItem.Alimentacao);

        Assert.Throws<BusinessException>(()=> lista.RemoverItem(arroz));
    }

    [Fact]
    public void NaoDeveAdicionarItemEmListaConcluida()
    {
        var lista = new ListaCompra(
            "ListaConcluida",
            TipoLista.Mensal
        );

        var arroz = new ItemCompra(
            "Arroz",
            5,
            null,
            CategoriaItem.Alimentacao
        );

        lista.ConcluirLista();

        Assert.Throws<BusinessException>(()=> lista.AdicionarItem(arroz));
    }

    [Fact]
    public void NaoDeveRemoverItemEmListaConcluida()
    {
        var lista = new ListaCompra(
            "ListaConcluida",
            TipoLista.Mensal
        );

        var arroz = new ItemCompra(
            "Arroz",
            5,
            null,
            CategoriaItem.Alimentacao
        );

        lista.AdicionarItem(arroz);
        lista.ConcluirLista();

        Assert.Throws<BusinessException>(()=> lista.RemoverItem(arroz));
    }

    [Fact]
    public void NaoDeveAdicionarItemEmListaArquivada()
    {
        var lista = new ListaCompra(
            "ListaArquivada",
            TipoLista.Mensal
        );

        var arroz = new ItemCompra(
            "Arroz",
            5,
            null,
            CategoriaItem.Alimentacao
        );

        lista.ArquivarLista();

        Assert.Throws<BusinessException>(()=> lista.AdicionarItem(arroz));
    }

    [Fact]
    public void NaoDeveRemoverItemEmListaArquivada()
    {
        var lista = new ListaCompra(
            "ListaConcluida",
            TipoLista.Mensal
        );

        var arroz = new ItemCompra(
            "Arroz",
            5,
            null,
            CategoriaItem.Alimentacao
        );

        lista.AdicionarItem(arroz);
        lista.ArquivarLista();

        Assert.Throws<BusinessException>(()=> lista.RemoverItem(arroz));
    }

    [Fact]
    public void DeveConcluirListaAtiva()
    {
        var lista = new ListaCompra(
            "ListaASerConcluida",
            TipoLista.Mensal
        );

        lista.ConcluirLista();

        Assert.Equal(StatusLista.Concluida, lista.Status);
        Assert.NotNull(lista.DataConclusao);
    }

    [Fact]
    public void DeveArquivarListaAtiva()
    {
        var lista = new ListaCompra(
            "ListaASerArquivada",
            TipoLista.Mensal
        );

        lista.ArquivarLista();

        Assert.Equal(StatusLista.Arquivada, lista.Status);
    }

    [Fact]
    public void NaoDeveConcluirListaJaConcluida()
    {
        var lista = new ListaCompra(
            "ListaConcluidaASerConcluida",
            TipoLista.Mensal
        );

        lista.ConcluirLista();  

        Assert.Throws<BusinessException>(()=> lista.ConcluirLista());
    }

    [Fact]
    public void NaoDeveConcluirListaArquivada()
    {
        var lista = new ListaCompra(
            "ListaArquivadaASerConcluida",
            TipoLista.Mensal
        );

        lista.ArquivarLista();  

        Assert.Throws<BusinessException>(()=> lista.ConcluirLista());
    }

    [Fact]
    public void NaoDeveArquivarListaArquivada()
    {
        var lista = new ListaCompra(
            "ListaArquivadaASerConcluida",
            TipoLista.Mensal
        );

        lista.ArquivarLista();  

        Assert.Throws<BusinessException>(()=> lista.ArquivarLista());
    }
}
