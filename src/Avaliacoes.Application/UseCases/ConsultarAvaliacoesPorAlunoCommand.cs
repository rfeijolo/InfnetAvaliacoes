using Avaliacoes.Application.Generic;
using Avaliacoes.Data;

namespace Avaliacoes.Application.UseCases
{
    public class ConsultarAvaliacoesPorAlunoCommand : ICommand
    {
        private readonly string _alunoId;

        public ConsultarAvaliacoesPorAlunoCommand(string alunoId)
        {
            _alunoId = alunoId;
        }

        public Message Validate()
        {
            return MessageFactory.Compose(Message.Status.Success);
        }

        public void Execute(Activity currentActivity)
        {
            currentActivity.Result = AvaliacaoRepository.Instance.ConsultarAvaliacoesDisponiveis(_alunoId);
        }
    }
}