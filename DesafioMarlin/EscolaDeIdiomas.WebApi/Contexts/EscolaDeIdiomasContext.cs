using EscolaDeIdiomas.WebApi.Domains;
using Microsoft.EntityFrameworkCore;

namespace EscolaDeIdiomas.WebApi.Contexts
{
    public class EscolaDeIdiomasContext : DbContext
    {
        public EscolaDeIdiomasContext(DbContextOptions<EscolaDeIdiomasContext> options) : base(options)
        {

        }

        //Define entidades no banco de dados
        public DbSet<Aluno> Alunos { get; set; }
        public DbSet<Turma> Turmas { get; set; }
        public DbSet<Matricula> Matriculas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region Alunos
            modelBuilder.Entity<Aluno>().ToTable("Alunos");

            //Primary Key
            modelBuilder.Entity<Aluno>().HasKey(x => x.idAluno);

            //Nome Completo
            modelBuilder.Entity<Aluno>().Property(x => x.nomeCompleto).HasMaxLength(150);
            modelBuilder.Entity<Aluno>().Property(x => x.nomeCompleto).HasColumnType("varchar(150)");
            modelBuilder.Entity<Aluno>().Property(x => x.nomeCompleto).IsRequired();
            modelBuilder.Entity<Aluno>().HasIndex(x => x.nomeCompleto).IsUnique();

            //CPF
            modelBuilder.Entity<Aluno>().Property(x => x.cpf).HasMaxLength(11);
            modelBuilder.Entity<Aluno>().Property(x => x.cpf).HasColumnType("varchar(11)");
            modelBuilder.Entity<Aluno>().Property(x => x.cpf).IsRequired();
            modelBuilder.Entity<Aluno>().HasIndex(x => x.cpf).IsUnique();

            //Email
            modelBuilder.Entity<Aluno>().Property(x => x.email).HasMaxLength(150);
            modelBuilder.Entity<Aluno>().Property(x => x.email).HasColumnType("varchar(150)");
            modelBuilder.Entity<Aluno>().Property(x => x.email).IsRequired();
            modelBuilder.Entity<Aluno>().HasIndex(x => x.email).IsUnique();
            #endregion

            #region Turmas

            modelBuilder.Entity<Turma>().ToTable("Turmas");
            //Primary Key
            modelBuilder.Entity<Turma>().HasKey(x => x.idTurma);

            //Número da Turma
            modelBuilder.Entity<Turma>().Property(x => x.numeroTurma).HasColumnType("INTEGER");
            modelBuilder.Entity<Turma>().Property(x => x.numeroTurma).IsRequired();
            modelBuilder.Entity<Turma>().HasIndex(x => x.numeroTurma).IsUnique();

            //CPF
            modelBuilder.Entity<Turma>().Property(x => x.anoLetivo).HasMaxLength(4);
            modelBuilder.Entity<Turma>().Property(x => x.anoLetivo).HasColumnType("varchar(4)");
            modelBuilder.Entity<Turma>().Property(x => x.anoLetivo).IsRequired();

            //Descrição da turma
            modelBuilder.Entity<Turma>().Property(x => x.decricaoTurma).HasMaxLength(200);
            modelBuilder.Entity<Turma>().Property(x => x.decricaoTurma).HasColumnType("varchar(200)");
            modelBuilder.Entity<Turma>().Property(x => x.decricaoTurma).IsRequired();
            #endregion

            #region Matriculas

            modelBuilder.Entity<Matricula>().ToTable("Matriculas");

            //Primary Key
            modelBuilder.Entity<Matricula>().HasKey(x => x.idMatricula);

            //Foreign Keys
            modelBuilder.Entity<Matricula>().HasOne(m => m.aluno).WithMany(m => m.Matriculas).HasForeignKey(m => m.idAluno);
            modelBuilder.Entity<Matricula>().HasOne(m => m.turma).WithMany(m => m.Matriculas).HasForeignKey(m => m.idTurma);

            #endregion

        }
    }
}
