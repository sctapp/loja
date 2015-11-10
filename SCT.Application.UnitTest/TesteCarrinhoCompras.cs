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
    }
}
