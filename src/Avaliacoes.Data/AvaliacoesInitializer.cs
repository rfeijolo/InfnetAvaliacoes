using System.Collections.Generic;
using System.Data.Entity;
using Avaliacoes.Domain;
using System.Threading.Tasks;

namespace Avaliacoes.Data
{
    public class AvaliacoesInitializer : DropCreateDatabaseAlways<AvaliacoesDbContext>
    {
        protected override void Seed(AvaliacoesDbContext context)
        {
            SeedCoordenadores(context);
            SeedTopicosAvaliacao(context);
            SeedQuestoes(context);
            SeedCursos(context);
            SeedProfessores(context);
            SeedAlunos(context);
            SeedDisciplinas(context);
            SeedAvaliacoes(context);
            base.Seed(context);
        }

        private void SeedAlunos(AvaliacoesDbContext context)
        {
            var alunos = new List<Aluno>{
                new Aluno{ Nome = "Rodrigo Aiala", Email="rodrigo.aiala@al.infnet.edu.br" },
                new Aluno{ Nome = "Felipe Barbirato", Email="felipe.barbirato@al.infnet.edu.br" },
                new Aluno{ Nome = "Gabriel Berguer", Email="gabriel.berguer@al.infnet.edu.br" },
                new Aluno{ Nome = "Diego Bastos", Email="diego.bastos@al.infnet.edu.br" },
            };
            alunos.ForEach(aluno => context.Alunos.Add(aluno));
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

        private static void SeedCursos(AvaliacoesDbContext context)
        {
            var cursos = new List<Curso>{
                new Curso{ Nome = "Engenharia de Software .NET" },
                new Curso{ Nome = "Engenharia de Software JAVA"},
                new Curso { Nome = "Engenharia de Redes"},
                new Curso {Nome = "Design Digital"}
            };

            cursos.ForEach(curso => context.Cursos.Add(curso));
            context.SaveChanges();
        }

        private static void SeedProfessores(AvaliacoesDbContext context)
        {
            var professores = new List<Professor>{
                new Professor { Nome = "Pier-Giovanni taranti"},
                new Professor { Nome = "Carlos Pedro Muniz"},
                new Professor { Nome = "Rogério Magela"},
                new Professor { Nome = "Rafael Mello"},
            };

            professores.ForEach(professor => context.Professores.Add(professor));
            context.SaveChanges();
        }

        private static void SeedDisciplinas(AvaliacoesDbContext context)
        {
            var disciplinas = new List<Disciplina>{
                new Disciplina { Nome = "Introdução à Engenharia de Software"},
                new Disciplina { Nome = "Métricas de Desenvolvimento de Software"},
                new Disciplina { Nome = "Processos de Desenvolvimento de Software"},
                new Disciplina { Nome = "Programação Orientada a Objetos com .NET"},
                new Disciplina { Nome = "Desenvolvimento de Aplicações com .NET"},
                new Disciplina { Nome = "Análise e Projeto de Sistemas Orientados a Objeto"},
                new Disciplina { Nome = "Projeto de Bloco: Desenvolvimento Orientado a Objeto com .NET"},
            };

            disciplinas.ForEach(disciplina => context.Disciplinas.Add(disciplina));
            context.SaveChanges();
        }

        private static void SeedAvaliacoes(AvaliacoesDbContext context)
        {
            try
            {
                var avaliacoes = new List<Avaliacao>{
                new Avaliacao { Objetivo = "Avaliar Pós Engenharia de Software .Net", DataInicio = new System.DateTime(2014,1,1), DataFim = new System.DateTime(2015,1,1), CoordenadorId = 1
                    //,Disciplinas = new List<Disciplina>{ 
                    //    new Disciplina { Id = 1}
                    //},
                    //Questoes = new List<Questao>{
                    //    new Questao {Id = 1, TopicoAvaliacaoId = 1},
                    //    new Questao {Id = 2, TopicoAvaliacaoId = 1},
                    //    new Questao {Id = 3, TopicoAvaliacaoId = 1}
                    //}
                },
                new Avaliacao { Objetivo = "Avaliar Pós Engenharia de Software Java", DataInicio = new System.DateTime(2014,1,1), DataFim = new System.DateTime(2015,1,1), CoordenadorId = 1
                    //,Disciplinas = new List<Disciplina>{ 
                    //    new Disciplina { Id = 2},
                    //    new Disciplina { Id = 3}
                    //},
                    //Questoes = new List<Questao>{
                    //    new Questao {Id = 4, TopicoAvaliacaoId = 1},
                    //    new Questao {Id = 5, TopicoAvaliacaoId = 1},
                    //    new Questao {Id = 6, TopicoAvaliacaoId = 1}
                    //}
                },
            };

                avaliacoes.ForEach(avaliacao => context.Avaliacoes.Add(avaliacao));
                context.SaveChanges();
            }
            catch (System.Exception ex)
            {
                throw;
            }

        }
    }
}