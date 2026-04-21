using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcCv.Models.Entity;
using MvcCv.Repositories;

namespace MvcCv.Controllers
{
    public class SertifikaController : Controller
    {
        // GET: Sertifika
        GenericRepository<Tbl_Sertifikalarim> repo = new GenericRepository<Tbl_Sertifikalarim>();
        public ActionResult Index()
        {
            var sertifika = repo.List();
            return View(sertifika);
        }
        [HttpGet]
        public ActionResult SertifikaGetir(int id)
        {
            var sertifika = repo.Find(x => x.ID == id);
            return View(sertifika);
        }
        [HttpPost]
        public ActionResult SertifikaGetir(Tbl_Sertifikalarim p)
        {
            var sertifika = repo.Find(x => x.ID == p.ID);
            sertifika.Baslik = p.Baslik;
            sertifika.AltBaslik = p.AltBaslik;
            sertifika.Aciklama1 = p.Aciklama1;
            sertifika.Aciklama2 = p.Aciklama2;
            sertifika.Tarih = p.Tarih;
            repo.TUpdate(sertifika);
            return RedirectToAction("Index");
        }
        public ActionResult SertifikaSil(int id)
        {
            var sertifika = repo.Find(x => x.ID == id);
            repo.TDelete(sertifika);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult YeniSertifika()
        {
            return View();
        }
        [HttpPost]
        public ActionResult YeniSertifika(Tbl_Sertifikalarim p)
        {
            repo.TAdd(p);
            return RedirectToAction("Index");
        }
    }
}