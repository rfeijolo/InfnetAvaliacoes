using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Avaliacoes.Domain
{
    public class Disciplina
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public virtual ICollection<Avaliacao> Avaliacoes { get; set; }
    }
}
