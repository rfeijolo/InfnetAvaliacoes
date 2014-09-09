using System.Collections.Generic;

namespace Avaliacoes.Domain
{
    public class Modulo
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public virtual ICollection<Turma> Turmas { get; set; }
        public virtual ICollection<Avaliacao> Avaliacoes { get; set; }
    }
}
