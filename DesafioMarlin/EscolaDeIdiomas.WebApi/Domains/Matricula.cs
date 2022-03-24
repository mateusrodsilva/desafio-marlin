using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EscolaDeIdiomas.WebApi.Domains
{
    public class Matricula
    {
        public Guid idMatricula { get; set; }

        public Guid idAluno { get; set; }
        
        public Guid idTurma { get; set; }

        public Aluno aluno { get; set; }

        public Turma turma { get; set; }
    }
}
