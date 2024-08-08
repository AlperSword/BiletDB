using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ornek.Models
{
 
        public class calisan
        {
            [Key]
            public int Calisanid { get; set; }
            public string ismi { get; set; }
            public string soyismi { get; set; }
            public double ucret { get; set; }
        }
}