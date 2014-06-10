using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
