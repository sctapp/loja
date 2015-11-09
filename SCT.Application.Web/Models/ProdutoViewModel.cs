using SCT.Entity.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SCT.Application.Web.Models
{
    public class ProdutoViewModel
    {
        public IEnumerable<Produto> Produtos { get; set; }

        public Paginacao Paginacao { get; set; }

        public string CategoriaAtual { get; set; }
    }
}