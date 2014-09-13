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

        public void AdicionarQuestao(Questao questao)
        {
            using (var db = new AvaliacoesDbContext())
            {
                db.Questoes.Add(questao);
                db.SaveChanges();
            }
        }

        public Questao ConsultarQuestao(int questaoId)
        {
            using (var db = new AvaliacoesDbContext())
            {
                return db.Questoes.Find(questaoId);
            }
        }

    }
}
