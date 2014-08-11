using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace Avaliacoes.Domain
{
    public class Questao
    {
        public int Id { get; set; }
        public string Texto { get; set; }
        public virtual ICollection<Avaliacao> Avaliacoes { get; set; }

        
        [ForeignKey("TopicoAvaliacao"), DisplayName("Tópico")]
        public int TopicoAvaliacaoId { get; set; }
        public virtual TopicoAvaliacao TopicoAvaliacao { get; set; }
    }
}
