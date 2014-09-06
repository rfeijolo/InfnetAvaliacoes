using System.Collections.Generic;

namespace Avaliacoes.Domain
{
    //TODO:Merge com ApplicationUser
    public class Aluno : ApplicationUser
    {
        public virtual ICollection<Turma> Turma { get; set; }
    }
}
