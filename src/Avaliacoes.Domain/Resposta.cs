using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Avaliacoes.Domain
{
    public class Resposta
    {
        public int Id { get; set; }
        public Questao Questao { get; set; }
        public Opcao OpcaoEscolhida { get; set; }
        public Aluno Aluno { get; set; }
        public Avaliacao Avaliacao { get; set; }


    }
}
