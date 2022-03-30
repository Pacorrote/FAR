using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FAR.Controllers
{
    public class UsuariosRolController : Controller
    {
        // GET: UsuariosRolController
        public ActionResult Index()
        {
            return View();
        }

        // GET: UsuariosRolController/Details/5
        public ActionResult Details(int id)
        {
            return View();
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
