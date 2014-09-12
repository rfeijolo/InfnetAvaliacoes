using System.Web.Mvc;
using Avaliacoes.Application.UseCases;
using Microsoft.AspNet.Identity;

namespace Avaliacoes.Web.Controllers
{
    [Authorize]
    public class AvaliacaoController : Controller
    {
        public ActionResult Index()
        {
            var avaliacoes = new SistemaController().ConsultarAvaliacoesDisponiveisPorAluno(User.Identity.GetUserId());
            return View(avaliacoes);
        }
        
        public ActionResult Responder(int avaliacaoId)
        {
            var avaliacao = new SistemaController().ConsultarAvaliacao(avaliacaoId);
            return View(avaliacao);
        }


    }
}