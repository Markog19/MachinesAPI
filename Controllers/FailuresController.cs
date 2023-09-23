using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace StrojeviAPI.Controllers
{
    public class FailuresController : Controller
    {
        // GET: FailuresController
        public ActionResult Index()
        {
            return View();
        }

        // GET: FailuresController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: FailuresController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: FailuresController/Create
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

        // GET: FailuresController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: FailuresController/Edit/5
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

        // GET: FailuresController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: FailuresController/Delete/5
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
