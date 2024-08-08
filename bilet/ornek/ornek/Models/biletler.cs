using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ornek.Models
{
    public class biletler
    {
        public int ID { get; set; }
        public double tcno { get; set; }
       
        public string ad { get; set; }
        public string soyad { get; set; }
        public int yas { get; set; }
        public string bilet_turu { get; set; }
        public string sehir { get; set; }
        public double fiyat { get; set; }
    }
}