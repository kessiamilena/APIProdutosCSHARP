using APIProdutos.Contexts;
using APIProdutos.Domains;
using APIProdutos.Interfaces;

namespace APIProdutos.Repositories
{
    public class ProdutoRepository : IProdutoRepository
    {
        private readonly ProdutoContext _context;

        public ProdutoRepository(ProdutoContext context)
        {
            _context = context;
        }

        public List<Produto> Listar()
        {
            // lista todos os produtos que vem da tabela produtos no banco de dados
            return _context.Produtos.ToList();
        }

        public Produto? BuscarPorId(int id)
        {
            return _context.Produtos.FirstOrDefault(produto => produto.Id == id);
        }

        public void Cadastrar(Produto produto)
        {
            _context.Produtos.Add(produto);

            _context.SaveChanges();
        }

        public void Atualizar(int id, Produto produtoAtualizado)
        {
            Produto? produto = BuscarPorId(id);

            if(produto == null)
            {
                throw new Exception("Produto não encontrado.");
            }

            produto.Nome = produtoAtualizado.Nome;
            produto.Marca = produtoAtualizado.Marca;
            produto.Preco = produtoAtualizado.Preco;
            produto.QuantidadeEstoque = produtoAtualizado.QuantidadeEstoque;
            produto.Ativo = produtoAtualizado.Ativo;

            _context.SaveChanges();
        }

        public void Deletar(int id)
        {
            Produto? produto = BuscarPorId(id);

            if(produto == null)
            {
                throw new Exception("Produto não encontrado.");
            }

            _context.Produtos.Remove(produto);
            _context.SaveChanges();
        }
    }
}
