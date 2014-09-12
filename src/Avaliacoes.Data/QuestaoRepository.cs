using Antlr.Runtime;
using Avaliacoes.Domain;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Avaliacoes.Data
{
    public class QuestaoRepository
    {
        #region Singleton

        private static QuestaoRepository instance;

        private QuestaoRepository() { }

        public static QuestaoRepository Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new QuestaoRepository();
                }
                return instance;
            }
        }

        #endregion

        private AvaliacoesDbContext db = new AvaliacoesDbContext();

        public void AdicionarQuestao(Questao questao)
        {
            db.Questoes.Add(questao);
            db.SaveChanges();
        }

    }
}
