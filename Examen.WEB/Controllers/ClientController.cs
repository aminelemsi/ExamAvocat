using Examen.ApplicationCore.Domain;
using Examen.ApplicationCore.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using NuGet.Protocol.Plugins;

namespace Examen.WEB.Controllers
{
    public class ClientController : Controller
    {
        IClientService cs;
        IConseillerService conseillerService;

        public ClientController(IClientService cs, IConseillerService conseillerService)
        {
            this.cs = cs;
            this.conseillerService = conseillerService;
        }


        // GET: ClientController
        public ActionResult Index(string? Login)
        {
            if (Login == null)
                return View(cs.GetAll());
            return View(cs.GetMany(p => p.Login.Equals(Login)));
        }

        // GET: ClientController/Details/5
        public ActionResult Details(int id)
        {
            return View(conseillerService.GetById(id));
        }

        // GET: ClientController/Create
        public ActionResult Create()
        {
            ViewBag.conseillerList = new SelectList(conseillerService.GetAll(), "ConseillerId", "ConseillerId");
            return View();
        }

        // POST: ClientController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Client client, IFormFile file)
        {
            try
            {
                {
                    var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "uploads",
                   file.FileName);
                    using (System.IO.Stream stream = new FileStream(path, FileMode.Create))
                    {
                        file.CopyTo(stream);
                    }
                    client.Photo = file.FileName;
                }

                cs.Add(client);
                cs.Commit();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ClientController/Edit/5
        public ActionResult Edit(int id)

        {
            var client = cs.GetById(id);
            if (client == null)
            {
                return NotFound();
            }
            ViewBag.conseillerList = new SelectList(conseillerService.GetAll(), "ConseillerId", "ConseillerId");

            return View();
        }

        // POST: ClientController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Client client, IFormFile file)
        {
            try
            {
                var thisClient = cs.GetById(id);

                thisClient.Login = client.Login;
                thisClient.Password = client.Password;  
                thisClient.ConseillerFk = client.ConseillerFk;
                var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "uploads",
                  file.FileName);
                using (System.IO.Stream stream = new FileStream(path, FileMode.Create))
                {
                    file.CopyTo(stream);
                }
                thisClient.Photo = file.FileName;
                cs.Update(thisClient);  
                cs.Commit();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ClientController/Delete/5
        public ActionResult Delete(int id)
        {
            var thisUser = cs.GetById(id);  
            if (thisUser == null)
            {
                NotFound();

            }
            return View();
        }

        // POST: ClientController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection )
        {
            try
            {
                var client = cs.GetById(id);
               if (client == null)
                {
                    NotFound();
                }
               cs.Delete(client!);
                cs.Commit();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
