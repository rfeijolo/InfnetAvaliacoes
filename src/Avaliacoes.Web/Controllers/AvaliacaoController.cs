using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Avaliacoes.Application.Generic;
using Avaliacoes.Application.UseCases;
using Avaliacoes.Domain;
using Avaliacoes.Web.Models;
using Microsoft.Ajax.Utilities;
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

        public ActionResult Responder(int? avaliacaoId = null)
        {
            if (avaliacaoId == null)
            {
                return RedirectToAction("Index");
            }
            var avaliacao = new SistemaController().ConsultarAvaliacao(avaliacaoId.Value);
            if (avaliacao == null)
            {
                return HttpNotFound();
            }
            return View(avaliacao);
        }

        public ActionResult EnviarResposta(IEnumerable<QuestaoRespostaViewModel> respostaQuestao)
        {
            var respostas = new List<Resposta>();

            respostaQuestao.ToList().ForEach(resp => respostas.Add(new Resposta
            {
                AlunoId = User.Identity.GetUserId(),
                QuestaoId = resp.QuestaoId,
                OpcaoEscolhida = (Likert)resp.RespostaId,
                AvaliacaoId = resp.AvaliacaoId
            }));
            var msg = new SistemaController().GravarRespostas(respostas);
            if (msg.CurrentStatus == Message.Status.Success)
            {
                return RedirectToAction("Index");
            }
            return RedirectToAction("Error");
        }


    }
}