using System.Collections.Generic;
using System.Data.Entity;
using Avaliacoes.Domain;

namespace Avaliacoes.Data
{
    public class AvaliacoesInitializer : DropCreateDatabaseIfModelChanges<AvaliacoesDbContext>
    {

        protected override void Seed(AvaliacoesDbContext context)
        {
            SeedCoordenadores(context);
            base.Seed(context);
        }

        private void SeedCoordenadores(AvaliacoesDbContext context)
        {
            var coordenadores = new List<Coordenador>
            {
                new Coordenador {Email = "aquino@infnet.edu.br", Nome = "Tomás de Aquino Tinoco Botelho"}
            };
            coordenadores.ForEach(coord => context.Coordenadores.Add(coord));
            context.SaveChanges();
        }
    }
}