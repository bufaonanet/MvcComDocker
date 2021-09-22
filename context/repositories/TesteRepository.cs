using MvcComDocker.Models;
using System.Collections.Generic;

namespace MvcComDocker.context.repositories
{
    public class TesteRepository : IRepository
    {
        private static Produto[] _produtos = new Produto[]
        {
            new Produto{Id = 10,Nome="Canega",Categoria="Materia",Preco = 10.55m  },
            new Produto{Id = 11,Nome="Borracha",Categoria="Materia" ,Preco = 6.50m },
            new Produto{Id = 12,Nome="Estojo",Categoria="Materia",Preco = 20.50m  }
        };

        public IEnumerable<Produto> Produtos { get => _produtos; }
    }
}