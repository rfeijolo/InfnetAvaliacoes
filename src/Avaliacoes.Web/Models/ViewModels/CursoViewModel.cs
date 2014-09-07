using Avaliacoes.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Avaliacoes.Web.Models.ViewModels
{
    public class CursoViewModel : Curso
    {
        public ICollection<int> BlocosId { get; set; }
    }
}