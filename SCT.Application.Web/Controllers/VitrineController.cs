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
        public int ProdutoPorPagina = 3;
        //
        // GET: /Vitrine/
        public ActionResult ListProdutos(int pagina = 1)
        {
            _repositorio = new ProdutosRepositorio();
            var produtos = _repositorio.Produtos
                    .OrderBy(p => p.Nome)
                    .Skip((pagina - 1) * ProdutoPorPagina)
                    .Take(ProdutoPorPagina);

            return View(produtos);
        }
    }
}