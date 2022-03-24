using EscolaDeIdiomas.WebApi.Commands;
using EscolaDeIdiomas.WebApi.Domains;

namespace EscolaDeIdiomas.WebApi.Interfaces
{
    public interface ITurmaRepository
    {
        void Cadastro(TurmaCommand novaTurma);
        void Atualizar(Guid idTurma, TurmaCommand turmaAtualizada);
        List<Turma> ListarTodos();
        void Excluir(Guid idTurma);
    }
}
