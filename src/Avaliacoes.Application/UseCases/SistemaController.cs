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
            catch(Exception)
            {
                throw;
            }

        }
    }
}
