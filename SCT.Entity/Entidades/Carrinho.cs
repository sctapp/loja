using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCT.Entity.Entidades
{
    public class Carrinho
    {
        private readonly List<ItemCarrinho> _itensCarrinho = new List<ItemCarrinho>();

        #region Adicionar

        public void AdicionarItem(Produto produto, int quantidade)
        {
            ItemCarrinho item = _itensCarrinho.FirstOrDefault(p => p.Produto.ProdutoId == produto.ProdutoId);

            if (item == null)
            {
                _itensCarrinho.Add(new ItemCarrinho
                {
                    Produto = produto,
                    Quantidade = quantidade
                });
            }
            else
            {
                item.Quantidade += quantidade;
            }
        }

        #endregion

        #region Remover

        public void RemoverItem(Produto produto)
        {
            _itensCarrinho.RemoveAll(l => l.Produto.ProdutoId == produto.ProdutoId);
        }

        #endregion

        #region Obter valor total

        public decimal ObterValorTotal()
        {
            return _itensCarrinho.Sum(e => e.Produto.Preco * e.Quantidade);
        }

        #endregion

        #region Limpar carrinho

        public void LimparCarrinho()
        {
            _itensCarrinho.Clear();
        }

        #endregion

        #region Itens Carrinho

        public IEnumerable<ItemCarrinho> ItensCarrinho
        {
            get { return _itensCarrinho; }
        }

        #endregion
    }

    public class ItemCarrinho
    {
        public Produto Produto { get; set; }
        public int Quantidade { get; set; }
    }
}
