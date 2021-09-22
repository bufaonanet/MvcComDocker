using Microsoft.EntityFrameworkCore;
using MvcComDocker.Models;

namespace MvcComDocker.context
{
    public class MvcomDockerContext : DbContext
    {
        public MvcomDockerContext(DbContextOptions<MvcomDockerContext> options) : base(options) { }

        public DbSet<Produto> Produtos { get; set; }
    }
}