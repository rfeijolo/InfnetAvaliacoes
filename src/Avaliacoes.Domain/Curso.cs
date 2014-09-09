using System.Collections.Generic;

namespace Avaliacoes.Domain
{
    public class Curso
    {
        public int Id { get; set; }
        public string Nome { get; set; }

        public ICollection<Bloco> Blocos { get; set; }
    }
}
