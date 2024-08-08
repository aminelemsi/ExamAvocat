using Examen.ApplicationCore.Domain;
using Examen.ApplicationCore.Interfaces;
using Examen.ApplicationCore.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Examen.WEB.Controllers
{
    public class ActiviteController : Controller
    {
        IActiviteService activiteService;
        IPackService packService;
        public ActiviteController(IActiviteService activiteService, IPackService packService)
        {
            this.activiteService = activiteService;
            this.packService = packService;
        }

        // GET: ActiviteController
        public ActionResult Index()
        {
            return View();
        }

        // GET: ActiviteController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ActiviteController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ActiviteController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Activite activite)
        {
            try
            {
                activiteService.Add(activite);  
                activiteService.Commit();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ActiviteController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ActiviteController/Edit/5
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

        // GET: ActiviteController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ActiviteController/Delete/5
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
