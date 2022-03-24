using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EscolaDeIdiomas.WebApi.Domains
{
    [Table("Alunos")]
    public class Aluno
    {
        [Key] //Define chave primária
        public Guid idAluno { get; set; }

        [Column(TypeName = "VARCHAR(150)")] //Define tipo de dado
        [Required(ErrorMessage = "O nome completo é obrigatório!")] //Define que a propriedade é obrigatória
        public string nomeCompleto { get; set; }

        [Column(TypeName = "VARCHAR(11)")]
        [Required(ErrorMessage = "O CPF é obrigatório!")]
        public string cpf { get; set; }

        [Column(TypeName = "VARCHAR(150)")]
        [Required(ErrorMessage = "O e-mail é obrigatório!")]
        public string email { get; set; }
    }
}
