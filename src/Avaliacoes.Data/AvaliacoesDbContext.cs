using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using Avaliacoes.Data.Contracts;
using Avaliacoes.Domain;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Avaliacoes.Data
{
    public class AvaliacoesDbContext : IdentityDbContext<ApplicationUser>, IAvaliacoesDataSource
    {
        public AvaliacoesDbContext()
            : base("AvaliacoesDbContext", throwIfV1Schema: false)
        {
        }

        public static AvaliacoesDbContext Create()
        {
            return new AvaliacoesDbContext();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Aluno> Alunos { get; set; }
        public DbSet<Avaliacao> Avaliacoes { get; set; }
        public DbSet<Coordenador> Coordenadores { get; set; }
        public DbSet<Curso> Cursos { get; set; }
        public DbSet<Modulo> Modulos { get; set; }
        public DbSet<Professor> Professores { get; set; }
        public DbSet<Questao> Questoes { get; set; }
        public DbSet<Resposta> Respostas { get; set; }
        public DbSet<TopicoAvaliacao> Topicos { get; set; }
        public DbSet<Turma> Turmas { get; set; }
        public DbSet<Bloco> Blocos { get; set; }

        IQueryable<Aluno> IAvaliacoesDataSource.Alunos
        {
            get { return Alunos; }
        }

        IQueryable<Avaliacao> IAvaliacoesDataSource.Avaliacoes
        {
            get { return Avaliacoes; }
        }

        IQueryable<Coordenador> IAvaliacoesDataSource.Coordenadores
        {
            get { return Coordenadores; }
        }

        IQueryable<Curso> IAvaliacoesDataSource.Cursos
        {
            get { return Cursos; }
        }

        IQueryable<Modulo> IAvaliacoesDataSource.Modulos
        {
            get { return Modulos; }
        }

        IQueryable<Professor> IAvaliacoesDataSource.Professores
        {
            get { return Professores; }
        }

        IQueryable<Questao> IAvaliacoesDataSource.Questoes
        {
            get { return Questoes; }
        }

        IQueryable<Resposta> IAvaliacoesDataSource.Respostas
        {
            get { return Respostas; }
        }

        IQueryable<TopicoAvaliacao> IAvaliacoesDataSource.Topicos
        {
            get { return Topicos; }
        }

        IQueryable<Turma> IAvaliacoesDataSource.Turmas
        {
            get { return Turmas; }
        }

        IQueryable<Bloco> IAvaliacoesDataSource.Blocos
        {
            get { return Blocos; }
        }

    }


}