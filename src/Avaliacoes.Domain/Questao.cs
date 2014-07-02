using System.Collections.Generic;

namespace Avaliacoes.Domain
{
    public class Questao
    {
        public int Id { get; set; }
        public string Texto { get; set; }
        public virtual ICollection<Avaliacao> Avaliacoes { get; set; }
        public TopicoAvaliacao TopicoAvaliacao { get; set; }
    }
}
