using MvcComDocker.Models;
using System.Collections.Generic;

namespace MvcComDocker.context.repositories
{
    public class ProdutoRepository : IRepository
    {
        private readonly MvcomDockerContext _context;
        public ProdutoRepository(MvcomDockerContext context)
        {
            _context = context;
        }

        public IEnumerable<Produto> Produtos => _context.Produtos;
    }
}
