﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Avaliacoes.Domain
{
    public class Resposta
    {
        public int Id { get; set; }
        public int QuestaoId { get; set; }

        public Likert OpcaoEscolhida { get; set; }

        public string AlunoId { get; set; }
        [ForeignKey("AlunoId")]
        public virtual Aluno Aluno { get; set; }
        [ForeignKey("QuestaoId")]
        public Questao Questao { get; set; }

        public int AvaliacaoId { get; set; }
        public Avaliacao Avaliacao { get; set; }
    }
}
