using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Avaliacoes.Domain
{
    public class ModuloTurma
    {
        public int Id { get; set; }

        public int TurmaId { get; set; }
        public int ModuloId { get; set; }
        public int ProfessorId { get; set; }
        public int AvaliacaoId { get; set; }

        [ForeignKey("TurmaId")]
        public virtual Turma Turma { get; set; }
        [ForeignKey("ModuloId")]
        public virtual Modulo Modulo { get; set; }
        [ForeignKey("ProfessorId")]
        public Professor Professor { get; set; }
        [ForeignKey("AvaliacaoId")]
        public Avaliacao Avaliacao { get; set; }
    }
}