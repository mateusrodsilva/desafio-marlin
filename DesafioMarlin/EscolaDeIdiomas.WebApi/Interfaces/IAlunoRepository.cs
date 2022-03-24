using EscolaDeIdiomas.WebApi.Commands;
using EscolaDeIdiomas.WebApi.Domains;

namespace EscolaDeIdiomas.WebApi.Interfaces
{
    public interface IAlunoRepository
    {
        void Cadastro(AlunoCommand novoluno);
        void Atualizar(Guid idAluno, AlunoCommand alunoAtualizado);
        List<Aluno> ListarTodos();
        void Excluir(Guid idAluno);
    }
}
