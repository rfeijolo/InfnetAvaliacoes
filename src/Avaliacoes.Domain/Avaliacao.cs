using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Avaliacoes.Domain
{
    public class Avaliacao
    {
        public int Id { get; set; }
        public string Objetivo { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime DataFim { get; set; }

        public Situacao Situacao
        {
            get
            {
                if (DateTime.Now < DataInicio)
                {
                    return Situacao.Agendada;
                }
                if (DateTime.Now >= DataInicio && DateTime.Now <= DataFim)
                {
                    return Situacao.Disponivel;
                }
                return Situacao.Finalizada;
            }
        }
        public virtual ICollection<Questao> Questoes { get; set; }
        public virtual ICollection<ModuloTurma> Modulo { get; set; }

        public static bool EstaValida(Avaliacao avaliacao)
        {
            return avaliacao != null && avaliacao.Situacao == Situacao.Disponivel;
        }
    }
}
