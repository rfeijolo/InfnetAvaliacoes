using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Avaliacoes.Domain
{
    public class Questao
    {
        public int Id { get; set; }
        public string Texto { get; set; }
        public virtual ICollection<Avaliacao> Avaliacoes { get; set; }

        
        [ForeignKey("TopicoAvaliacao")]
        public int TopicoAvaliacaoId { get; set; }
        public TopicoAvaliacao TopicoAvaliacao { get; set; }
    }
}
