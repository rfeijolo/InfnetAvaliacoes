using Avaliacoes.Application.Generic;
using Avaliacoes.Data.Contracts;
using Avaliacoes.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Avaliacoes.Application.UseCases
{
    public class ActivityFactory
    {
        #region Singleton

        private static ActivityFactory instance;

        private ActivityFactory() { }

        public static ActivityFactory Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new ActivityFactory();
                }
                return instance;
            }
        }

        #endregion

        public Activity GerarAtividadeCriarQuestao(Questao questao)
        {
            return new Activity(new CriarQuestaoCommand(questao));
        }
    }
}
