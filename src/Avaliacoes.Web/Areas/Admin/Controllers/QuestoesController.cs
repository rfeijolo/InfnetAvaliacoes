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
using Avaliacoes.Application.UseCases;

namespace Avaliacoes.Web.Areas.Admin.Controllers
{
    [Authorize(Roles = "admin")]
    public class QuestoesController : Controller
    {
        private AvaliacoesDbContext db = new AvaliacoesDbContext();

        // GET: Admin/Questao
        public ActionResult Index()
        {
            var questoes = db.Questoes.Include(q => q.TopicoAvaliacao);
            return View(questoes.ToList());
        }

        // GET: Admin/Questao/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Questao questao = db.Questoes.Find(id);
            if (questao == null)
            {
                return HttpNotFound();
            }
            return View(questao);
        }

        // GET: Admin/Questao/Create
        public ActionResult Create()
        {
            ViewBag.TopicoAvaliacaoId = new SelectList(db.Topicos, "Id", "Descricao");
            return View();
        }

        // POST: Admin/Questao/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Texto,TopicoAvaliacaoId")] Questao questao)
        {
            if (ModelState.IsValid)
            {

                SistemaController appController = new SistemaController();

                var message = appController.CriarQuestao(questao);

                ViewBag.Feedback = message;

                return RedirectToAction("Index");
            }

            ViewBag.TopicoAvaliacaoId = new SelectList(db.Topicos, "Id", "Descricao", questao.TopicoAvaliacaoId);
            return View(questao);
        }

        // GET: Admin/Questao/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Questao questao = db.Questoes.Find(id);
            if (questao == null)
            {
                return HttpNotFound();
            }
            ViewBag.TopicoAvaliacaoId = new SelectList(db.Topicos, "Id", "Descricao", questao.TopicoAvaliacaoId);
            return View(questao);
        }

        // POST: Admin/Questao/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Texto,TopicoAvaliacaoId")] Questao questao)
        {
            if (ModelState.IsValid)
            {
                db.Entry(questao).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.TopicoAvaliacaoId = new SelectList(db.Topicos, "Id", "Descricao", questao.TopicoAvaliacaoId);
            return View(questao);
        }

        // GET: Admin/Questao/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Questao questao = db.Questoes.Find(id);
            if (questao == null)
            {
                return HttpNotFound();
            }
            return View(questao);
        }

        // POST: Admin/Questao/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Questao questao = db.Questoes.Find(id);
            db.Questoes.Remove(questao);
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
