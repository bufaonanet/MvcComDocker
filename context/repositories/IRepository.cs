using MvcComDocker.Models;
using System.Collections.Generic;

namespace MvcComDocker.context.repositories
{
    public interface IRepository
    {
        IEnumerable<Produto> Produtos { get; }
    }
}