namespace Avaliacoes.Domain
{
    public class Opcao
    {
        public int Id { get; set; }
        public string Texto { get; set; }
        public Questao Questao { get; set; }
    }
}
