using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using System.Configuration;
using IkinciElAracIhaleSistemi.Entities.Entities;

namespace IkinciElAracIhaleSistemiSonKullanici.DAL.Context
{
    public class AracIhaleContext : DbContext
    {
        public AracIhaleContext()
        {
            
        }
        public AracIhaleContext(DbContextOptions<AracIhaleContext> opt) : base(opt)
        {

        }

        public DbSet<Uye> Uyeler { get; set; }
        public DbSet<UyeTuru> UyeTurleri { get; set; }
        public DbSet<BireyselUye> BireyselUyeler { get; set; }
        public DbSet<KurumsalUye> KurumsalUyeler { get; set; }
        public DbSet<RolYetki> RolYetkileri { get; set; }
    }
}
