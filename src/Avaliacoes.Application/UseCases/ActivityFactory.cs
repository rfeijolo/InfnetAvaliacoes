using Avaliacoes.Application.Generic;
using Avaliacoes.Data;
using Avaliacoes.Data.Contracts;
using Avaliacoes.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Avaliacoes.Application.UseCases
{
    public class ActivityFactory
    {
        #region Singleton

        private static ActivityFactory instance;

        private ActivityFactory() { }

        public static ActivityFactory Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new ActivityFactory();
                }
                return instance;
            }
        }

        #endregion

        public Activity GerarAtividadeCriarQuestao(Questao questao)
        {
            return new Activity(new CriarQuestaoCommand(questao));
        }

        public Activity GerarAtividadeConsultarAvaliacoesPorAluno(string alunoId)
        {
            return new Activity(new ConsultarAvaliacoesPorAlunoCommand(alunoId));
        }

        public Activity GerarAtividadeConsultarAvaliacao(int avaliacaoId)
        {
            throw new NotImplementedException();
        }

        public Activity GerarAtividadeIniciarAvaliacao(int avaliacaoId)
        {
            return new Activity(new IniciarAvaliacaoCommand(avaliacaoId));
        }

        internal Activity GerarAtividadeCriarAvaliacao(Avaliacao avaliacao, ICollection<int> modulosIds, ICollection<int> questoesIds)
        {
            return new Activity(new CriarAvaliacaoCommand(avaliacao, modulosIds, questoesIds));
        }
        public Activity GerarAtividadeGravarRespostas(IEnumerable<Resposta> respostas)
        {
            return new Activity(new GravarRespostaCommand(respostas));
        }
    }

    
}
