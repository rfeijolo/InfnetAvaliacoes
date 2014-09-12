using Avaliacoes.Application.Generic;
using Avaliacoes.Data;
using Avaliacoes.Domain;

namespace Avaliacoes.Application.UseCases
{
    public class IniciarAvaliacaoCommand : ICommand
    {
        private readonly Avaliacao _avaliacao;
        public IniciarAvaliacaoCommand(int avaliacaoId)
        {
            _avaliacao = AvaliacaoRepository.Instance.ConsultarAvaliacao(avaliacaoId);
        }

        public Message Validate()
        {
            if (!Avaliacao.EstaValida(_avaliacao))
            {
                return MessageFactory.AvaliacaoIndisponivel();
            }
            return new Message(string.Empty, Message.Status.Success);
        }

        public void Execute(Activity currentActivity)
        {
            currentActivity.Result = _avaliacao;
        }
    }
}