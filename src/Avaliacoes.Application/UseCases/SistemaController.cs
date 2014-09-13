using Avaliacoes.Application.Generic;
using Avaliacoes.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Avaliacoes.Application.UseCases
{
    public class SistemaController
    {
        public Message CriarQuestao(Questao questao)
        {
            try
            {
                Activity atividadeCriarQuestao = ActivityFactory.Instance.GerarAtividadeCriarQuestao(questao);

                Message msg = atividadeCriarQuestao.Initiate();

                if (msg.CurrentStatus == Message.Status.Success)
                {
                    //pode salvar algum estado caso necessário depois da ação com sucesso retirando de atividade.Result
                    //ex: int idInserido = (int) atividadeCadastrarQuestao.Result
                }

                return msg;

            }
            catch (Exception)
            {
                throw;
            }

        }

        public IEnumerable<ModuloTurma> ConsultarAvaliacoesDisponiveisPorAluno(string alunoId)
        {
            var consultarAvaliacoesDisponiveisPorAluno = ActivityFactory.Instance.GerarAtividadeConsultarAvaliacoesPorAluno(alunoId);
            consultarAvaliacoesDisponiveisPorAluno.Initiate();
            return consultarAvaliacoesDisponiveisPorAluno.Result as IEnumerable<ModuloTurma>;
        }

        public Avaliacao ConsultarAvaliacao(int avaliacaoId)
        {
            var iniciarAvaliacao = ActivityFactory.Instance.GerarAtividadeIniciarAvaliacao(avaliacaoId);
            iniciarAvaliacao.Initiate();
            return iniciarAvaliacao.Result as Avaliacao;
        }

        public Message CriarAvaliacao(Avaliacao avaliacao, ICollection<int> modulosIds, ICollection<int> questoesIds)
        {
            var criarAvaliacao = ActivityFactory.Instance.GerarAtividadeCriarAvaliacao(avaliacao, modulosIds, questoesIds);
            Message msg = criarAvaliacao.Initiate();
            return msg;
        }
    }
}
