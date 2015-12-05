using SCT.Entity.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SCT.Application.Web.Models
{
    public class CarrinhoViewModel
    {
        public Carrinho Carrinho { get; set; }

        public string ReturnUrl { get; set; }
    }
}