using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EscolaDeIdiomas.WebApi.Domains
{
    public class Aluno
    {
        public Aluno(string nomeCompleto, string cpf, string email)
        {
            this.idAluno = Guid.NewGuid();
            this.nomeCompleto = nomeCompleto;
            this.cpf = cpf;
            this.email = email;
        }

        public Guid idAluno { get; set; }
        
        [Required(ErrorMessage = "O nome completo é obrigatório!")] //Define que a propriedade é obrigatória
        public string nomeCompleto { get; set; }

        [Required(ErrorMessage = "O CPF é obrigatório!")]
        public string cpf { get; set; }

        [Required(ErrorMessage = "O e-mail é obrigatório!")]
        public string email { get; set; }

        public ICollection<Matricula> Matriculas { get; set; } // Referenciando lista de Matriculas para o relacionamento entre as tabelas
    }
}
