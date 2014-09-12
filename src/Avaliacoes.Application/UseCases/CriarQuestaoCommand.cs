using Avaliacoes.Application.Generic;
using Avaliacoes.Data;
using Avaliacoes.Data.Contracts;
using Avaliacoes.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Avaliacoes.Application.UseCases
{
    public class CriarQuestaoCommand : ICommand
    {
        private Questao _questao;
        public CriarQuestaoCommand(Questao questao)
        {
            _questao = questao;
        }

        public Message Validate()
        {
            //Validação

            if (_questao.Texto.Length > 250)
            {
                return MessageFactory.Compose(
                                                Message.Status.Failure,
                                                MessageFactory.CadastroNaoEfetuado(),
                                                MessageFactory.CampoUltrapassaLimiteCaracteres("Texto da questão", 250)
                                             );
            }

            return MessageFactory.CadastroEfetuadoSucesso();
        }

        public void Execute(Activity currentActivity)
        {
            try
            {
                //Chamar a persistencia

                QuestaoRepository.Instance.AdicionarQuestao(_questao);
               
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
