using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using Avaliacoes.Domain;
using Avaliacoes.Data;

namespace Avaliacoes.Web.Areas.Admin.Controllers
{
    //TODO: Somente role administrador
    [Authorize]
    public class CoordenadorController : Controller
    {
        private readonly AvaliacoesDbContext _dbContext = new AvaliacoesDbContext();

        // GET: /Admin/Coordenador/
        public ActionResult Index()
        {
            return View(_dbContext.Coordenadores.ToList());
        }

        // GET: /Admin/Coordenador/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Coordenador coordenador = _dbContext.Coordenadores.Find(id);
            if (coordenador == null)
            {
                return HttpNotFound();
            }
            return View(coordenador);
        }

        // GET: /Admin/Coordenador/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /Admin/Coordenador/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="Id,Nome,Email")] Coordenador coordenador)
        {
            if (ModelState.IsValid)
            {
                _dbContext.Coordenadores.Add(coordenador);
                _dbContext.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(coordenador);
        }

        // GET: /Admin/Coordenador/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Coordenador coordenador = _dbContext.Coordenadores.Find(id);
            if (coordenador == null)
            {
                return HttpNotFound();
            }
            return View(coordenador);
        }

        // POST: /Admin/Coordenador/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="Id,Nome,Email")] Coordenador coordenador)
        {
            if (ModelState.IsValid)
            {
                _dbContext.Entry(coordenador).State = EntityState.Modified;
                _dbContext.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(coordenador);
        }

        // GET: /Admin/Coordenador/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Coordenador coordenador = _dbContext.Coordenadores.Find(id);
            if (coordenador == null)
            {
                return HttpNotFound();
            }
            return View(coordenador);
        }

        // POST: /Admin/Coordenador/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Coordenador coordenador = _dbContext.Coordenadores.Find(id);
            _dbContext.Coordenadores.Remove(coordenador);
            _dbContext.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _dbContext.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
