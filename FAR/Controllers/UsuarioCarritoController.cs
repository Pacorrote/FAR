using FAR.Commands;
using FAR.Queries;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FAR.Controllers
{
    public class UsuarioCarritoController : Controller
    {
        public const string SQLCONNECTIONLocal = "Data Source=MEX-FKTNMG3\\SQLEXPRESS; Initial Catalog=FAR; Trusted_Connection=true; MultipleActiveResultSets=true";
        public const string SQLCONNECTION = "Server=tcp:farstore.database.windows.net,1433;Initial Catalog=FAR;Persist Security Info=False;User ID=FAR;Password=FixWWxkf6VZkysE;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
        private readonly UsuarioCarritoCommands command = new UsuarioCarritoCommands(SQLCONNECTION);
        private readonly UsuarioCarritoQueries querie = new UsuarioCarritoQueries(SQLCONNECTION);
        // GET: UsuarioCarritoController
        public ActionResult Index()
        {
            var lista = querie.GetAll();
            return View("View", lista);
        }

        // GET: UsuarioCarritoController/Details/5
        public ActionResult Details(int id)
        {
            var usuarioCarrito = querie.FindById(id);
            return View("Details", usuarioCarrito);
        }

        // GET: UsuarioCarritoController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: UsuarioCarritoController/Create
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

        // GET: UsuarioCarritoController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: UsuarioCarritoController/Edit/5
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

        // GET: UsuarioCarritoController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: UsuarioCarritoController/Delete/5
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
