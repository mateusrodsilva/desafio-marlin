using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EscolaDeIdiomas.WebApi.Domains
{
    public class Turma
    {
        public Turma(int numeroTurma, string anoLetivo, string descricaoTurma)
        {
            this.idTurma = Guid.NewGuid();
            this.numeroTurma = numeroTurma;
            this.anoLetivo = anoLetivo;
            this.descricaoTurma = descricaoTurma;
        }

        public Guid idTurma { get; set; }

        [Required(ErrorMessage = "O número da turma é obrigatório")]
        public int numeroTurma { get; set; }

        [Required(ErrorMessage = "O ano letivo da turma é obrigatório")]
        public string anoLetivo { get; set; }
        
        [Required(ErrorMessage = "A descrição da turma é obrigatório")]
        public string descricaoTurma { get; set; }

        public ICollection<Matricula> Matriculas { get; set; }

    }
}
