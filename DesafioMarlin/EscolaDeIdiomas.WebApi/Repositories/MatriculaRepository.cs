using EscolaDeIdiomas.WebApi.Commands;
using EscolaDeIdiomas.WebApi.Contexts;
using EscolaDeIdiomas.WebApi.Domains;
using EscolaDeIdiomas.WebApi.Interfaces;

namespace EscolaDeIdiomas.WebApi.Repositories
{
    public class MatriculaRepository : IMatriculaRepository
    {
        private readonly EscolaDeIdiomasContext ctx; //Criamos uma instância do context para maniluplação do banco de dados

        public MatriculaRepository(EscolaDeIdiomasContext ctx)
        {
            this.ctx = ctx;
        }

        public void Cadastro(MatriculaCommand novaMatricula)
        {
            var existeMatricula = ctx.Matriculas.FirstOrDefault(x => x.idAluno == novaMatricula.idAluno && x.idTurma == novaMatricula.idTurma);

            var alunosTurma = ctx.Matriculas.ToList()
                .Where(x => x.idTurma == novaMatricula.idTurma);

            if (alunosTurma.Count() > 4)
            {
                throw new Exception("A turma escolhida está lotada, só é permitido 5 alunos por turma!");
            }

            if (existeMatricula != null)
            {
                throw new Exception("O aluno informado já está matriculado nesta turma!");
            }

            Matricula matricula = new Matricula(novaMatricula.idAluno,
                                                novaMatricula.idTurma);

            ctx.Matriculas.Add(matricula);
            ctx.SaveChanges();

        }

        public void Excluir(Guid idMatricula)
        {
            Matricula matriculaBuscada = ctx.Matriculas.Find(idMatricula);

            if (matriculaBuscada == null)
            {
                throw new Exception("Matricula não encontrada");
            }

            ctx.Matriculas.Remove(matriculaBuscada);
            ctx.SaveChanges();
        }

        public List<Matricula> ListarTodos()
        {
            return ctx.Matriculas.ToList();
        }
    }
}
