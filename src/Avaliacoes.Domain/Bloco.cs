using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Avaliacoes.Domain
{
    public class Bloco
    {
        public int Id { get; set; }
        public string Nome { get; set; }

        [ForeignKey("Curso"), Required, Display(Name = "Curso")]
        public int CursoId { get; set; }
        public virtual Curso Curso { get; set; }

        public ICollection<Modulo> Modulos { get; set; }
    }
}
