using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ornek.Models
{
    public class Kullanici
    {
        public int Id { get; set; }
        public string KullanıcıAdı { get; set; }
        public string Sifre { get; set; }
        public string Adı { get; set; }
        public string Soyadı { get; set; }
    }
}