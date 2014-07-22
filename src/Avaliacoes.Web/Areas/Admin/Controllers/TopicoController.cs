using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using Avaliacoes.Domain;
using Avaliacoes.Data;

namespace Avaliacoes.Web.Areas.Admin.Controllers
{
    public class TopicoController : Controller
    {
        private AvaliacoesDbContext db = new AvaliacoesDbContext();

        // GET: /Admin/Topico/
        public ActionResult Index()
        {
            return View(db.Topicos.ToList());
        }

        // GET: /Admin/Topico/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TopicoAvaliacao topicoavaliacao = db.Topicos.Find(id);
            if (topicoavaliacao == null)
            {
                return HttpNotFound();
            }
            return View(topicoavaliacao);
        }

        // GET: /Admin/Topico/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /Admin/Topico/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="Id,Descricao")] TopicoAvaliacao topicoavaliacao)
        {
            if (ModelState.IsValid)
            {
                db.Topicos.Add(topicoavaliacao);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(topicoavaliacao);
        }

        // GET: /Admin/Topico/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TopicoAvaliacao topicoavaliacao = db.Topicos.Find(id);
            if (topicoavaliacao == null)
            {
                return HttpNotFound();
            }
            return View(topicoavaliacao);
        }

        // POST: /Admin/Topico/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="Id,Descricao")] TopicoAvaliacao topicoavaliacao)
        {
            if (ModelState.IsValid)
            {
                db.Entry(topicoavaliacao).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(topicoavaliacao);
        }

        // GET: /Admin/Topico/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TopicoAvaliacao topicoavaliacao = db.Topicos.Find(id);
            if (topicoavaliacao == null)
            {
                return HttpNotFound();
            }
            return View(topicoavaliacao);
        }

        // POST: /Admin/Topico/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TopicoAvaliacao topicoavaliacao = db.Topicos.Find(id);
            db.Topicos.Remove(topicoavaliacao);
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
