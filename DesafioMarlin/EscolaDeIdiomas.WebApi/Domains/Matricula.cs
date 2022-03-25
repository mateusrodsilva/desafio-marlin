using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EscolaDeIdiomas.WebApi.Domains
{
    public class Matricula
    {
        public Matricula(Guid idAluno, Guid idTurma)
        {
            this.idMatricula = Guid.NewGuid();
            this.idAluno = idAluno;
            this.idTurma = idTurma;
        }

        public Guid idMatricula { get; set; }

        public Guid idAluno { get; set; }
        
        public Guid idTurma { get; set; }

        public Aluno aluno { get; set; }

        public Turma turma { get; set; }
    }
}
