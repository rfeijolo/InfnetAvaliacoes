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
            return View();
        }

        //
        // GET: /Admin/Avaliacoes/Create
        public ActionResult Create()
        {
            ViewBag.CoordenadorId = new SelectList(db.Coordenadores, "Id", "Nome");
            return View();
        }

        //
        // POST: /Admin/Avaliacoes/Create
        [HttpPost]
        public ActionResult Create(Avaliacao avaliacao)
        {
            if (ModelState.IsValid)
            {
                db.Avaliacoes.Add(avaliacao);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CoordenadorId = new SelectList(db.Coordenadores, "Id", "Nome");
            return View(avaliacao);
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
            ViewBag.CoordenadorId = new SelectList(db.Coordenadores, "Id", "Nome");
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

            ViewBag.CoordenadorId = new SelectList(db.Coordenadores, "Id", "Nome");
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
