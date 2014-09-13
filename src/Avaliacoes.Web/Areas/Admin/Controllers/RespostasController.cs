using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Avaliacoes.Domain;
using Avaliacoes.Data;

namespace Avaliacoes.Web.Areas.Admin.Controllers
{
    public class RespostasController : Controller
    {
        private AvaliacoesDbContext db = new AvaliacoesDbContext();

        // GET: /Admin/Respostas/
        public ActionResult Index()
        {
            var respostas = db.Respostas.Include(r => r.Aluno).Include(r => r.Avaliacao).Include(r => r.Questao);
            return View(respostas.ToList());
        }

        // GET: /Admin/Respostas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Resposta resposta = db.Respostas.Find(id);
            if (resposta == null)
            {
                return HttpNotFound();
            }
            return View(resposta);
        }

        // GET: /Admin/Respostas/Create
        public ActionResult Create()
        {
            ViewBag.AlunoId = new SelectList(db.Users, "Id", "Name");
            ViewBag.AvaliacaoId = new SelectList(db.Avaliacoes, "Id", "Objetivo");
            ViewBag.QuestaoId = new SelectList(db.Questoes, "Id", "Texto");
            return View();
        }

        // POST: /Admin/Respostas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="Id,QuestaoId,OpcaoEscolhida,AlunoId,AvaliacaoId")] Resposta resposta)
        {
            if (ModelState.IsValid)
            {
                db.Respostas.Add(resposta);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AlunoId = new SelectList(db.Users, "Id", "Name", resposta.AlunoId);
            ViewBag.AvaliacaoId = new SelectList(db.Avaliacoes, "Id", "Objetivo", resposta.AvaliacaoId);
            ViewBag.QuestaoId = new SelectList(db.Questoes, "Id", "Texto", resposta.QuestaoId);
            return View(resposta);
        }

        // GET: /Admin/Respostas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Resposta resposta = db.Respostas.Find(id);
            if (resposta == null)
            {
                return HttpNotFound();
            }
            ViewBag.AlunoId = new SelectList(db.Users, "Id", "Name", resposta.AlunoId);
            ViewBag.AvaliacaoId = new SelectList(db.Avaliacoes, "Id", "Objetivo", resposta.AvaliacaoId);
            ViewBag.QuestaoId = new SelectList(db.Questoes, "Id", "Texto", resposta.QuestaoId);
            return View(resposta);
        }

        // POST: /Admin/Respostas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="Id,QuestaoId,OpcaoEscolhida,AlunoId,AvaliacaoId")] Resposta resposta)
        {
            if (ModelState.IsValid)
            {
                db.Entry(resposta).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AlunoId = new SelectList(db.Users, "Id", "Name", resposta.AlunoId);
            ViewBag.AvaliacaoId = new SelectList(db.Avaliacoes, "Id", "Objetivo", resposta.AvaliacaoId);
            ViewBag.QuestaoId = new SelectList(db.Questoes, "Id", "Texto", resposta.QuestaoId);
            return View(resposta);
        }

        // GET: /Admin/Respostas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Resposta resposta = db.Respostas.Find(id);
            if (resposta == null)
            {
                return HttpNotFound();
            }
            return View(resposta);
        }

        // POST: /Admin/Respostas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Resposta resposta = db.Respostas.Find(id);
            db.Respostas.Remove(resposta);
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
