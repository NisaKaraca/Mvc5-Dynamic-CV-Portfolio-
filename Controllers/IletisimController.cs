using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcCv.Models.Entity;
using MvcCv.Repositories;

namespace MvcCv.Controllers
{
    public class IletisimController : Controller
    {
        // GET: Iletisim
        GenericRepository<Tbl_Iletisim> repo = new GenericRepository<Tbl_Iletisim>();
        public ActionResult Index()
        {
            var iletisim = repo.List();
            return View(iletisim);
        }
        public ActionResult MesajSil(int id)
        {
            var mesaj = repo.Find(x => x.ID == id);
            repo.TDelete(mesaj);
            return RedirectToAction("Index");
        }
    }
}