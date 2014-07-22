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
            SeedTopicosAvaliacao(context);
            SeedQuestoes(context);
            base.Seed(context);
        }

        private static void SeedTopicosAvaliacao(AvaliacoesDbContext context)
        {
            var topicos = new List<TopicoAvaliacao>
            {
                new TopicoAvaliacao{Descricao = "Quanto ao desenvolvimento do curso"},
                new TopicoAvaliacao{Descricao = "Quanto aos recursos auxiliares e tempo"},
                new TopicoAvaliacao{Descricao = "Quanto a avaliacação"},
            };
            
            topicos.ForEach(topico => context.Topicos.Add(topico));
            context.SaveChanges();
        }


        private static void SeedQuestoes(AvaliacoesDbContext context)
        {
            var questoes = new List<Questao>
            {
                new Questao{Texto = "A motivação dos alunos foi adequada para a compreensão?", TopicoAvaliacaoId = 1},
                new Questao{Texto = "Perguntas formuladas pelo professor focalizaram, estimularam e desencadearam novas idéias?", TopicoAvaliacaoId = 1},
                new Questao{Texto = "As idéias principais foram retomadas, resumidas, esclarecidas ou completadas, quando necessário?", TopicoAvaliacaoId = 1},
                new Questao{Texto = "Os exemplos utilizados foram ilustrativos, simples, relevantes e ajustados aos conceitos principais?", TopicoAvaliacaoId = 1},
                new Questao{Texto = "O vocabulário utilizado na apresentação foi preciso, correto, sendo traduzido quando necessário?", TopicoAvaliacaoId = 1},
                new Questao{Texto = "O professor demonstrou domínio suficiente aos assuntos abordados?", TopicoAvaliacaoId = 1},
                new Questao{Texto = "Qual o grau de profundidade que foi desenvolvido o curso?", TopicoAvaliacaoId = 1},
                new Questao{Texto = "As técnicas de ensino utilizadas foram adequadas aos objetivos propostos?", TopicoAvaliacaoId = 1},

                new Questao{Texto = "A data proposta foi adequada?", TopicoAvaliacaoId = 2},
                new Questao{Texto = "O prazo (tempo do curso) foi adequado?", TopicoAvaliacaoId = 2},
                new Questao{Texto = "Adequação da quantidade de alunos.", TopicoAvaliacaoId = 2},
                new Questao{Texto = "Os textos foram adequados, preparados e utilizados?", TopicoAvaliacaoId = 2},
                new Questao{Texto = "O uso do material foi relevante para melhorar a aprendizagem do conteúdo?", TopicoAvaliacaoId = 2},
                new Questao{Texto = "Os recursos audiovisuais foram utilizados adequadamente?", TopicoAvaliacaoId = 2},
                new Questao{Texto = "As instalações físicas foram suficientes para um bom desenvolvimento do curso?", TopicoAvaliacaoId = 2},

                new Questao{Texto = "As avaliações foram feitas de forma periódica, facilitando a compreensão e o entendimento do assunto?", TopicoAvaliacaoId = 3},
                new Questao{Texto = "As avaliações foram adequadas aos objetivos propostos?", TopicoAvaliacaoId = 3},
                new Questao{Texto = "Qual é o seu grau de interesse em outros cursos?", TopicoAvaliacaoId = 3}
            };
            questoes.ForEach(questao => context.Questoes.Add(questao));
            context.SaveChanges();
        }

        private static void SeedCoordenadores(AvaliacoesDbContext context)
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