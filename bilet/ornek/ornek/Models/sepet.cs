using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ornek.Models
{
    public class sepet
    {
        [Key]
        public int sepetid { get; set; }
        public int id { get; set; }
        public string adi { get; set; }
        public string bilet_turu { get; set; }
        public int fiyati { get; set; }
        public int adet { get; set; }
        public int toplam { get; set; }
    }
}
