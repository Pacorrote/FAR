using FAR.Commands;
using FAR.Queries;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FAR.Controllers
{
    public class ProductoCarritoController : Controller
    {
        public const string SQLCONNECTIONLocal = "Data Source=MEX-FKTNMG3\\SQLEXPRESS; Initial Catalog=FAR; Trusted_Connection=true; MultipleActiveResultSets=true";
        public const string SQLCONNECTION = "Server=tcp:farstore.database.windows.net,1433;Initial Catalog=FAR;Persist Security Info=False;User ID=FAR;Password=FixWWxkf6VZkysE;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
        private readonly ProductoCarritoCommand command = new ProductoCarritoCommand(SQLCONNECTION);
        private readonly ProductoCarritoQueries querie = new ProductoCarritoQueries(SQLCONNECTION);
        // GET: ProductoCarritoController
        public ActionResult Index()
        {
           var lista = querie.GetAll();
            return View("View",lista);
        }

        // GET: ProductoCarritoController/Details/5
        public ActionResult Details(int id)
        {
            var productoCarrito = querie.FindByID(id);
            return View("Details", productoCarrito);
        }

        // GET: ProductoCarritoController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ProductoCarritoController/Create
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

        // GET: ProductoCarritoController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ProductoCarritoController/Edit/5
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

        // GET: ProductoCarritoController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ProductoCarritoController/Delete/5
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
