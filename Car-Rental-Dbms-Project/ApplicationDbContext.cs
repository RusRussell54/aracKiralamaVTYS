using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Car_Rental_Dbms_Project
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Sokak> sokaklar { get; set; }
        public DbSet<Sehir> sehirler { get; set; }
        public DbSet<Ilce> ilceler { get; set; }
        public DbSet<PostaKodu> postaKodlari { get; set; }
        public DbSet<Mahalle> mahalleler { get; set; }  // Mahalle tablosu eklendi

        public DbSet<Musteri> musteriler { get; set; }
        public DbSet<Calisan> calisanlar { get; set; }
        public DbSet<Arac> araclar { get; set; }
        public DbSet<BinekArac> binek_araclar { get; set; }
        public DbSet<TicariArac> ticari_araclar { get; set; }
        public DbSet<Kiralama> kiralamalar { get; set; }
        public DbSet<Fatura> faturalar { get; set; }
        public DbSet<Odeme> odemeler { get; set; }
        public DbSet<Adres> adresler { get; set; }
        public DbSet<Arac_Kategorileri> arac_kategorileri { get; set; }
        public DbSet<Arac_Tuketim_Bilgileri> arac_tuketim_bilgileri { get; set; }
        public DbSet<Arac_Istatistikleri> arac_istatistikleri { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(DatabaseHelper.ConnectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Arac sınıfı için temel tablo adı
            modelBuilder.Entity<Arac>().ToTable("araclar");

            // BinekArac ve TicariArac sınıfları için ayrı tablolar - TPT stratejisi
            modelBuilder.Entity<BinekArac>().ToTable("binek_araclar");
            modelBuilder.Entity<TicariArac>().ToTable("ticari_araclar");

            // Adres İlişkileri
            modelBuilder.Entity<Adres>()
                .HasOne(a => a.Sokak)
                .WithMany(s => s.Adresler)
                .HasForeignKey(a => a.SokakId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Adres>()
                .HasOne(a => a.Sehir)
                .WithMany(s => s.Adresler)
                .HasForeignKey(a => a.SehirId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Adres>()
                .HasOne(a => a.Ilce)
                .WithMany(i => i.Adresler)
                .HasForeignKey(a => a.IlceId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Adres>()
                .HasOne(a => a.PostaKodu)
                .WithMany(p => p.Adresler)
                .HasForeignKey(a => a.PostaKoduId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Adres>()
                .HasOne(a => a.Mahalle)
                .WithMany(m => m.Adresler)
                .HasForeignKey(a => a.MahalleId)
                .OnDelete(DeleteBehavior.Restrict);

            // Musteri - Adres İlişkisi
            modelBuilder.Entity<Musteri>()
                .HasOne(m => m.Adres)
                .WithMany()
                .HasForeignKey(m => m.AdresId)
                .OnDelete(DeleteBehavior.Cascade);

            // Calisan - Adres İlişkisi
            modelBuilder.Entity<Calisan>()
                .HasOne(c => c.Adres)
                .WithMany()
                .HasForeignKey(c => c.AdresId)
                .OnDelete(DeleteBehavior.Cascade);

            // Kiralama - Musteri İlişkisi (CASCADE - müşteri silindiğinde kiralamalar da silinsin)
            modelBuilder.Entity<Kiralama>()
                .HasOne(k => k.Musteri)
                .WithMany()
                .HasForeignKey(k => k.MusteriId)
                .OnDelete(DeleteBehavior.Cascade);

            // Kiralama - Arac İlişkisi (SetNull - araç silinirse kiralamanın AracId null olur)
            modelBuilder.Entity<Kiralama>()
                .HasOne(k => k.Arac)
                .WithMany()
                .HasForeignKey(k => k.AracId)
                .OnDelete(DeleteBehavior.SetNull);

            // Fatura - Kiralama İlişkisi
            modelBuilder.Entity<Fatura>()
                .HasOne(f => f.Kiralama)
                .WithMany()
                .HasForeignKey(f => f.KiralamaId)
                .OnDelete(DeleteBehavior.Cascade);

            // Odeme - Fatura İlişkisi
            modelBuilder.Entity<Odeme>()
                .HasOne(o => o.Fatura)
                .WithMany()
                .HasForeignKey(o => o.FaturaId)
                .OnDelete(DeleteBehavior.Cascade);

            // Arac - AracKategori İlişkisi (nullable olabilir)
            modelBuilder.Entity<Arac>()
                .HasOne(a => a.Kategori)
                .WithMany()
                .HasForeignKey(a => a.KategoriId)
                .OnDelete(DeleteBehavior.SetNull);

            // Arac_Tuketim_Bilgileri - Arac İlişkisi
            modelBuilder.Entity<Arac_Tuketim_Bilgileri>()
                .HasOne(atb => atb.Arac)
                .WithMany()
                .HasForeignKey(atb => atb.AracId)
                .OnDelete(DeleteBehavior.Cascade);

            // Arac_Istatistikleri - Arac İlişkisi
            modelBuilder.Entity<Arac_Istatistikleri>()
                .HasOne(ai => ai.Arac)
                .WithMany()
                .HasForeignKey(ai => ai.AracId)
                .OnDelete(DeleteBehavior.Cascade);

            // ========== SEED DATA ==========
            // Kategorileri ekle
            modelBuilder.Entity<Arac_Kategorileri>().HasData(
                new Arac_Kategorileri { Id = 1, KategoriAd = "Kompakt" },
                new Arac_Kategorileri { Id = 2, KategoriAd = "Sedan" },
                new Arac_Kategorileri { Id = 3, KategoriAd = "SUV" },
                new Arac_Kategorileri { Id = 4, KategoriAd = "Kamyon" },
                new Arac_Kategorileri { Id = 5, KategoriAd = "Minibüs" }
            );

            // Binek araçlar (Arac alanları + BagajHacmi)
            modelBuilder.Entity<BinekArac>().HasData(
                new BinekArac { Id = 3, Marka = "Renault", Model = "Clio", Yil = 2021, KategoriId = 1, BagajHacmi = 260 },
                new BinekArac { Id = 4, Marka = "Renault", Model = "Megane", Yil = 2023, KategoriId = 2, BagajHacmi = 420 },
                new BinekArac { Id = 5, Marka = "Fiat", Model = "Egea", Yil = 2022, KategoriId = 2, BagajHacmi = 380 },
                new BinekArac { Id = 6, Marka = "Toyota", Model = "Corolla", Yil = 2023, KategoriId = 2, BagajHacmi = 330 }
            );

            // Ticari araçlar (Arac alanları + YukKapasitesi)
            modelBuilder.Entity<TicariArac>().HasData(
                new TicariArac { Id = 1, Marka = "Ford", Model = "Transit", Yil = 2023, KategoriId = 4, YukKapasitesi = 3500 },
                new TicariArac { Id = 2, Marka = "Fiat", Model = "Combi", Yil = 2022, KategoriId = 5, YukKapasitesi = 2800 }
            );

            // İstatistikler
            modelBuilder.Entity<Arac_Istatistikleri>().HasData(
                new Arac_Istatistikleri { Id = 1, AracId = 1, BeygirGucu = 170, ToplamKilometre = 15000 },
                new Arac_Istatistikleri { Id = 2, AracId = 2, BeygirGucu = 145, ToplamKilometre = 12000 },
                new Arac_Istatistikleri { Id = 3, AracId = 3, BeygirGucu = 110, ToplamKilometre = 8000 },
                new Arac_Istatistikleri { Id = 4, AracId = 4, BeygirGucu = 130, ToplamKilometre = 10000 },
                new Arac_Istatistikleri { Id = 5, AracId = 5, BeygirGucu = 140, ToplamKilometre = 9000 },
                new Arac_Istatistikleri { Id = 6, AracId = 6, BeygirGucu = 140, ToplamKilometre = 7000 }
            );

            // Tüketim bilgileri
            modelBuilder.Entity<Arac_Tuketim_Bilgileri>().HasData(
                new Arac_Tuketim_Bilgileri { Id = 1, AracId = 1, YakitTuru = "Dizel", YakitTuketimi = 9.5m },
                new Arac_Tuketim_Bilgileri { Id = 2, AracId = 2, YakitTuru = "Benzin", YakitTuketimi = 7.8m },
                new Arac_Tuketim_Bilgileri { Id = 3, AracId = 3, YakitTuru = "Benzin", YakitTuketimi = 5.5m },
                new Arac_Tuketim_Bilgileri { Id = 4, AracId = 4, YakitTuru = "Benzin", YakitTuketimi = 6.2m },
                new Arac_Tuketim_Bilgileri { Id = 5, AracId = 5, YakitTuru = "Benzin", YakitTuketimi = 6.0m },
                new Arac_Tuketim_Bilgileri { Id = 6, AracId = 6, YakitTuru = "Benzin", YakitTuketimi = 5.8m }
            );
        }
    }
}
