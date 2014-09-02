using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Avaliacoes.Data;
using Avaliacoes.Web.Models;
using Avaliacoes.Web.Resources;
using Microsoft.AspNet.Identity;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity.Owin;

namespace Avaliacoes.Web.Areas.Admin.Controllers
{
    public class AlunosController : Controller
    {
        private ApplicationUserManager _userManager;
        //TODO: Refatorar, merge com AccountController
        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }
        private void AddErrors(IdentityResult result)
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error);
            }
        }
        private AvaliacoesDbContext db = new AvaliacoesDbContext();

        // GET: Admin/Alunos
        public ActionResult Index()
        {

            return View(UserManager.Users.ToList());
        }

        // GET: Admin/Alunos/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ApplicationUser applicationUser = db.Users.Find(id);
            if (applicationUser == null)
            {
                return HttpNotFound();
            }
            return View(applicationUser);
        }

        // GET: Admin/Alunos/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Alunos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Nome,Email,Password,PasswordConfirmation")] RegisterViewModel model)
        {
            if (!ModelState.IsValid) return View(model);

            var user = new ApplicationUser { Name = model.Nome, Email = model.Email };
            var result = await UserManager.CreateAsync(user, model.Password);
            if (result.Succeeded)
            {
                UserManager.AddToRole(user.Id, RolesResource.Alunos);
                return RedirectToAction("Index");
            }
            AddErrors(result);

            return View(model);
        }

        // GET: Admin/Alunos/Edit/5
        public async Task<ActionResult> Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var applicationUser = await UserManager.FindByIdAsync(id);
            if (applicationUser == null)
            {
                return HttpNotFound();
            }
            return View(new RegisterViewModel
            {
                Id = applicationUser.Id,
                Nome = applicationUser.Name,
                Email = applicationUser.Email
            });
        }

        // POST: Admin/Alunos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Nome,Email,Password,PasswordConfirmation")] RegisterViewModel model)
        {
            if (!ModelState.IsValid) return View(model);
            var user = await UserManager.FindByIdAsync(model.Id);
            if (user == null)
            {
                return HttpNotFound();
            }
            user.Name = model.Nome;
            user.Email = model.Email;
            var result = await UserManager.UpdateAsync(user);
            if (result.Succeeded)
            {
                return RedirectToAction("Index");
            }
            AddErrors(result);
            return View(model);
        }

        // GET: Admin/Alunos/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ApplicationUser applicationUser = db.Users.Find(id);
            if (applicationUser == null)
            {
                return HttpNotFound();
            }
            return View(applicationUser);
        }

        // POST: Admin/Alunos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            ApplicationUser applicationUser = db.Users.Find(id);
            db.Users.Remove(applicationUser);
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
