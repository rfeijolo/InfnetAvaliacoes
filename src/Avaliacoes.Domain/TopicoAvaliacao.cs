using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Avaliacoes.Domain
{
    public class TopicoAvaliacao
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
        public virtual ICollection<Questao> Questoes { get; set; }
    }
}
