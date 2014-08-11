using System.ComponentModel.DataAnnotations;
namespace Avaliacoes.Domain
{
    public class Resposta
    {
        public int Id { get; set; }
        public Questao Questao { get; set; }
        [Range(1, 5)]
        public int OpcaoEscolhida { get; set; }
        public virtual Aluno Aluno { get; set; }
        public virtual Avaliacao Avaliacao { get; set; }
    }
}
