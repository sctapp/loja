using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SCT.Entity.Entidades;
using System.Linq;

namespace SCT.Application.UnitTest
{
    [TestClass]
    public class TesteCarrinhoCompras
    {
        [TestMethod]
        public void AdicionarItensAoCarrinho()
        {

            //Arrange

            Produto produto1 = new Produto
            {
                ProdutoId = 1,
                Nome = "Produto 1"
            };

            Produto produto2 = new Produto
            {
                ProdutoId = 2,
                Nome = "Produto 2"
            };

            Produto produto3 = new Produto
            {
                ProdutoId = 3,
                Nome = "Produto 3"
            };

            Carrinho carrinho = new Carrinho();

            carrinho.AdicionarItem(produto1, 2);

            carrinho.AdicionarItem(produto2, 7);

            carrinho.AdicionarItem(produto3, 1);

            //Act
            ItemCarrinho[] itens = carrinho.ItensCarrinho.ToArray();

            //Assert
            Assert.AreEqual(itens.Length, 3);
            Assert.AreEqual(itens[0].Produto, produto1);
            Assert.AreEqual(itens[1].Produto, produto2);
        }

        [TestMethod]
        public void AdicionarItemExistenteLista()
        {
            //region Arrange

            Produto produto1 = new Produto
            {
                ProdutoId = 1,
                Nome = "Produto 1"
            };

            Produto produto2 = new Produto
            {
                ProdutoId = 2,
                Nome = "Produto 2"
            };

            Carrinho carrinho = new Carrinho();

            carrinho.AdicionarItem(produto1, 2);

            carrinho.AdicionarItem(produto2, 7);

            carrinho.AdicionarItem(produto1, 10);

            //Act
            ItemCarrinho[] resultado = carrinho.ItensCarrinho.OrderBy(c => c.Produto.Nome).ToArray();

            //Assert
            Assert.AreEqual(resultado.Length, 2);
        }

        [TestMethod]
        public void RemoverItemDoCarrinho()
        {
            Produto produto1 = new Produto
            {
                ProdutoId = 1,
                Nome = "Produto 1"
            };

            Produto produto2 = new Produto
            {
                ProdutoId = 2,
                Nome = "Produto 2"
            };

            Carrinho carrinho = new Carrinho();

            carrinho.AdicionarItem(produto1, 2);

            carrinho.AdicionarItem(produto2, 7);

            carrinho.RemoverItem(produto2);

            Assert.AreEqual(carrinho.ItensCarrinho.Where(c => c.Produto == produto2).Count(), 0);
        }

        [TestMethod]
        public void CalcularValorTotalCarrinho()
        {
            Produto produto1 = new Produto
            {
                ProdutoId = 1,
                Nome = "Produto 1",
                Preco = 100M
            };

            Produto produto2 = new Produto
            {
                ProdutoId = 2,
                Nome = "Produto 2",
                Preco = 50M
            };

            Carrinho carrinho = new Carrinho();

            carrinho.AdicionarItem(produto1, 2);

            carrinho.AdicionarItem(produto2, 7);

            decimal resultado = carrinho.ObterValorTotal();

            Assert.AreEqual(resultado, 550M);
        }

        [TestMethod]
        public void LimparCarrinho()
        {
            Produto produto1 = new Produto
            {
                ProdutoId = 1,
                Nome = "Produto 1",
                Preco = 100M
            };

            Produto produto2 = new Produto
            {
                ProdutoId = 2,
                Nome = "Produto 2",
                Preco = 50M
            };

            Carrinho carrinho = new Carrinho();

            carrinho.AdicionarItem(produto1, 2);

            carrinho.AdicionarItem(produto2, 7);

            carrinho.LimparCarrinho();

            Assert.AreEqual(carrinho.ItensCarrinho.Count(), 0);
        }
    }
}
