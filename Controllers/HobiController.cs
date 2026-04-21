using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcCv.Models.Entity;
using MvcCv.Repositories;

namespace MvcCv.Controllers
{
    public class HobiController : Controller
    {
        // GET: Hobi
        GenericRepository<Tbl_Hobilerim> repo = new GenericRepository<Tbl_Hobilerim>();
        [HttpGet]
        public ActionResult Index()
        {
            var hobiler = repo.List();
            return View(hobiler);
        }
        [HttpPost]
        public ActionResult Index(Tbl_Hobilerim p)
        {
            var hobi = repo.Find(x => x.ID == p.ID);

            if (hobi != null)
            {
                hobi.Aciklama1 = p.Aciklama1;
                hobi.Aciklama2 = p.Aciklama2;
                repo.TUpdate(hobi);
            }

            return RedirectToAction("Index");
        }

    }
}