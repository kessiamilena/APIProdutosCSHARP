using APIProdutos.Domains;
using APIProdutos.Interfaces;

namespace APIProdutos.Services
{
    public class ProdutoService
    {
        private readonly IProdutoRepository _repository;

        public ProdutoService(IProdutoRepository repository)
        {
            _repository = repository;
        }

        public List<Produto> Listar()
        {
            return _repository.Listar();
        }

        public Produto? BuscarPorId(int id)
        {
            return _repository.BuscarPorId(id);
        }

        public void Cadastrar(Produto produto)
        {
            if(string.IsNullOrWhiteSpace(produto.Nome))
            {
                throw new Exception("O nome do produto é obrigatório");
            }

            if(string.IsNullOrWhiteSpace(produto.Marca))
            {
                throw new Exception("A marca do produto é obrigatória.");
            }

            if(produto.Preco <= 0)
            {
                throw new Exception("O preço deve ser maior que zero");
            }

            if(produto.QuantidadeEstoque < 0)
            {
                throw new Exception("A quantidade em estoque não pode ser negativa.");
            }

            _repository.Cadastrar(produto);
        }

        public void Atualizar(int id, Produto produto)
        {
            if (string.IsNullOrWhiteSpace(produto.Nome))
            {
                throw new Exception("O nome do produto é obrigatório");
            }

            if (string.IsNullOrWhiteSpace(produto.Marca))
            {
                throw new Exception("A marca do produto é obrigatória.");
            }

            if (produto.Preco <= 0)
            {
                throw new Exception("O preço deve ser maior que zero");
            }

            if (produto.QuantidadeEstoque < 0)
            {
                throw new Exception("A quantidade em estoque não pode ser negativa.");
            }

            _repository.Atualizar(id, produto);
        }

        public void Deletar(int id)
        {
            _repository.Deletar(id);
        }
    }
}
