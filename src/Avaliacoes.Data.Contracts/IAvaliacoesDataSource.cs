using System.Linq;
using Avaliacoes.Domain;

namespace Avaliacoes.Data.Contracts
{
    public interface IAvaliacoesDataSource
    {
        IQueryable<Aluno> Alunos { get; }
        IQueryable<Avaliacao> Avaliacoes { get; }
        IQueryable<Coordenador> Coordenadores { get; }
        IQueryable<Curso> Cursos { get; }
        IQueryable<Modulo> Modulos { get; }
        IQueryable<Professor> Professores { get; }
        IQueryable<Questao> Questoes { get; }
        IQueryable<Resposta> Respostas { get; }
        IQueryable<TopicoAvaliacao> Topicos { get; }
        IQueryable<Turma> Turmas { get; }
        IQueryable<Bloco> Blocos { get; }

    }
}
