using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using MvcCv.Models.Entity;

namespace MvcCv.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {
        // GET: Login
        DbCvEntities db = new DbCvEntities();
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(Tbl_Admin p)
        {
            var bilgiler = db.Tbl_Admin.FirstOrDefault(x => x.KullaniciAdi == p.KullaniciAdi && x.Sifre == p.Sifre);
            if (bilgiler != null)
            {
                FormsAuthentication.SetAuthCookie(bilgiler.KullaniciAdi, false);
                Session["KullaniciAdi"] = bilgiler.KullaniciAdi.ToString();
                return RedirectToAction("Index", "Deneyim");
            }
            else
            {
                ViewBag.Hata = "Hatalı Kullanıcı Adı veya Şifre";
                return RedirectToAction("Index", "Login");
            }
        }
        public ActionResult CikisYap()
        {
            FormsAuthentication.SignOut();
            Session.Clear();
            Session.Abandon();
            return RedirectToAction("Index", "Login");
        }
    }
}