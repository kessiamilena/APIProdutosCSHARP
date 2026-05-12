using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APIProdutos.Domains
{
    public class Produto
    {
        // anotação -> Key
        // serve para dizer que esse atributo é uma chave primária no banco de dados
        [Key]
        public int Id { get; set; }

        // anotação -> Required
        // todos os campos precisam ser obrigatórios
        [Required]
        public string Nome { get; set; } = string.Empty;

        [Required]
        public string Marca { get; set; } = string.Empty;

        // decimal(10,2) -> podemos ter até 10 números armazenados, sendo eles 2 números depois da vírgula
        [Column(TypeName = "decimal(10,2)")]
        public decimal Preco { get; set; }

        public int QuantidadeEstoque { get; set; }

        public bool Ativo { get; set; } = true;

    }
}
