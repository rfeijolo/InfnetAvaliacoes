using System.Collections.Generic;
using System.ComponentModel;

namespace Avaliacoes.Domain
{
    public class TopicoAvaliacao
    {
        public int Id { get; set; }
        [DisplayName("Tópico")]
        public string Descricao { get; set; }
        public virtual ICollection<Questao> Questoes { get; set; }
    }
}
