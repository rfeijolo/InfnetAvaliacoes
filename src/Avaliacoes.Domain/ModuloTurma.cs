using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Avaliacoes.Domain
{
    public class ModuloTurma
    {
        //public int Id { get; set; }
        [Key, Column(Order = 0)]
        public int TurmaId { get; set; }
        [Key, Column(Order = 1)]
        public int ModuloId { get; set; }
        [Key, Column(Order = 2)]
        public int ProfessorId { get; set; }
        //[Key, Column(Order = 3)]
        public int AvaliacaoId { get; set; }

        [ForeignKey("TurmaId")]
        public virtual Turma Turma { get; set; }
        [ForeignKey("ModuloId")]
        public virtual Modulo Modulo { get; set; }
        [ForeignKey("ProfessorId")]
        public virtual Professor Professor { get; set; }
        [ForeignKey("AvaliacaoId")]
        public virtual Avaliacao Avaliacao { get; set; }
    }
}