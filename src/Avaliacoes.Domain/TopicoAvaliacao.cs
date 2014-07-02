using System.Collections.Generic;

namespace Avaliacoes.Domain
{
    public class TopicoAvaliacao
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
        public virtual ICollection<Questao> Questoes { get; set; }
    }
}
