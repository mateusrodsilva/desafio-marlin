using EscolaDeIdiomas.WebApi.Commands;
using EscolaDeIdiomas.WebApi.Contexts;
using EscolaDeIdiomas.WebApi.Domains;
using EscolaDeIdiomas.WebApi.Interfaces;

namespace EscolaDeIdiomas.WebApi.Repositories
{
    public class TurmaRepository : ITurmaRepository //Herdamos os métodos da interface
    {
        private readonly EscolaDeIdiomasContext ctx; //Criamos uma instância do context para maniluplação do banco de dados

        public TurmaRepository(EscolaDeIdiomasContext ctx)
        {
            this.ctx = ctx;
        }

        public void Atualizar(Guid idTurma, TurmaCommand turmaAtualizada)
        {
            Turma turmaBuscada = ctx.Turmas.Find(idTurma);

            if (turmaBuscada == null)
            {
                throw new Exception("Turma não encontrada");
            }

            if (turmaAtualizada.numeroTurma != 0 && turmaAtualizada.anoLetivo != null && turmaAtualizada.descricaoTurma != null)
            {
                turmaBuscada.numeroTurma = turmaAtualizada.numeroTurma;
                turmaBuscada.anoLetivo = turmaAtualizada.anoLetivo;
                turmaBuscada.descricaoTurma = turmaAtualizada.descricaoTurma;
            }

            ctx.Turmas.Update(turmaBuscada);

            ctx.SaveChanges();
        }

        public void Cadastro(TurmaCommand novaTurma)
        {
            Turma turma = new Turma(novaTurma.numeroTurma,
                                    novaTurma.anoLetivo,
                                    novaTurma.descricaoTurma);

            ctx.Turmas.Add(turma);
            ctx.SaveChanges();
        }

        public void Excluir(Guid idTurma)
        {
            Turma turmaBuscada = ctx.Turmas.Find(idTurma);

            var alunosTurma = ctx.Matriculas.ToList()
                .Where(x => x.idTurma == idTurma);

            if (alunosTurma.Count() > 0)
            {
                throw new Exception("Tem alunos matriculados nesta turma, não é possível exclui-la!");
            }

            ctx.Turmas.Remove(turmaBuscada);
            ctx.SaveChanges();
        }

        public List<Turma> ListarTodos()
        {
            return ctx.Turmas.ToList();
        }
    }
}
