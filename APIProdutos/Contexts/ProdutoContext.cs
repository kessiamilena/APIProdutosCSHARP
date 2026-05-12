using APIProdutos.Domains;
using Microsoft.EntityFrameworkCore;

namespace APIProdutos.Contexts
{
    public class ProdutoContext : DbContext
    {
        public ProdutoContext(DbContextOptions<ProdutoContext> options) : base(options) { }

        // DbSet -> "Crie uma tabela produtos na classe produto"
        public DbSet<Produto> Produtos { get; set; }

    }
}
