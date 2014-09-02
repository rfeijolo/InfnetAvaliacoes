using System.Collections.Generic;

namespace Avaliacoes.Domain
{
    //TODO:Merge com ApplicationUser
    public class Aluno
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public virtual ICollection<Turma> Turma { get; set; }
    }
}
