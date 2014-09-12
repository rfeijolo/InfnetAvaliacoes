using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading;
using Avaliacoes.Domain;

namespace Avaliacoes.Data
{
    public class AvaliacaoRepository
    {
        #region Singleton

        private static AvaliacaoRepository instance;

        private AvaliacaoRepository() { }

        public static AvaliacaoRepository Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new AvaliacaoRepository();
                }
                return instance;
            }
        }

        #endregion

        public IEnumerable<ModuloTurma> ConsultarAvaliacoesDisponiveis(string alunoId)
        {
            using (var db = new AvaliacoesDbContext())
            {
                var modulosComAvaliacaoPendente = db.ModuloTurmas.Include(mt => mt.Modulo).Include(mt => mt.Avaliacao).Include(mt => mt.Professor).Include(mt => mt.Turma).Where(
                    mt =>
                        mt.Turma.Alunos.Select(aluno => aluno.Id).Contains(alunoId) && DateTime.Now <= mt.Avaliacao.DataFim &&
                        DateTime.Now >= mt.Avaliacao.DataInicio);

                return modulosComAvaliacaoPendente.ToList();
            }
        }

        public Avaliacao ConsultarAvaliacao(int avaliacaoId)
        {
            using (var db = new AvaliacoesDbContext())
            {
                return db.Avaliacoes.Include(av => av.Questoes.Select(questao => questao.TopicoAvaliacao)).FirstOrDefault(avaliacao => avaliacao.Id == avaliacaoId);
            }
        }

    }
}