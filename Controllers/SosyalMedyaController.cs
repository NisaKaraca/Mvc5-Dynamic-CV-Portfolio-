using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcCv.Models.Entity;
using MvcCv.Repositories;

namespace MvcCv.Controllers
{
    public class SosyalMedyaController : Controller
    {
        // GET: SosyalMedya
        GenericRepository<Tbl_SosyalMedya> repo = new GenericRepository<Tbl_SosyalMedya>();
        public ActionResult Index()
        {
            var sosyalMedya = repo.List();
            return View(sosyalMedya);
        }
        [HttpGet]
        public ActionResult Ekle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Ekle(Tbl_SosyalMedya p)
        {
            repo.TAdd(p);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult SayfaGetir(int id)
        {
            var sosyalMedya = repo.Find(x => x.ID == id);
            return View(sosyalMedya);
        }
        [HttpPost]
        public ActionResult SayfaGetir(Tbl_SosyalMedya p)
        {
            var sosyalMedya = repo.Find(x => x.ID == p.ID);
            sosyalMedya.Ad = p.Ad;
            sosyalMedya.Link = p.Link;
            sosyalMedya.Ikon = p.Ikon;
            sosyalMedya.Durum = true;
            repo.TUpdate(sosyalMedya);
            return RedirectToAction("Index");
        }
        public ActionResult Sil(int id)
        {
            var sosyalMedya = repo.Find(x => x.ID == id);
            sosyalMedya.Durum = false;
            repo.TUpdate(sosyalMedya);
            return RedirectToAction("Index");
        }
    }
}