using FAR.Commands;
using FAR.Queries;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FAR.Controllers
{
    public class CategoriaController : Controller
    {
        public const string SQLCONNECTIONLocal = "Data Source=MEX-FKTNMG3\\SQLEXPRESS; Initial Catalog=FAR; Trusted_Connection=true; MultipleActiveResultSets=true";
        public const string SQLCONNECTION = "Server=tcp:farstore.database.windows.net,1433;Initial Catalog=FAR;Persist Security Info=False;User ID=FAR;Password=FixWWxkf6VZkysE;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
        private readonly CategoriaCommands command = new CategoriaCommands(SQLCONNECTION);
        private readonly CategoriasQueries querie = new CategoriasQueries(SQLCONNECTION);
        // GET: CategoriaController
        public ActionResult Index()
        {
            var lista = querie.GetAll();
            return View("View", lista);
        }

        // GET: CategoriaController/Details/5
        public ActionResult Details(int id)
        {
            var categoria = querie.FindById(id);
            return View("Details", categoria);
        }

        // GET: CategoriaController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CategoriaController/Create
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

        // GET: CategoriaController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: CategoriaController/Edit/5
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

        // GET: CategoriaController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: CategoriaController/Delete/5
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
