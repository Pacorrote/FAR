using FAR.Commands;
using FAR.DTOs;
using FAR.Models;
using FAR.Queries;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FAR.Controllers
{
    public class ProductoController : Controller
    {
        public const string SQLCONNECTIONLocal = "Data Source=MEX-FKTNMG3\\SQLEXPRESS; Initial Catalog=FAR; Trusted_Connection=true; MultipleActiveResultSets=true";
        public const string SQLCONNECTION = "Server=tcp:farstore.database.windows.net,1433;Initial Catalog=FAR;Persist Security Info=False;User ID=FAR;Password=FixWWxkf6VZkysE;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
        private readonly ProductoCommands command = new ProductoCommands(SQLCONNECTION);
        private readonly ProductoQueries querie = new ProductoQueries(SQLCONNECTION);

        
        // GET: ProductoController
        public ActionResult Index()
        {
            var lista = querie.GetAll();
            ViewData["lista"] = lista;
            ViewData["productos"] = querie.Productos();

            return View("View");
        }

        // GET: ProductoController/Details/5
        public ActionResult Details(int id)
        {
            var producto = querie.FindById(id);
            return View("Details", producto);
        }

        // GET: ProductoController/Create
        public ActionResult Create()
        {
            return View("Create");
        }

        // POST: ProductoController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind("Nombre,Descripcion,Stock,Precio,Habilitado,Id_Categoria,Id_Usuario")] Productos producto)
        {

            try
            {
                command.AgregarProducto(producto);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return View();
            }
        }

        // GET: ProductoController/Edit/5
        public ActionResult Edit(int id)
        {
            var productos = querie.FindById(id);
            return View("Edit", new Productos
            {
                Id_Producto = productos.Id_Producto,
                Nombre = productos.Nombre,
                Descripcion = productos.Descripcion,
                Stock = productos.Stock,
                Precio = productos.Precio,
                Habilitado = productos.Habilitado,
                Id_Categoria = productos.Id_Categoria,
                Id_Usuario = productos.Id_Usuario,
            });

        }

        // POST: ProductoController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind("Id_Producto,Nombre,Descripcion,Stock,Precio,Habilitado,Id_Categoria,Id_Usuario")]Productos producto)
        {
            try
            {
                command.ActualizarProducto(producto);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ProductoController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ProductoController/Delete/5
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
