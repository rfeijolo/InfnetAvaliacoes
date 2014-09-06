using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Security.Policy;
using Avaliacoes.Domain;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Avaliacoes.Data
{
    public class AvaliacoesInitializer : DropCreateDatabaseIfModelChanges<AvaliacoesDbContext>
    {
        protected override void Seed(AvaliacoesDbContext context)
        {
            SeedCoordenadores(context);
            SeedTopicosAvaliacao(context);
            SeedQuestoes(context);
            SeedCursos(context);
            SeedProfessores(context);
            SeedAlunos(context);
            SeedModulos(context);
            SeedAvaliacoes(context);
            SeedBloco(context);

            SeedApplicationUsers(context);

            base.Seed(context);
        }

        private void SeedApplicationUsers(AvaliacoesDbContext context)
        {
            var adminRole = new IdentityRole { Name = "admin", Id = Guid.NewGuid().ToString() };
            context.Roles.Add(adminRole);

            var administrador = new ApplicationUser
            {
                Name = "Administrador",
                UserName = "admin@infnet.edu.br",
                Email = "admin@infnet.edu.br",
                EmailConfirmed = true,
                SecurityStamp = Guid.NewGuid().ToString(),
                PasswordHash = HashPassword,
            };

            context.Users.Add(administrador);
            administrador.Roles.Add(new IdentityUserRole { RoleId = adminRole.Id, UserId = administrador.Id });
            context.SaveChanges();
        }

        private static string HashPassword
        {
            get { return new PasswordHasher().HashPassword("mudar123!"); }
        }

        private void SeedAlunos(AvaliacoesDbContext context)
        {

            var alunoRole = new IdentityRole { Name = "aluno", Id = Guid.NewGuid().ToString() };
            context.Roles.Add(alunoRole);
            var alunos = new List<Aluno>
                {
                    new Aluno
                    {
                        Name = "Rodrigo Aiala",
                        UserName = "rodrigo.rodrigues@al.infnet.edu.br",
                        Email = "rodrigo.rodrigues@al.infnet.edu.br",
                        SecurityStamp = Guid.NewGuid().ToString(),
                        PasswordHash = HashPassword
                    },
                    new Aluno
                    {
                        Name = "Felipe Barbirato",
                        UserName = "felipe.barbirato@al.infnet.edu.br",
                        Email = "felipe.barbirato@al.infnet.edu.br",
                        SecurityStamp = Guid.NewGuid().ToString(),
                        PasswordHash = HashPassword
                    },
                    new Aluno
                    {
                        Name = "Gabriel Berguer",
                        UserName = "gabriel.berguer@al.infnet.edu.br",
                        Email = "gabriel.berguer@al.infnet.edu.br",
                        SecurityStamp = Guid.NewGuid().ToString(),
                        PasswordHash = HashPassword
                    },
                    new Aluno
                    {
                        Name = "Diego Bastos",
                        UserName = "diego.bastos@al.infnet.edu.br",
                        Email = "diego.bastos@al.infnet.edu.br",
                        SecurityStamp = Guid.NewGuid().ToString(),
                        PasswordHash = HashPassword
                    },
                };
            alunos.ForEach(user =>
            {
                user.Roles.Add(new IdentityUserRole { RoleId = alunoRole.Id, UserId = user.Id });
                context.Users.Add(user);
            });
            alunos.ForEach(aluno => context.Alunos.Add(aluno));
            context.SaveChanges();
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

        private static void SeedModulos(AvaliacoesDbContext context)
        {
            var modulos = new List<Modulo>{
                new Modulo { Nome = "Introdução à Engenharia de Software"},
                new Modulo { Nome = "Métricas de Desenvolvimento de Software"},
                new Modulo { Nome = "Processos de Desenvolvimento de Software"},
                new Modulo { Nome = "Programação Orientada a Objetos com .NET"},
                new Modulo { Nome = "Desenvolvimento de Aplicações com .NET"},
                new Modulo { Nome = "Análise e Projeto de Sistemas Orientados a Objeto"},
                new Modulo { Nome = "Projeto de Bloco: Desenvolvimento Orientado a Objeto com .NET"},
            };

            modulos.ForEach(modulo => context.Modulos.Add(modulo));
            context.SaveChanges();
        }

        private static void SeedAvaliacoes(AvaliacoesDbContext context)
        {
            var avaliacoes = new List<Avaliacao>{
                new Avaliacao { Objetivo = "Avaliar Pós Engenharia de Software .Net", DataInicio = new System.DateTime(2014,1,1), DataFim = new System.DateTime(2015,1,1), CoordenadorId = 1
                    //,Modulos = new List<Modulo>{ 
                    //    new Modulo { Id = 1}
                    //},
                    //Questoes = new List<Questao>{
                    //    new Questao {Id = 1, TopicoAvaliacaoId = 1},
                    //    new Questao {Id = 2, TopicoAvaliacaoId = 1},
                    //    new Questao {Id = 3, TopicoAvaliacaoId = 1}
                    //}
                },
                new Avaliacao { Objetivo = "Avaliar Pós Engenharia de Software Java", DataInicio = new System.DateTime(2014,1,1), DataFim = new System.DateTime(2015,1,1), CoordenadorId = 1
                    //,Modulos = new List<Modulo>{ 
                    //    new Modulo { Id = 2},
                    //    new Modulo { Id = 3}
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

        private static void SeedBloco(AvaliacoesDbContext context)
        {
            var blocos = new List<Bloco>{
                new Bloco { Nome = "Engenharia de Software"},
                new Bloco { Nome = "Desenvolvimento Orientado a Objetos com .NET"},
                new Bloco { Nome = "Desenvolvimento Web com .NET"},
            };

            blocos.ForEach(bloco => context.Blocos.Add(bloco));
            context.SaveChanges();
        }
    }
}