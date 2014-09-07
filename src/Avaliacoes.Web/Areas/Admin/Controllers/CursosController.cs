using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Avaliacoes.Data;
using Avaliacoes.Domain;
using Avaliacoes.Web.Models.ViewModels;

namespace Avaliacoes.Web.Areas.Admin.Controllers
{
    [Authorize(Roles = "admin")]
    public class CursosController : Controller
    {
        private AvaliacoesDbContext db = new AvaliacoesDbContext();

        // GET: Admin/Cursos
        public ActionResult Index()
        {
            return View(db.Cursos.ToList());
        }

        // GET: Admin/Cursos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Curso curso = db.Cursos.Where(c => c.Id == id)
                                   .Include(c => c.Blocos)
                                   .FirstOrDefault();

            if (curso == null)
            {
                return HttpNotFound();
            }

            return View(curso);
        }

        // GET: Admin/Cursos/Create
        public ActionResult Create()
        {
            var blocos = db.Blocos.ToList();
            ViewBag.ListaBlocos = new MultiSelectList(blocos, "Id", "Nome", null);

            return View();
        }

        // POST: Admin/Cursos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Nome,BlocosID")] CursoViewModel cursoViewModel)
        {
            if (ModelState.IsValid)
            {
                var curso = new Curso();
                curso.Nome = cursoViewModel.Nome;

                if (cursoViewModel.BlocosId.Count > 0)
                {
                    curso.Blocos = new List<Bloco>();
                    foreach (int blocoId in cursoViewModel.BlocosId)
                    {
                        var bloco = db.Blocos.Find(blocoId);
                        if (bloco != null)
                        {
                            curso.Blocos.Add(bloco);
                        }
                    }
                }

                db.Cursos.Add(curso);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            var blocos = db.Blocos.ToList();
            ViewBag.ListaBlocos = new MultiSelectList(blocos, "Id", "Nome", null);

            return View(cursoViewModel);
        }

        // GET: Admin/Cursos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Curso curso = db.Cursos.Where(c => c.Id == id)
                                   .Include(c => c.Blocos)
                                   .FirstOrDefault();
            if (curso == null)
            {
                return HttpNotFound();
            }

            var cursoViewModel = new CursoViewModel();
            cursoViewModel.Nome = curso.Nome;
            cursoViewModel.Blocos = curso.Blocos;

            List<int> blocosId = null;
            if (cursoViewModel.Blocos != null)
            {
                blocosId = new List<int>();
                cursoViewModel.Blocos.ToList().ForEach(b => blocosId.Add(b.Id));
            }

            var blocos = db.Blocos.ToList();
            ViewBag.ListaBlocos = new MultiSelectList(blocos, "Id", "Nome", blocosId);

            return View(cursoViewModel);
        }

        // POST: Admin/Cursos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Nome,BlocosId")] CursoViewModel cursoViewModel)
        {
            if (ModelState.IsValid)
            {

                var curso = new Curso();
                curso.Id = cursoViewModel.Id;
                curso.Nome = cursoViewModel.Nome;

                if (cursoViewModel.BlocosId.Count > 0)
                {
                    curso.Blocos = new List<Bloco>();
                    foreach (int blocoId in cursoViewModel.BlocosId)
                    {
                        var bloco = db.Blocos.Find(blocoId);
                        if (bloco != null)
                        {
                            curso.Blocos.Add(bloco);
                        }
                    }
                }

                db.Entry(curso).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            var blocos = db.Blocos.ToList();
            ViewBag.ListaBlocos = new MultiSelectList(blocos, "Id", "Nome", null);

            return View(cursoViewModel);
        }

        // GET: Admin/Cursos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Curso curso = db.Cursos.Find(id);
            if (curso == null)
            {
                return HttpNotFound();
            }
            return View(curso);
        }

        // POST: Admin/Cursos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Curso curso = db.Cursos.Find(id);
            db.Cursos.Remove(curso);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
