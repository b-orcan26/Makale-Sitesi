using MakaleExample.Entity;
using MakaleExample.Models;
using MakaleExample.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.Mvc;
using System.IO;
using System.Web.Security;
using MakaleExample.Authorize;
using PagedList;
using PagedList.Mvc;


namespace MakaleExample.Controllers
{
    public class YonetimController : Controller
    {
        Model1 veritabani = new Model1();

        [AllowAnonymous]
        public ActionResult Login()
        {
            return View();
        }

        [AllowAnonymous]
        [HttpPost]
        public ActionResult Login(Kullanicilar kullanici)
        {

            Kullanicilar _kullanici = (from k in veritabani.Kullanicilar where k.kullanici_ad == kullanici.kullanici_ad && k.kullanici_sifre == kullanici.kullanici_sifre select k).FirstOrDefault();
            if (_kullanici != null)
            {
                FormsAuthentication.SetAuthCookie(kullanici.kullanici_ad, false);
                return RedirectToAction("Panel");
            }
            else
            {
                ModelState.AddModelError("", "Kullanici adi veya şifre hatalı!");
            }
            return View(kullanici);
        }

        [Authorize]
        public ActionResult Panel()
        {
            var makaleler = veritabani.Makale.ToList();

            return View(makaleler);
        }

        [Authorize]
        [HttpGet]
        public ActionResult Guncelle(int makale_id)
        {
            Makale m = veritabani.Makale.Where(mk => mk.makale_id == makale_id).FirstOrDefault();
            return View(m);
        }

        [Authorize]
        [HttpPost]
        public ActionResult Guncelle(Makale m)
        {
            Makale makale = veritabani.Makale.Where(mk => mk.makale_id == m.makale_id).Select(mk => mk).FirstOrDefault();
            makale.makale_baslik = m.makale_baslik;
            makale.makale_icerik = m.makale_icerik;
            makale.tarih = m.tarih;

            veritabani.SaveChanges();
            return RedirectToAction("Panel");
        }

        [Authorize]
        public ActionResult Sil(int id)
        {
            Makale m = veritabani.Makale.Where(mk => mk.makale_id == id).Select(mk => mk).FirstOrDefault();
            veritabani.Makale.Remove(m);
            veritabani.SaveChanges();
            return RedirectToAction("Panel");
        }



        [Authorize]
        public ActionResult Ekle()
        {
            CreateViewModel model = new CreateViewModel();
            model.Kategoris = veritabani.Kategoriler.Select(x => new SelectListItem
            {
                Value = x.kategori_id.ToString(),
                Text = x.kategori_ad
            });
            model.tarih = DateTime.Now;
            return View(model);
        }

        [Authorize]
        [HttpPost]
        public ActionResult Ekle(CreateViewModel model)
        {
            Makale m = new Makale();
            m.kategori_id = model.kategori_id;
            m.makale_baslik = model.makale_baslik;
            m.makale_icerik = model.makale_icerik;
            m.tarih = model.tarih;
            veritabani.Makale.Add(m);
            veritabani.SaveChanges();
            return RedirectToAction("Panel");
        }



    }
}