using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcCv.Models.Entity;  
using MvcCv.Repositories;

namespace MvcCv.Controllers
{
    public class HakkimdaController : Controller
    {
        // GET: Hakkimda
        GenericRepository<Tbl_Hakkimda> repo = new GenericRepository<Tbl_Hakkimda>();
        public ActionResult Index()
        {
            var hakkimda = repo.List();
            return View(hakkimda);
        }
        [HttpPost]
        public ActionResult Index(Tbl_Hakkimda p)
        {
            var hakkimda = repo.Find(x => x.ID == p.ID);

            if (hakkimda != null)
            {
                hakkimda.Ad = p.Ad;
                hakkimda.Soyad = p.Soyad;
                hakkimda.Adres = p.Adres;
                hakkimda.Telefon = p.Telefon;
                hakkimda.Mail = p.Mail;
                hakkimda.Aciklama = p.Aciklama;
                hakkimda.Resim = p.Resim;
                repo.TUpdate(hakkimda);
            }

            return RedirectToAction("Index");
        }
    }
}