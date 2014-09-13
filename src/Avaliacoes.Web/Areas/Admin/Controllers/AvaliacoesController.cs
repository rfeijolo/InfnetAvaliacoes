using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using Avaliacoes.Data;
using Avaliacoes.Domain;
using System.Net;
using Avaliacoes.Web.Models.ViewModels;
using Avaliacoes.Application.UseCases;

namespace Avaliacoes.Web.Areas.Admin.Controllers
{
    [Authorize(Roles = "admin")]
    public class AvaliacoesController : Controller
    {
        private AvaliacoesDbContext db = new AvaliacoesDbContext();

        //
        // GET: /Admin/Avaliacoes/
        public ActionResult Index()
        {
            var avaliacoes = db.Avaliacoes;
            return View(avaliacoes.ToList());
        }

        //
        // GET: /Admin/Avaliacoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Avaliacao avaliacao = db.Avaliacoes.Find(id);
            if (avaliacao == null)
            {
                return HttpNotFound();
            }
            return View(avaliacao);
        }

        //
        // GET: /Admin/Avaliacoes/Create
        public ActionResult Create()
        {
            List<Modulo> modulos = db.Modulos.ToList();
            ViewBag.ListaModulos = new MultiSelectList(modulos, "Id", "Nome", null);

            List<Questao> questoes = db.Questoes.ToList();
            ViewBag.ListaQuestoes = new MultiSelectList(questoes, "Id", "Texto", null);
            return View();
        }

        //
        // POST: /Admin/Avaliacoes/Create
        [HttpPost]
        public ActionResult Create(AvaliacaoViewModel avaliacaoViewModel)
        {
            if (ModelState.IsValid)
            {
                SistemaController appController = new SistemaController();

                var avaliacao = new Avaliacao();
                avaliacao.Objetivo = avaliacaoViewModel.Objetivo;
                avaliacao.DataInicio = avaliacaoViewModel.DataInicio;
                avaliacao.DataFim = avaliacaoViewModel.DataFim;

                var message = appController.CriarAvaliacao(avaliacao, avaliacaoViewModel.ModulosID, avaliacaoViewModel.QuestoesID);

                ViewBag.Feedback = message;

                return RedirectToAction("Index");
            }

            List<Modulo> Modulos = db.Modulos.ToList();
            ViewBag.ListaModulos = new MultiSelectList(Modulos, "Id", "Nome", null);
            return View(avaliacaoViewModel);
        }

        //
        // GET: /Admin/Avaliacoes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Avaliacao avaliacao = db.Avaliacoes.Find(id);

            if (avaliacao == null)
            {
                return HttpNotFound();
            }

            var avaliacaoViewModel = new AvaliacaoViewModel();
            avaliacaoViewModel.Objetivo  = avaliacao.Objetivo;
            avaliacaoViewModel.DataInicio = avaliacao.DataInicio;
            avaliacaoViewModel.DataFim = avaliacao.DataFim;
            //avaliacaoViewModel.Modulos = avaliacao.Modulos;
            avaliacaoViewModel.Questoes = avaliacao.Questoes;

            var modulosID = new List<int>();
            //avaliacaoViewModel.Modulos.ToList().ForEach(m => modulosID.Add(m.Id));

            var questoesID = new List<int>();
            avaliacaoViewModel.Questoes.ToList().ForEach(q => questoesID.Add(q.Id));

            List<Modulo> modulos = db.Modulos.ToList();
            ViewBag.ListaModulos = new MultiSelectList(modulos, "Id", "Nome", modulosID);

            List<Questao> questoes = db.Questoes.ToList();
            ViewBag.ListaQuestoes = new MultiSelectList(questoes, "Id", "Texto", questoesID);

            return View(avaliacaoViewModel);
        }

        //
        // POST: /Admin/Avaliacoes/Edit/5
        [HttpPost]
        public ActionResult Edit(AvaliacaoViewModel avaliacaoViewModel)
        {
            if (ModelState.IsValid)
            {

                var avaliacao = new Avaliacao();
                avaliacao.Id = avaliacaoViewModel.Id;
                avaliacao.Objetivo = avaliacaoViewModel.Objetivo;
                avaliacao.DataInicio = avaliacaoViewModel.DataInicio;
                avaliacao.DataFim = avaliacaoViewModel.DataFim;

                foreach (var moduloID in avaliacaoViewModel.ModulosID)
                {
                    var modulo = db.Modulos.Find(moduloID);
                    if (modulo != null)
                    {
                        //if (avaliacao.Modulos == null)
                        //{
                        //    avaliacao.Modulos = new List<Modulo> { modulo };
                        //}
                        //else
                        //{
                        //    avaliacao.Modulos.Add(modulo);
                        //}
                    }
                }

                foreach (var questaoID in avaliacaoViewModel.QuestoesID)
                {
                    var questao = db.Questoes.Find(questaoID);
                    if (questao != null)
                    {
                        if (avaliacao.Questoes == null)
                        {
                            avaliacao.Questoes = new List<Questao> { questao };
                        }
                        else
                        {
                            avaliacao.Questoes.Add(questao);
                        }
                    }
                }

                db.Entry(avaliacao).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(avaliacaoViewModel);
        }

        //
        // GET: /Admin/Avaliacoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Avaliacao avaliacao = db.Avaliacoes.Find(id);
            if (avaliacao == null)
            {
                return HttpNotFound();
            }
            return View(avaliacao);
        }

        //
        // POST: /Admin/Avaliacoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Avaliacao avaliacao = db.Avaliacoes.Find(id);
            if (avaliacao == null)
            {
                return HttpNotFound();
            }
            db.Avaliacoes.Remove(avaliacao);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
