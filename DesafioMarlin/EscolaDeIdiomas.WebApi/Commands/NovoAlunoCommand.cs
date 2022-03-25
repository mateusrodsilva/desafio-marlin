namespace EscolaDeIdiomas.WebApi.Commands
{
    public class NovoAlunoCommand
    {
        public string nomeCompleto { get; set; }
        public string cpf { get; set; }
        public string email { get; set; }
        public Guid idTurma { get; set; }
    }
}
