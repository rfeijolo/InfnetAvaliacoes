using System.Collections.Generic;
namespace Avaliacoes.Domain
{
    public class Turma
    {
        public int Id { get; set; }
        public string Codigo { get; set; }
        public virtual ICollection<Aluno> Alunos { get; set; }
    }
}
