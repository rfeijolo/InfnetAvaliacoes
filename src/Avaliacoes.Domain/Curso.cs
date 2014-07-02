using System.Collections.Generic;

namespace Avaliacoes.Domain
{
    public class Curso
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public virtual ICollection<Disciplina> Disciplinas { get; set; }
        public virtual ICollection<Turma> Turmas { get; set; }

    }
}
