using EscolaDeIdiomas.WebApi.Commands;
using EscolaDeIdiomas.WebApi.Contexts;
using EscolaDeIdiomas.WebApi.Domains;
using EscolaDeIdiomas.WebApi.Interfaces;

namespace EscolaDeIdiomas.WebApi.Repositories
{
    public class AlunoRepository : IAlunoRepository
    {
        private readonly EscolaDeIdiomasContext ctx; //Criamos uma instância do context para maniluplação do banco de dados

        public AlunoRepository(EscolaDeIdiomasContext ctx)
        {
            this.ctx = ctx;
        }

        public void Atualizar(Guid idAluno, AlunoCommand alunoAtualizado)
        {
            Aluno alunoBuscado = ctx.Alunos.Find(idAluno);

            if (alunoBuscado == null)
            {
                throw new Exception("Aluno não encontrado");
            }

            if (alunoAtualizado.nomeCompleto != null && alunoAtualizado.cpf != null && alunoAtualizado.email != null)
            {
                alunoBuscado.nomeCompleto = alunoAtualizado.nomeCompleto;
                alunoBuscado.cpf = alunoAtualizado.cpf;
                alunoBuscado.email = alunoAtualizado.email;
            }

            ctx.Alunos.Update(alunoBuscado);

            ctx.SaveChanges();
        }

        public void Cadastro(AlunoCommand novoAluno)
        {
            Aluno aluno = new Aluno(novoAluno.nomeCompleto,
                                    novoAluno.cpf,
                                    novoAluno.email);

            ctx.Alunos.Add(aluno);
            ctx.SaveChanges();
        }

        public void Excluir(Guid idAluno)
        {
            Aluno alunoBuscado = ctx.Alunos.Find(idAluno);

            ctx.Alunos.Remove(alunoBuscado);
            ctx.SaveChanges();
        }

        public List<Aluno> ListarTodos()
        {
            return ctx.Alunos.ToList();
        }
    }
}
