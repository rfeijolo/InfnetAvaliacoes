using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
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

        public void AdicionarAvaliacao(Avaliacao avaliacao)
        {
            using (var db = new AvaliacoesDbContext())
            {
                db.Avaliacoes.Add(avaliacao);
                db.SaveChanges();
            }
        }

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

    public class RespostaRepository
    {
        #region Singleton

        private static RespostaRepository instance;

        private RespostaRepository() { }

        public static RespostaRepository Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new RespostaRepository();
                }
                return instance;
            }
        }

        #endregion

        public void GravarRespostas(IEnumerable<Resposta> respostas)
        {
            using (var db = new AvaliacoesDbContext())
            {
                var enumerable = respostas as IList<Resposta> ?? respostas.ToList();
                for (var index = 0; index < enumerable.Count; index++)
                {
                    var resposta = enumerable[index];
                    var jaResposdido = db.Respostas.FirstOrDefault(
                        resp =>
                            resp.AlunoId == resposta.AlunoId && resp.QuestaoId == resposta.QuestaoId &&
                            resposta.AvaliacaoId == resp.AvaliacaoId);
                    if (jaResposdido == null)
                    {
                        db.Respostas.Add(resposta);
                    }
                    else
                    {
                        jaResposdido.OpcaoEscolhida = resposta.OpcaoEscolhida;
                        db.Entry(jaResposdido).State = EntityState.Modified;
                    }
                }
                db.SaveChanges();
            }
        }

    }
}