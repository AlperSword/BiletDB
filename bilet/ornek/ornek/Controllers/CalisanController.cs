using ornek.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
namespace uygulama.Controllers
{
    public class CalisanController : Controller
    {
        // GET: Calisan
        public ActionResult Index()
        {
            return View();
        }
        // GET 
        calisan yenikayit = new calisan();
        context db = new context();

        public string User_Name;
        public string User_sifre;
        public string User_yetki;
        public string User_ok;

        [HttpGet]
        public ActionResult calisanEkle()
        {//saadece admin
            HttpCookie reqCookies = Request.Cookies["userInfodosya"];
            if (reqCookies != null)
            {
                User_Name = reqCookies?["UserName"].ToString();
                User_sifre = reqCookies?["Usersifre"].ToString();
                User_yetki = reqCookies?["Useryetki"].ToString();
                User_ok = reqCookies?["Userok"].ToString();
            }
            else
            {
                User_Name = "";
                User_sifre = "";
                User_yetki = "";
                User_ok = "";
                return RedirectToAction("login", "Calisan");
            }
            if (User_yetki.Trim() == "user")
            {
                return RedirectToAction("Index", "Home");
            }
            ViewBag.nevar = reqCookies["UserName"].ToString() + "Admin olarak giriş yapıldı";
            var veriler = db.bilet.ToList();
            ViewBag.depart = new SelectList(veriler, "DepartmanID", "Departmanİsmi");
            return View();
        }
        [HttpPost]
        public ActionResult calisanEkle(FormCollection myform)
        {
            yenikayit.ismi = myform["cadi"].Trim();
            yenikayit.soyismi = myform["sadi"].Trim();
            yenikayit.Calisanid = Convert.ToInt32(myform["dropdanveri"].Trim());
            yenikayit.ucret = Convert.ToDouble(myform["ucret"].Trim());
            db.calisanlar.Add(yenikayit);
            db.SaveChanges();
            var veriler = db.bilet.ToList();
            ViewBag.depart = new SelectList(veriler, "DepartmanID", "Departmanİsmi");
            return View();
        }


        // login

        public ActionResult login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult login(string isim, string sifre)
        {
            var varmi = (from i in db.girisler
                         where i.isim == isim && i.sifre == sifre
                         select i).Count();
            if (varmi > 0)
            {
                ViewBag.mesaj = "Giriş Başarılı";
                string yetki1 = (from i in db.girisler
                                 where (i.isim == isim && i.sifre == sifre)
                                 select i.yetki).FirstOrDefault();
                if (Response.Cookies["userInfodosya"] != null)
                {
                    HttpCookie userInfo = new HttpCookie("userInfodosya");
                    userInfo["UserName"] = isim;
                    userInfo["Usersifre"] = sifre;
                    userInfo["Useryetki"] = yetki1;
                    userInfo["Userok"] = "ok";
                    DateTime now = DateTime.Now;
                    userInfo.Expires = now.AddMinutes(3);
                    Response.Cookies.Add(userInfo);


                }
            }
            else
            {
                ViewBag.mesaj = "Giriş Başarısız";
            }
            return View();
        }


        // logout
        public ActionResult logout()
        {
            if (Request.Cookies["userInfodosya"] != null)
            {
                HttpCookie userInfo = new HttpCookie("userInfodosya");
                userInfo.Expires = DateTime.Now.AddDays(-1d);
                Response.Cookies.Add(userInfo);
            }
            return View();
        }
    }
}