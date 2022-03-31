using FAR.Commands;
using FAR.Models;
using FAR.Queries;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FAR.Controllers
{
    public class CarritoController : Controller
    {
        public const string SQLCONNECTIONLocal = "Data Source=MEX-FKTNMG3\\SQLEXPRESS; Initial Catalog=FAR; Trusted_Connection=true; MultipleActiveResultSets=true";
        public const string SQLCONNECTION = "Server=tcp:farstore.database.windows.net,1433;Initial Catalog=FAR;Persist Security Info=False;User ID=FAR;Password=FixWWxkf6VZkysE;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
        private readonly CarritoCommand command = new CarritoCommand(SQLCONNECTION);
        private readonly CarritoQueries querie = new CarritoQueries(SQLCONNECTION);
        // GET: CarritoController
        public ActionResult Index()
        {
            var lista = querie.GetAll();
            return View("View", lista);
        }

        // GET: CarritoController/Details/5
        public ActionResult Details(int id)
        {
            var carrito = querie.FindByID(id);
            return View("Details", carrito);
        }

        // GET: CarritoController/Create
        public ActionResult Create()
        {
            return View("Create");
        }

        // POST: CarritoController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind("Folio,Cancelado,Total_venta")] Carrito carrito)
        {

            try
            {
                command.SaveCarrito(carrito);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return View();
            }
        }

        // GET: CarritoController/Edit/5
        public ActionResult Edit(int id)
        {
            var carrito = querie.FindByID(id);
            return View("Editar", new Carrito
            {
                Id_Carrito = carrito.Id_Carrito,
                Folio = carrito.Folio,
                Cancelado = carrito.Cancelado,
                Total_venta = carrito.Total_venta,
            });
        }

        // POST: CarritoController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind("Id_Carrito,Folio,Cancelado,Total_venta")]Carrito carrito)
        {
            try
            {
                command.ModifyCarrito(carrito);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CarritoController/Delete/5
        public ActionResult DeleteV(int id)
        {
            var carrito = querie.FindByID(id);
            return View("Delete", new Carrito
            {
                Id_Carrito = carrito.Id_Carrito,
                Folio = carrito.Folio,
                Cancelado = carrito.Cancelado,
                Total_venta = carrito.Total_venta,
            });
        }

        // POST: CarritoController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            try
            {
                var carrito = command.RemoveCarrito(id);
                if (carrito != null)
                {
                    return RedirectToAction(nameof(Index));
                }
                return View();
            }
            catch
            {
                return View();
            }
        }
    }
}
