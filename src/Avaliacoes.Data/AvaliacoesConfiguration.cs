using System.Data.Entity;

namespace Avaliacoes.Data
{
    public class AvaliacoesConfiguration : DbConfiguration
    {
        public AvaliacoesConfiguration()
        {
            SetDatabaseInitializer(new AvaliacoesInitializer());
        }
    }
}