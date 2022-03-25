using EscolaDeIdiomas.WebApi.Commands;
using EscolaDeIdiomas.WebApi.Domains;

namespace EscolaDeIdiomas.WebApi.Interfaces
{
    public interface IAlunoRepository
    {
        void Cadastro(NovoAlunoCommand novoluno);
        void Atualizar(Guid idAluno, AlunoCommand alunoAtualizado);
        Aluno BuscarPorCpf(string cpf);
        Aluno BuscarPorEmail(string email);
        List<Aluno> ListarTodos();
        void Excluir(Guid idAluno);
    }
}
