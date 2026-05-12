using APIProdutos.Domains;

namespace APIProdutos.Interfaces
{
    public interface IProdutoRepository
    {
        List<Produto> Listar();

        Produto BuscarPorId(int id);

        void Cadastrar(Produto produto);

        void Atualizar(int id, Produto produto);

        void Deletar(int id);
    }
}
