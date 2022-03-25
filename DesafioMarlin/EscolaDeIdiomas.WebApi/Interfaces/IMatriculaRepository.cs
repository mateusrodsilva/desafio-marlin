using EscolaDeIdiomas.WebApi.Commands;
using EscolaDeIdiomas.WebApi.Domains;

namespace EscolaDeIdiomas.WebApi.Interfaces
{
    public interface IMatriculaRepository
    {
        void Cadastro(MatriculaCommand novaMatricula);
        List<Matricula> ListarTodos();
        void Excluir(Guid idMatricula);
    }
}
