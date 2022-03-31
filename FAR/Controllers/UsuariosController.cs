using FAR.Commands;
using FAR.Models;
using FAR.Queries;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FAR.Controllers
{
    public class UsuariosController : Controller
    {
        public const string SQLCONNECTIONLocal = "Data Source=MEX-FKTNMG3\\SQLEXPRESS; Initial Catalog=FAR; Trusted_Connection=true; MultipleActiveResultSets=true";
        public const string SQLCONNECTION = "Server=tcp:farstore.database.windows.net,1433;Initial Catalog=FAR;Persist Security Info=False;User ID=FAR;Password=FixWWxkf6VZkysE;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
        private readonly UsuariosCommand command = new UsuariosCommand(SQLCONNECTION);
        private readonly UsuariosQueries querie = new UsuariosQueries(SQLCONNECTION);
        // GET: UsuariosController
        public ActionResult Index()
        {
            var lista = querie.GetAll();
            return View("View", lista);
        }

        // GET: UsuariosController/Details/5
        public ActionResult Details(int id)
        {
            var usuario = querie.FindByID(id);
            return View("Details", usuario);
        }

        // GET: UsuariosController/Create
        public ActionResult Create()
        {
            return View("Create");
        }

        // POST: UsuariosController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind("Nombre, Apellidos, Telefono, Email, Calle, Id_Localidad, Fecha_Nacimiento, Contrasena, Username, Id_Rol")] Usuarios newUsuario)
        {

            try
            {
                command.SaveUsuario(newUsuario);
                return RedirectToAction(nameof(Index));
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                return View();
            }
        }

        // GET: UsuariosController/Edit/5
        public ActionResult Edit(int id)
        {
            var usuario = querie.FindByID(id);
            return View("Editar", usuario);
        }

        // POST: UsuariosController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind("Id_Usuario, Nombre, Apellidos, Telefono, Email, Calle, Id_Localidad, Fecha_Nacimiento, Contrasena, Username, Id_Rol")] Usuarios usuario)
        {
            try
            {
                command.ModifyUsuarios(usuario);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return View();
            }
        }

        // GET: UsuariosController/Delete/5
        public ActionResult ViewDelete(int id)
        {
            var usuario = querie.FindByID(id);
            return View("Delete", usuario);
        }

        // POST: UsuariosController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            try
            {
                var usuario = command.RemoveUsuarios(id);
                if(usuario != null)
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
