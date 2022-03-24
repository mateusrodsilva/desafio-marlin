using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EscolaDeIdiomas.WebApi.Domains
{
    [Table("Matriculas")]
    public class Matricula
    {
        [Key] //Define chave primária
        public Guid idMatricula { get; set; }

        [Column(TypeName = "GUID")] //Define tipo de dado
        public Guid idAluno { get; set; }
        
        [Column(TypeName = "GUID")]
        public Guid idTurma { get; set; }

        [ForeignKey("idAluno")] //Definindo chave estrangeira
        public Aluno aluno { get; set; }

        [ForeignKey("idTurma")]
        public Turma turma { get; set; }
    }
}
