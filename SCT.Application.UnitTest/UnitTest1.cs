using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Web.Mvc;
using SCT.Application.Web.Models;
using SCT.Application.Web.HtmlHelpers;

namespace SCT.Application.UnitTest
{
    [TestClass]
    public class UnitTestSCT
    {
        [TestMethod]
        public void TestandoQuebraPaginacao()
        {
            //Arrange

            HtmlHelper html = null;

            Paginacao paginacao = new Paginacao
            {
                PaginaAtual = 2,
                ItensPorPagina = 10,
                ItensTotal = 28
            };

            Func<int, string> paginaUrl = i => "Pagina" + i;

            //Act

            MvcHtmlString resultado = html.PageLinks(paginacao, paginaUrl);

            //Assert

            Assert.AreEqual(
                @"<a class=""btn btn-default"" href=""Pagina1"">1</a>"
                + @"<a class=""btn btn-default selected btn-primary"" href=""Pagina2"">2</a>"
                + @"<a class=""btn btn-default"" href=""Pagina3"">3</a>", resultado.ToString()
                );
        }
    }
}
