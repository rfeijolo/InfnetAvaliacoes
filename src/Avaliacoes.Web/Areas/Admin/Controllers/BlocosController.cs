using Avaliacoes.Data;
using Avaliacoes.Domain;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Avaliacoes.Web.Areas.Admin.Controllers
{
    public class BlocosController : Controller
    {
        private AvaliacoesDbContext db = new AvaliacoesDbContext();

        //
        // GET: /Admin/Blocos/
        public ActionResult Index()
        {
            var blocos = db.Blocos;
            return View(blocos.ToList());
        }

        //
        // GET: /Admin/Blocos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bloco bloco = db.Blocos.Find(id);
            if (bloco == null)
            {
                return HttpNotFound();
            }
            return View(bloco);
        }

        //
        // GET: /Admin/Blocos/Create
        public ActionResult Create()
        {
            CreateCursosInViewBag();
            return View();
        }

        private void CreateCursosInViewBag(int? selectedValue = null)
        {
            var cursos = db.Cursos;
            ViewBag.Cursos = selectedValue.HasValue
                ? new SelectList(cursos, "Id", "Nome", selectedValue.Value)
                : new SelectList(cursos, "Id", "Nome");
        }

        //
        // POST: /Admin/Blocos/Create
        [HttpPost]
        public ActionResult Create(Bloco bloco)
        {
            if (ModelState.IsValid)
            {
                db.Blocos.Add(bloco);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(bloco);
        }

        //
        // GET: /Admin/Blocos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var bloco = db.Blocos.Find(id);
            if (bloco == null)
            {
                return HttpNotFound();
            }
            CreateCursosInViewBag(bloco.CursoId);
            return View(bloco);
        }

        //
        // POST: /Admin/Blocos/Edit/5
        [HttpPost]
        public ActionResult Edit(Bloco bloco)
        {
            if (ModelState.IsValid)
            {
                db.Entry(bloco).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(bloco);
        }

        //
        // GET: /Admin/Blocos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bloco bloco = db.Blocos.Find(id);
            if (bloco == null)
            {
                return HttpNotFound();
            }
            return View(bloco);
        }

        // POST: Admin/Blocos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Bloco bloco = db.Blocos.Find(id);
            db.Blocos.Remove(bloco);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
