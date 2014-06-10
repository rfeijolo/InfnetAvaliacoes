using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Avaliacoes.Domain;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace Avaliacoes.Web.Infrastructure
{
    public class AvaliacoesDb : DbContext, IAvaliacoesDataSource
    {
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }

        public DbSet<Aluno> Alunos { get; set; }
        public DbSet<Avaliacao> Avaliacoes { get; set; }
        public DbSet<Coordenador> Coordenadores { get; set; }
        public DbSet<Curso> Cursos { get; set; }
        public DbSet<Disciplina> Disciplinas { get; set; }
        public DbSet<Opcao> Opcoes { get; set; }
        public DbSet<Professor> Professores { get; set; }
        public DbSet<Questao> Questoes { get; set; }
        public DbSet<Resposta> Respostas { get; set; }
        public DbSet<TopicoAvaliacao> Topicos { get; set; }
        public DbSet<Turma> Turmas { get; set; }

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

        IQueryable<Disciplina> IAvaliacoesDataSource.Disciplinas
        {
            get { return Disciplinas; }
        }

        IQueryable<Opcao> IAvaliacoesDataSource.Opcoes
        {
            get { return Opcoes; }
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

    }
}