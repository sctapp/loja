using SCT.Entity.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCT.Entity.Repositorio
{
    public class ProdutosRepositorio
    {
        private readonly SctDbContext _context = new SctDbContext();

        public IEnumerable<Produto> Produtos
        {
            get { return _context.Produtos; }
        }
    }
}
