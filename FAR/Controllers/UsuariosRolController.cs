using FAR.Commands;
using FAR.Queries;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FAR.Controllers
{
    public class UsuariosRolController : Controller
    {
        public const string SQLCONNECTIONLocal = "Data Source=MEX-FKTNMG3\\SQLEXPRESS; Initial Catalog=FAR; Trusted_Connection=true; MultipleActiveResultSets=true";
        public const string SQLCONNECTION = "Server=tcp:farstore.database.windows.net,1433;Initial Catalog=FAR;Persist Security Info=False;User ID=FAR;Password=FixWWxkf6VZkysE;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
        private readonly UsuariosRolCommand command = new UsuariosRolCommand(SQLCONNECTION);
        private readonly UsuariosRolQueries querie = new UsuariosRolQueries(SQLCONNECTION);
        // GET: UsuariosRolController
        public ActionResult Index()
        {
            var lista = querie.GetAll();
            return View("View", lista);
        }

        // GET: UsuariosRolController/Details/5
        public ActionResult Details(uint id)
        {
            var usuarioRol = querie.FindByID(id);
            return View("Details", usuarioRol);
        }

        // GET: UsuariosRolController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: UsuariosRolController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: UsuariosRolController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: UsuariosRolController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: UsuariosRolController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: UsuariosRolController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
