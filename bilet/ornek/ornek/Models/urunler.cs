using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ornek.Models
{
    public class urunler
    {
        public int id { get; set; }
        public string urun_adi { get; set; }
        public double urun_fiyati { get; set; }
        public double miktar { get; set; }
        
    }
}