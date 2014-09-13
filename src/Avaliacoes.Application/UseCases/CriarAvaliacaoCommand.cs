using Avaliacoes.Application.Generic;
using Avaliacoes.Data;
using Avaliacoes.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Avaliacoes.Application.UseCases
{
    public class CriarAvaliacaoCommand : ICommand
    {
        private Avaliacao _avaliacao;
        private ICollection<int> _modulosIds;
        private ICollection<int> _questoesIds;

        public CriarAvaliacaoCommand(Avaliacao avaliacao, ICollection<int> modulosIds, ICollection<int> questoesIds)
        {
            _avaliacao = avaliacao;
            _modulosIds = modulosIds;
            _questoesIds = questoesIds;
        }

        public Message Validate()
        {
            return MessageFactory.CadastroEfetuadoSucesso();
        }

        public void Execute(Activity currentActivity)
        {
            foreach (var questaoID in _questoesIds)
            {
                var questao = QuestaoRepository.Instance.ConsultarQuestao(questaoID);
                if (questao != null)
                {
                    if (_avaliacao.Questoes == null)
                    {
                        _avaliacao.Questoes = new List<Questao> { questao };
                    }
                    else
                    {
                        _avaliacao.Questoes.Add(questao);
                    }
                }
            }

            AvaliacaoRepository.Instance.AdicionarAvaliacao(_avaliacao);
            
        }
    }
}
