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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<RolYetki>()
                .HasKey(x => new { x.RolId, x.SayfaId });
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Uye> Uye { get; set; }
        public DbSet<UyeTuru> UyeTuru { get; set; }
        public DbSet<BireyselUye> BireyselUye { get; set; }
        public DbSet<KurumsalUye> KurumsalUye { get; set; }
        public DbSet<RolYetki> RolYetki { get; set; }
        public DbSet<Sayfa> Sayfa { get; set; }
        public DbSet<Ihale> Ihale { get; set; }
        public DbSet<IhaleTuru> IhaleTuru { get; set; }
        public DbSet<IhaleStatu> IhaleStatu { get; set; }
        public DbSet<Statu> Statu { get; set; }
        public DbSet<Arac> Arac { get; set; }
        public DbSet<AracStatu> AracStatu { get; set; }
        public DbSet<AracIhale> AracIhale { get; set; }
        public DbSet<AracTeklif> AracTeklif { get; set; }
        public DbSet<Marka> Marka { get; set; }
        public DbSet<Model> Model { get; set; }
        public DbSet<Ozellik> Ozellik { get; set; }
        public DbSet<OzellikDetay> OzellikDetay { get; set; }
        public DbSet<AracOzellik> AracOzellik{ get; set; }
    }
}
