using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Car_Rental_Dbms_Project
{
    public class BaseEntity
    {
        public int Id { get; set; }
    }
    public class Musteri : BaseEntity
    {
        public string Ad { get; set; }
        public string Soyad { get; set; }
        public string Email { get; set; }
        public string Telefon { get; set; }
        public int AdresId { get; set; }
        public Adres Adres { get; set; }
    }
    public class Calisan : BaseEntity
    {
        public string Ad { get; set; }
        public string Soyad { get; set; }
        public string Email { get; set; }
        public string Telefon { get; set; }
        public int AdresId { get; set; }
        public Adres Adres { get; set; }
    }
    public class Arac : BaseEntity
    {
        public string Marka { get; set; }
        public string Model { get; set; }
        public int Yil { get; set; }
        public int? KategoriId { get; set; }
        public Arac_Kategorileri Kategori { get; set; }

    }

    public class TicariArac : Arac
    {
        public int YukKapasitesi { get; set; }
    }

    public class BinekArac : Arac
    {
        public decimal BagajHacmi { get; set; }
    }
    public class Kiralama : BaseEntity
    {
        public int MusteriId { get; set; }
        public int AracId { get; set; }
        public DateTime KiralamaTarihi { get; set; }
        public DateTime KiralamaBitisTarihi { get; set; }
        public Musteri Musteri { get; set; }
        public Arac Arac { get; set; }
    }
    public class Fatura : BaseEntity
    {
        public int KiralamaId { get; set; }
        public decimal Tutar { get; set; }
        public DateTime FaturaTarihi { get; set; }
        public Kiralama Kiralama { get; set; }
    }
    public class Odeme : BaseEntity
    {
        public int FaturaId { get; set; }
        public DateTime OdemeTarihi { get; set; }
        public decimal OdemeTutar { get; set; }
        public Fatura Fatura { get; set; }
    }
    public class Sokak : BaseEntity
    {
        public string SokakAd { get; set; }
        public ICollection<Adres> Adresler { get; set; }
    }

    public class Sehir : BaseEntity
    {
        public string SehirAd { get; set; }
        public ICollection<Adres> Adresler { get; set; }
    }

    public class Ilce : BaseEntity
    {
        public string IlceAd { get; set; }
        public ICollection<Adres> Adresler { get; set; }
    }

    public class PostaKodu : BaseEntity
    {
        public string PostaKoduAd { get; set; }
        public ICollection<Adres> Adresler { get; set; }
    }
    public class Mahalle : BaseEntity
    {
        public string MahalleAd { get; set; }
        public ICollection<Adres> Adresler { get; set; }
    }
    public class Adres : BaseEntity
    {
        public int SokakId { get; set; }
        public int SehirId { get; set; }
        public int IlceId { get; set; }
        public int PostaKoduId { get; set; }
        public int MahalleId { get; set; }  
        public Sokak Sokak { get; set; }
        public Sehir Sehir { get; set; }
        public Ilce Ilce { get; set; }
        public PostaKodu PostaKodu { get; set; }
        public Mahalle Mahalle { get; set; }  
    }
    public class Arac_Kategorileri : BaseEntity
    {
        public string KategoriAd { get; set; }
    }
    public class Arac_Tuketim_Bilgileri : BaseEntity
    {
        public int AracId { get; set; }
        public string YakitTuru { get; set; }
        public decimal YakitTuketimi { get; set; }
        public Arac Arac { get; set; }
    }
    public class Arac_Istatistikleri : BaseEntity
    {
        public int AracId { get; set; }
        public int BeygirGucu { get; set; }
        public int ToplamKilometre { get; set; }
        public Arac Arac { get; set; }
    }

    public class LogIslemleri : BaseEntity
    {
        public string IslemTipi { get; set; }
        public string TabloAdi { get; set; }
        public int KayitId { get; set; }
        public DateTime IslemTarihi { get; set; } = DateTime.Now;
        public string Kullanici { get; set; }
    }
}
