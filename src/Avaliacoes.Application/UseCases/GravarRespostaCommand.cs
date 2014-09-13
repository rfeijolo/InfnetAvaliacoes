using System.Collections.Generic;
using System.Linq;
using Avaliacoes.Application.Generic;
using Avaliacoes.Data;
using Avaliacoes.Domain;

namespace Avaliacoes.Application.UseCases
{
    public class GravarRespostaCommand : ICommand
    {
        private readonly IEnumerable<Resposta> _respostas;
        public GravarRespostaCommand(IEnumerable<Resposta> respostas)
        {
            _respostas = respostas;
        }

        public Message Validate()
        {
            var avaliacaoId = _respostas.Select(resposta => resposta.AvaliacaoId).FirstOrDefault();
            var avaliacao = AvaliacaoRepository.Instance.ConsultarAvaliacao(avaliacaoId);
            if (!Avaliacao.EstaValida(avaliacao))
            {
                return MessageFactory.AvaliacaoIndisponivel();
            }
            return new Message(string.Empty, Message.Status.Success);
        }

        public void Execute(Activity currentActivity)
        {
            RespostaRepository.Instance.GravarRespostas(_respostas);
        }
    }
}