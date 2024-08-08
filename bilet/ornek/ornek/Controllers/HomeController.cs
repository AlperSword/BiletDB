using ornek.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ornek.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }
        
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        biletler yeniurun = new biletler ();
        context db = new context();
        [HttpGet]
        public ActionResult bilet_ekle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult bilet_ekle(FormCollection myform)
        {
                yeniurun.tcno = Convert.ToDouble(myform["tcno"].Trim());
                yeniurun.ad = myform["ad"].Trim();
                yeniurun.soyad = myform["soyad"].Trim();
                yeniurun.yas= Convert.ToInt32(myform["yas"].Trim());
                yeniurun.bilet_turu = myform["biletturu"].Trim();
                yeniurun.sehir = myform["sehir"].Trim();
                yeniurun.fiyat= Convert.ToDouble(myform["fiyat"].Trim());
                db.bilet.Add(yeniurun);
                db.SaveChanges();
                return View();
            

            
        }
        public ActionResult Listele()
        {
            var verilistele = db.bilet.ToList();
            return View(verilistele);
        }
        public ActionResult Guncelle(int id)
        {
            var guncellenecek = db.bilet.Find(id);
            return View(guncellenecek);
        }
        [HttpPost]
        public ActionResult Guncelle(FormCollection myform)
        {
            
            int id = Convert.ToInt32(myform["id"]);
            var guncellenecek = db.bilet.Find(id);
            guncellenecek.tcno = Convert.ToDouble(myform["tcno"].Trim());
            guncellenecek.ad = myform["ad"].Trim();
            guncellenecek.soyad = myform["soyad"].Trim();
            guncellenecek.yas = Convert.ToInt32(myform["yas"].Trim());
            guncellenecek.bilet_turu = myform["biletturu"].Trim();
            guncellenecek.sehir = myform["sehir"].Trim();
            guncellenecek.fiyat = Convert.ToDouble(myform["fiyat"].Trim());

            db.SaveChanges();
            return RedirectToAction("listele");


        }
        public ActionResult Silme(int id)
        {
            var silinecek = db.bilet.Find(id);

       
            db.bilet.Remove(silinecek);
            db.SaveChanges();
            return RedirectToAction("listele");
        }
        public ActionResult Arama()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Arama(string aranan)
        {
            var bulsql = (from i in db.bilet
                          where i.ad== aranan
                          select i).ToList();
            return View(bulsql);
        }
        public ActionResult Urunler()
        {
            var urungoster = db.bilet.ToList();
            return View(urungoster);
        }



        // ürün detay(partial view)
        public ActionResult UrunListe(int? id)
        {
            if (id != null)
            {
                var urunbilgisi = (from i in db.bilet
                                   where i.ID == id
                                   select i).ToList();
                return View(urunbilgisi);
            }
            return View();
        }
        // ürün göster içi
        public PartialViewResult UrunGoster()
        {
            var verigonder = db.bilet.ToList();
            return PartialView(verigonder);
        }
        sepet yenisepet = new sepet();
        
        public ActionResult Sepetekle(int id, string adet ="1")
        {
            var gelen = db.bilet.Find(id);
            yenisepet.adi = gelen.ad;
            yenisepet.fiyati = Convert.ToInt32(gelen.fiyat);
            yenisepet.sepetid = gelen.ID;
            //
            yenisepet.adet = Convert.ToInt32(adet);
            //
            //db.sepetler.Add(yenisepet);
            //db.SaveChanges();
            sepetviewmodel.yenisepetlerim.Add(yenisepet);
            int git = gelen.ID;
            return RedirectToAction("biletListe", new { id = git });
        }
        //sepetteki toplam tutar hesaplama
        
        public PartialViewResult sepet_ici()
        {
            var gonder = sepetviewmodel.yenisepetlerim.ToList();
            foreach (var item in gonder)
            {
                item.toplam = item.adet * item.fiyati;
            }
            double topla = (from i in gonder
                            select i.toplam).Sum();
            ViewBag.toplam = topla;
            return PartialView(gonder);
        }
        public ActionResult biletler()
        {
            var urungoster = db.bilet.ToList();
            return View(urungoster);
        }



        // ürün detay(partial view)
        public ActionResult biletListe(int? id)
        {
            if (id != null)
            {
                var urunbilgisi = (from i in db.bilet
                                   where i.ID == id
                                   select i).ToList();
                return View(urunbilgisi);
            }
            return View();
        }
        // ürün göster içi
        public PartialViewResult biletGoster()
        {
            var verigonder = db.bilet.ToList();
            return PartialView(verigonder);
        }
        public ActionResult Futbol()
        {

            return View();
        }
        public ActionResult Konser()
        {


            return View();
        }
    }
}