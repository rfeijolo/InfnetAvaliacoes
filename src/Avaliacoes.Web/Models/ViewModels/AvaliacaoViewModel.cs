using Avaliacoes.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Avaliacoes.Web.Models.ViewModels
{
    public class AvaliacaoViewModel : Avaliacao
    {
        public ICollection<int> ModulosID { get; set; }
    }
}