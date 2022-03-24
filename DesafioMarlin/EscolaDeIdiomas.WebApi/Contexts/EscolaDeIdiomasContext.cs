using EscolaDeIdiomas.WebApi.Domains;
using Microsoft.EntityFrameworkCore;

namespace EscolaDeIdiomas.WebApi.Contexts
{
    public class EscolaDeIdiomasContext : DbContext
    {
        //Define entidades no banco de dados
        public DbSet<Aluno> Alunos { get; set; }
        public DbSet<Turma> Turmas { get; set; }
        public DbSet<Matricula> Matriculas { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=LAPTOP-DFNK1JF6; initial catalog=EscolaDeIdiomas; integrated Security=True");
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            /*modelBuilder.Entity<Aluno>().HasData(
                new Aluno
                {

                }
                ); */

            modelBuilder.Entity<Aluno>().ToTable("Alunos");
            modelBuilder.Entity<Aluno>().Property(x => x.idAluno);

            modelBuilder.Entity<Aluno>().Property(x => x.nomeCompleto).HasMaxLength(150);
            modelBuilder.Entity<Aluno>().Property(x => x.nomeCompleto).HasColumnType("varchar(150)");
            modelBuilder.Entity<Aluno>().Property(x => x.nomeCompleto).IsRequired();

            modelBuilder.Entity<Aluno>().Property(x => x.cpf).HasMaxLength(11);
            modelBuilder.Entity<Aluno>().Property(x => x.cpf).HasColumnType("varchar(11)");
            modelBuilder.Entity<Aluno>().Property(x => x.cpf).IsRequired();
            modelBuilder.Entity<Aluno>().HasIndex(x => x.cpf).IsUnique();


        }
    }
}
