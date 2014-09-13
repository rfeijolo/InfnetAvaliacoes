using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Avaliacoes.Domain;

namespace Avaliacoes.Web.Models
{
    public class AvaliacaoRespostaViewModel
    {
        public Avaliacao Avaliacao { get; set; }
        public IEnumerable<Questao> Questao { get; set; }
        public QuestaoRespostaViewModel QuestaoRespostas { get; set; }
    }

    public class QuestaoRespostaViewModel
    {
        public int AvaliacaoId { get; set; }
        public int QuestaoId { get; set; }
        public int RespostaId { get; set; }
    }

    
}