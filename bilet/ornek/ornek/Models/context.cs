using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ornek.Models
{
    public class context : DbContext
    {
        public context() : base("sqlim")
        {

        }
        public DbSet<biletler> bilet { get; set; }
        public DbSet<calisan> calisanlar { get; set; }
        public DbSet<sepet> sepetler { get; set; }
        public DbSet<giris> girisler { get; set; }


    }
}
