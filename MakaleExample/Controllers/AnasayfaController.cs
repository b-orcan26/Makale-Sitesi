using MakaleExample.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using PagedList.Mvc;

namespace MakaleExample.Controllers
{
    public class AnasayfaController : Controller
    {
        Model1 veritabani = new Model1();
        // GET: Anasayfa
      
        
        public ActionResult Icerik(int sayfa=1)
        {
                                                        //kacınci sayfa , sayfada kac eleman olsun
            var makaleler = veritabani.Makale.OrderByDescending(x=>x.tarih).ToList().ToPagedList(sayfa, 5);
            
            return View(makaleler);
        }

        
        [HttpGet]
        public ActionResult Ara(string Aranan,int sayfa=1)
        {
            ViewBag.aranan = Aranan;
            var makaleler = veritabani.Makale.Where(a => a.makale_baslik.Contains(Aranan)).Select(a => a).ToList().ToPagedList(sayfa, 5);
            return View(makaleler);
        }


/*
        [HttpPost]
        public ActionResult Ara(string Aranan, int sayfa = 1)
        {
            var makaleler = veritabani.Makale.Where(a => a.makale_baslik.Contains(Aranan)).Select(a => a).ToList().ToPagedList(sayfa, 5);
            Aranan_kelime = Aranan;
            return View(makaleler);
        }
*/

        // [ValidateInput(false)]
        /// PAGESS


        public ActionResult Mvc(int sayfa=1)
        {
            int kategori_id = veritabani.Kategoriler.Where(k => k.kategori_ad.ToLower() == "asp.net mvc").Select(k => k.kategori_id).FirstOrDefault();
            var asp_makaleler = veritabani.Makale.Where(m => m.kategori_id == kategori_id).Select(m => m).ToList().ToPagedList(sayfa, 5);
            return View(asp_makaleler);
        }

        public ActionResult Css(int sayfa=1)
        {
            int kategori_id = veritabani.Kategoriler.Where(k => k.kategori_ad.ToLower() == "css").Select(k => k.kategori_id).FirstOrDefault();
            var css_makaleler = veritabani.Makale.Where(m => m.kategori_id == kategori_id).Select(m => m).ToList().ToPagedList(sayfa, 5);
            return View(css_makaleler);
        }

        public ActionResult Bootstrap(int sayfa=1)
        {
            int kategori_id = veritabani.Kategoriler.Where(k => k.kategori_ad.ToLower() == "bootstrap").Select(k => k.kategori_id).FirstOrDefault();
            var bootstrap_makaleler = veritabani.Makale.Where(m => m.kategori_id == kategori_id).Select(m => m).ToList().ToPagedList(sayfa, 5);
            return View(bootstrap_makaleler);
        }

        public ActionResult Wpf(int sayfa=1)
        {
            int kategori_id = veritabani.Kategoriler.Where(k => k.kategori_ad.ToLower() == "wpf").Select(k => k.kategori_id).FirstOrDefault();
            var wpf_makaleler = veritabani.Makale.Where(m => m.kategori_id == kategori_id).Select(m => m).ToList().ToPagedList(sayfa, 5);
            return View(wpf_makaleler);
        }

        public ActionResult Android(int sayfa=1)
        {
            int kategori_id = veritabani.Kategoriler.Where(k => k.kategori_ad.ToLower() == "android").Select(k => k.kategori_id).FirstOrDefault();
            var android_makaleler = veritabani.Makale.Where(m => m.kategori_id == kategori_id).Select(m => m).ToList().ToPagedList(sayfa, 5);
            return View(android_makaleler);
        }


    }
}