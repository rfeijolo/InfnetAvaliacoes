using System.Collections.Generic;

namespace Avaliacoes.Domain
{
    public class Professor
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public virtual ICollection<Disciplina> Disciplinas { get; set; }
        
    }
}
