using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CRUD.Entities;

namespace CRUD.Controllers
{
    [Authorize]
    public class MenuController : Controller
    {
        // GET: Menu
        public ActionResult Index()
        {
            List<theMenu> m;
            using (var r = new MenuEntities())
            {
                m = r.theMenu.ToList();
            }
            return View(m);
        }

        [HttpGet]
        [ActionName("Create")]
        public ActionResult Create_Get()
        {
            return View();
        }

        [HttpPost]
        [ActionName("Create")]
        public ActionResult Create_Post()
        {
            var menumodel = new theMenu();
            TryUpdateModel(menumodel);

            using (var r = new MenuEntities())
            {
                r.theMenu.Add(menumodel);
                r.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Details(string code)
        {
            var menumodel = new theMenu();
            TryUpdateModel(menumodel);

            using (var r = new MenuEntities())
            {
                menumodel = r.theMenu.FirstOrDefault(x => x.MenuCode == code);
            }

            return View(menumodel);
        }

        [HttpGet]
        [ActionName("Edit")]
        public ActionResult Edit_Get(string code)
        {
            var menumodel = new theMenu();
            TryUpdateModel(menumodel);

            using (var r = new MenuEntities())
            {
                menumodel = r.theMenu.Where(x => x.MenuCode == code).FirstOrDefault();
            }

            return View(menumodel);
        }

        [HttpPost]
        [ActionName("Edit")]
        public ActionResult Edit_Post(string code)
        {
            var menumodel = new theMenu();
            TryUpdateModel(menumodel);

            using (var r = new MenuEntities())
            {
                var m = r.theMenu.Where(x => x.MenuCode == code).FirstOrDefault();
                TryUpdateModel(m);
                r.SaveChanges();
            }

            return RedirectToAction("Index");
        }

        [HttpGet]
        [ActionName("Delete")]
        public ActionResult Delete_Get(string code)
        {
            var menumodel = new theMenu();
            TryUpdateModel(menumodel);

            using (var r = new MenuEntities())
            {
                menumodel = r.theMenu.FirstOrDefault(x => x.MenuCode == code);
            }

            return View(menumodel);
        }
        [HttpPost]
        [ActionName("Delete")]
        public ActionResult Delete_Post(string code)
        {
            var menumodel = new theMenu();
            TryUpdateModel(menumodel);

            using (var r = new MenuEntities())
            {
                var m = r.theMenu.Remove(r.theMenu.FirstOrDefault(x => x.MenuCode == code));
                TryUpdateModel(m);
                r.SaveChanges();
            }

            return RedirectToAction("Index");
        }
    }
}