using SCT.Application.Web.Models;
using SCT.Entity.Repositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SCT.Application.Web.Controllers
{
    public class VitrineController : Controller
    {
        private ProdutosRepositorio _repositorio;
        public int ProdutoPorPagina = 8;

        //
        // GET: /Vitrine/
        public ViewResult ListProdutos(string categoria, int pagina = 1)
        {
            _repositorio = new ProdutosRepositorio();

            ProdutoViewModel model = new ProdutoViewModel
            {
                Produtos = _repositorio.Produtos
                    .Where(p => categoria == null || p.Categoria == categoria)
                    .OrderBy(p => p.Nome)
                    .Skip((pagina - 1) * ProdutoPorPagina)
                    .Take(ProdutoPorPagina),

                Paginacao = new Paginacao
                {
                    PaginaAtual = pagina,
                    ItensPorPagina = ProdutoPorPagina,
                    ItensTotal = _repositorio.Produtos.Count()
                },

                CategoriaAtual = categoria
            };

            return View(model);
        }
    }
}