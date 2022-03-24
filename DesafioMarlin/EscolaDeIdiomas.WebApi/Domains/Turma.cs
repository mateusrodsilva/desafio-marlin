using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EscolaDeIdiomas.WebApi.Domains
{
    [Table("Turmas")]
    public class Turma
    {
        [Key] //Define chave primária
        public Guid idTurma { get; set; }

        [Column(TypeName = "INTEGER")] //Define tipo de dado
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] //Define o auto-incremento
        public int numeroTurma { get; set; }

        [Column(TypeName = "VARCHAR(4)")]
        public string anoLetivo { get; set; }
    }
}
