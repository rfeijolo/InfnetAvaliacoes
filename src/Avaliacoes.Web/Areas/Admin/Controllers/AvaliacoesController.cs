using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Avaliacoes.Data;
using Avaliacoes.Domain;
using System.Net;
using Avaliacoes.Web.Models.ViewModels;

namespace Avaliacoes.Web.Areas.Admin.Controllers
{
    public class AvaliacoesController : Controller
    {
        private AvaliacoesDbContext db = new AvaliacoesDbContext();

        //
        // GET: /Admin/Avaliacoes/
        public ActionResult Index()
        {
            var avaliacoes = db.Avaliacoes.Include(a => a.Coordenador);
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
            List<Disciplina> Disciplinas = db.Disciplinas.ToList();
            ViewBag.ListaDisciplinas = new MultiSelectList(Disciplinas, "Id", "Nome", null);

            ViewBag.CoordenadorId = new SelectList(db.Coordenadores, "Id", "Nome");
            return View();
        }

        //
        // POST: /Admin/Avaliacoes/Create
        [HttpPost]
        public ActionResult Create(AvaliacaoViewModel avaliacaoViewModel)
        {
            if (ModelState.IsValid)
            {
                var avaliacao = new Avaliacao();
                avaliacao.Objetivo = avaliacaoViewModel.Objetivo;
                avaliacao.DataInicio = avaliacaoViewModel.DataInicio;
                avaliacao.DataFim = avaliacaoViewModel.DataFim;
                avaliacao.CoordenadorId = avaliacaoViewModel.CoordenadorId;

                foreach (var disciplinaID in avaliacaoViewModel.DisciplinasID)
                {
                    var disciplina = db.Disciplinas.Find(disciplinaID);
                    if (disciplina != null)
                    {
                        if (avaliacao.Disciplinas == null)
                        {
                            avaliacao.Disciplinas = new List<Disciplina> {disciplina};
                        }
                        else 
                        { 
                            avaliacao.Disciplinas.Add(disciplina);
                        }
                    }
                }
                db.Avaliacoes.Add(avaliacao);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            List<Disciplina> Disciplinas = db.Disciplinas.ToList();
            ViewBag.ListaDisciplinas = new MultiSelectList(Disciplinas, "Id", "Nome", null);
            ViewBag.CoordenadorId = new SelectList(db.Coordenadores, "Id", "Nome");
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
            ViewBag.CoordenadorId = new SelectList(db.Coordenadores, "Id", "Nome", avaliacao.CoordenadorId);
            return View(avaliacao);
        }

        //
        // POST: /Admin/Avaliacoes/Edit/5
        [HttpPost]
        public ActionResult Edit(Avaliacao avaliacao)
        {
            if (ModelState.IsValid)
            {
                db.Entry(avaliacao).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CoordenadorId = new SelectList(db.Coordenadores, "Id", "Nome", avaliacao.CoordenadorId);
            return View(avaliacao);
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
