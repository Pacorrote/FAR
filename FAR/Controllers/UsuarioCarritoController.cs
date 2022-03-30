using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FAR.Controllers
{
    public class UsuarioCarritoController : Controller
    {
        // GET: UsuarioCarritoController
        public ActionResult Index()
        {
            return View();
        }

        // GET: UsuarioCarritoController/Details/5
        public ActionResult Details(int id)
        {
            return View();
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
