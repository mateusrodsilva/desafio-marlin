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

        public Aluno BuscarPorCpf(string cpf)
        {
            return ctx.Alunos.FirstOrDefault(x => x.cpf == cpf);
        }

        public Aluno BuscarPorEmail(string email)
        {
            return ctx.Alunos.FirstOrDefault(x => x.email == email);
        }

        public void Cadastro(NovoAlunoCommand novoAluno)
        {
            var verificadorCpf = BuscarPorCpf(novoAluno.cpf);

            var verificadorEmail = BuscarPorEmail(novoAluno.email);
            
            if (verificadorCpf != null)
            {
                throw new Exception("CPF já cadastrado! Informe outro CPF");
            }

            if (verificadorEmail != null)
            {
                throw new Exception("Email já cadastrado! Informe outro Email");
            }

            Aluno aluno = new Aluno(novoAluno.nomeCompleto,
                                    novoAluno.cpf,
                                    novoAluno.email);

            var buscarTurma = ctx.Turmas.FirstOrDefault(x => x.idTurma == novoAluno.idTurma);

            if (buscarTurma == null)
            {
                throw new Exception("Turma não encontrada! Informe um id de turma válido");
            }


            Matricula novaMatricula = new Matricula(aluno.idAluno,
                                                    novoAluno.idTurma);

            ctx.Alunos.Add(aluno);
            ctx.Matriculas.Add(novaMatricula);
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
