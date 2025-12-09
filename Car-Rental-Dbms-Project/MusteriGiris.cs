using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Car_Rental_Dbms_Project
{
    public partial class MusteriGiris : Form
    {
        public MusteriGiris()
        {
            InitializeComponent();
            LoadCarsWithDetails();
        }

        private void LoadCarsWithDetails()
        {
            try
            {
                using (var context = new ApplicationDbContext())
                {
                    // Tüm araçları database'den çek (Include ile ilişkili verileri al)
                    var araclar = context.araclar
                        .Include(a => a.Kategori)
                        .ToList();

                    if (araclar.Count == 0)
                    {
                        MessageBox.Show("Hiç araç bulunamadı. Lütfen yönetici panelinden araç ekleyiniz.",
                            "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }

                    // UI layout parametreleri
                    int panelWidth = 270;
                    int panelHeight = 340;
                    int maxColumns = 3;
                    int xOffset = (this.ClientSize.Width - ((panelWidth + 10) * maxColumns)) / 2;
                    int yOffset = 10;
                    int columnCount = 0;

                    foreach (var arac in araclar)
                    {
                        // İlişkili verileri al
                        var binekArac = context.binek_araclar.FirstOrDefault(b => b.Id == arac.Id);
                        var ticariArac = context.ticari_araclar.FirstOrDefault(t => t.Id == arac.Id);
                        var istatistik = context.arac_istatistikleri.FirstOrDefault(ai => ai.AracId == arac.Id);
                        var tuketim = context.arac_tuketim_bilgileri.FirstOrDefault(atb => atb.AracId == arac.Id);

                        // Araç türünü belirle
                        string aracTuru = binekArac != null ? "Binek" : (ticariArac != null ? "Ticari" : "Bilinmiyor");
                        decimal? bagajHacmi = binekArac?.BagajHacmi;
                        int? yukKapasitesi = ticariArac?.YukKapasitesi;

                        // İmaj yolunu dinamik olarak oluştur
                        string imagePath = GetImagePath(arac.Id);
                        Image aracResmi = File.Exists(imagePath) ? Image.FromFile(imagePath) : null;

                        // Panel oluştur
                        Panel panel = new Panel
                        {
                            Size = new Size(panelWidth, panelHeight),
                            Location = new Point(xOffset + 550, yOffset),
                            BorderStyle = BorderStyle.FixedSingle,
                            Tag = arac.Id
                        };

                        // PictureBox oluştur
                        PictureBox pictureBox = new PictureBox
                        {
                            Image = aracResmi,
                            SizeMode = PictureBoxSizeMode.StretchImage,
                            Size = new Size(panelWidth, 150),
                            Location = new Point(0, 0)
                        };

                        // Label oluştur
                        Label infoLabel = new Label
                        {
                            Text = $"Marka: {arac.Marka}\nModel: {arac.Model}\nYıl: {arac.Yil}\nKategori: {arac.Kategori?.KategoriAd ?? "N/A"}\n" +
                                   $"Araç Türü: {aracTuru}\n" +
                                   $"Bagaj Hacmi: {(bagajHacmi?.ToString() ?? "N/A")}\nYük Kapasitesi: {(yukKapasitesi?.ToString() ?? "N/A")}\n" +
                                   $"Beygir Gücü: {istatistik?.BeygirGucu ?? 0}\nToplam Kilometre: {istatistik?.ToplamKilometre ?? 0}\n" +
                                   $"Yakıt Türü: {tuketim?.YakitTuru ?? "N/A"}\nYakıt Tüketimi: {tuketim?.YakitTuketimi ?? 0}L/100km",
                            Location = new Point(10, 160),
                            AutoSize = true,
                            Font = new Font("Arial", 8)
                        };

                        panel.Controls.Add(pictureBox);
                        panel.Controls.Add(infoLabel);
                        this.Controls.Add(panel);

                        columnCount++;
                        xOffset += panel.Width + 10;

                        if (columnCount >= maxColumns)
                        {
                            columnCount = 0;
                            xOffset = (this.ClientSize.Width - ((panelWidth + 10) * maxColumns)) / 2;
                            yOffset += panelHeight + 150;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Araçlar yüklenirken hata oluştu:\n\n{ex.Message}\n\nDetay: {ex.InnerException?.Message}",
                    "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private string GetImagePath(int aracId)
        {
            // Resources klasörü çalışan exe dosyasının yanında
            string baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
            return Path.Combine(baseDirectory, "Resources", $"{aracId}.jpg");
        }

        private void MusteriGiris_Load(object sender, EventArgs e)
        {
        }

        private void btnKiralama_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Bu Aracı Kiralayıp Ödeme yapmak istediğinize emin misiniz?",
                                  "Onay",
                                  MessageBoxButtons.OKCancel,
                                  MessageBoxIcon.Question);

            if (dr == DialogResult.OK)
            {
                try
                {
                    // İnput validasyon
                    if (string.IsNullOrWhiteSpace(txtAd.Text) ||
                        string.IsNullOrWhiteSpace(txtSoyad.Text) ||
                        string.IsNullOrWhiteSpace(txtEmail.Text) ||
                        string.IsNullOrWhiteSpace(txtTelefon.Text) ||
                        string.IsNullOrWhiteSpace(txtSokak.Text) ||
                        string.IsNullOrWhiteSpace(txtMahalle.Text) ||
                        string.IsNullOrWhiteSpace(txtSehir.Text) ||
                        string.IsNullOrWhiteSpace(txtIlce.Text) ||
                        string.IsNullOrWhiteSpace(txtPostaKodu.Text))
                    {
                        MessageBox.Show("Lütfen tüm alanları doldurun.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    // Araç seçimini kontrol et
                    int aracId = GetSelectedAracId();

                    if (aracId == 0)
                    {
                        MessageBox.Show("Lütfen bir araç seçin.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    using (var context = new ApplicationDbContext())
                    {
                        // Seçilen aracın var olup olmadığını kontrol et
                        var aracVarMi = context.araclar.Any(a => a.Id == aracId);
                        if (!aracVarMi)
                        {
                            MessageBox.Show($"Araç ID {aracId} veritabanında bulunamadı. Lütfen bir araç seçin.",
                                "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }

                        int gunlukFiyat = GetGunlukFiyat(aracId);

                        // Tarihleri kontrol et
                        DateTime kiralamaTarihi = dateTimePickerKiralamaTarihi.Value;
                        DateTime kiralamaBitisTarihi = dateTimePickerKiralamaBitisTarihi.Value;

                        kiralamaTarihi = DateTime.SpecifyKind(kiralamaTarihi, DateTimeKind.Utc);
                        kiralamaBitisTarihi = DateTime.SpecifyKind(kiralamaBitisTarihi, DateTimeKind.Utc);

                        var kiralamaSuresi = (kiralamaBitisTarihi - kiralamaTarihi).Days;

                        if (kiralamaSuresi <= 0)
                        {
                            MessageBox.Show("Kiralama bitiş tarihi, başlangıç tarihinden sonraki bir tarih olmalıdır.",
                                "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }

                        int toplamTutar = gunlukFiyat * kiralamaSuresi;

                        // Adres verilerini ekle
                        var sokak = new Sokak { SokakAd = txtSokak.Text };
                        context.sokaklar.Add(sokak);
                        context.SaveChanges();

                        var mahalle = new Mahalle { MahalleAd = txtMahalle.Text };
                        context.mahalleler.Add(mahalle);
                        context.SaveChanges();

                        var sehir = new Sehir { SehirAd = txtSehir.Text };
                        context.sehirler.Add(sehir);
                        context.SaveChanges();

                        var ilce = new Ilce { IlceAd = txtIlce.Text };
                        context.ilceler.Add(ilce);
                        context.SaveChanges();

                        var postaKodu = new PostaKodu { PostaKoduAd = txtPostaKodu.Text };
                        context.postaKodlari.Add(postaKodu);
                        context.SaveChanges();

                        var adres = new Adres
                        {
                            SokakId = sokak.Id,
                            SehirId = sehir.Id,
                            IlceId = ilce.Id,
                            PostaKoduId = postaKodu.Id,
                            MahalleId = mahalle.Id
                        };
                        context.adresler.Add(adres);
                        context.SaveChanges();

                        // Müşteri ekle
                        var musteri = new Musteri
                        {
                            Ad = txtAd.Text,
                            Soyad = txtSoyad.Text,
                            Email = txtEmail.Text,
                            Telefon = txtTelefon.Text,
                            AdresId = adres.Id
                        };
                        context.musteriler.Add(musteri);
                        context.SaveChanges();

                        // Kiralama ekle - AracId'nin var olduğundan emin olduk
                        var kiralama = new Kiralama
                        {
                            MusteriId = musteri.Id,
                            KiralamaTarihi = kiralamaTarihi,
                            KiralamaBitisTarihi = kiralamaBitisTarihi,
                            AracId = aracId  // Bu değer var olduğundan emin olduk
                        };
                        context.kiralamalar.Add(kiralama);
                        context.SaveChanges();

                        // Fatura ekle
                        var fatura = new Fatura
                        {
                            KiralamaId = kiralama.Id,
                            FaturaTarihi = DateTime.UtcNow,
                            Tutar = toplamTutar
                        };
                        context.faturalar.Add(fatura);
                        context.SaveChanges();

                        // Ödeme ekle
                        var odeme = new Odeme
                        {
                            FaturaId = fatura.Id,
                            OdemeTarihi = DateTime.UtcNow,
                            OdemeTutar = toplamTutar
                        };
                        context.odemeler.Add(odeme);
                        context.SaveChanges();

                        // Bilgileri göster
                        MessageBox.Show(
                            $"Ödeme Tarihi: {odeme.OdemeTarihi}\n\n" +
                            $"Ödeme Tutarı: {odeme.OdemeTutar} TL\n\n",
                            "Teşekkürler!", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        MessageBox.Show(
                            $"Fatura Tarihi: {fatura.FaturaTarihi}\n" +
                            $"Kiralama Tarihi: {kiralama.KiralamaTarihi}\n" +
                            $"Kiralama Bitiş Tarihi: {kiralama.KiralamaBitisTarihi}\n" +
                            $"Toplam Tutar: {fatura.Tutar} TL\n\n",
                            "Fatura Bilgileri!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch (Microsoft.EntityFrameworkCore.DbUpdateException dbEx)
                {
                    string errorMessage = "Veritabanı kayıt hatası:\n\n";
                    if (dbEx.InnerException != null)
                    {
                        errorMessage += $"Detay: {dbEx.InnerException.Message}\n\n";
                    }
                    errorMessage += $"Ana Hata: {dbEx.Message}";
                    MessageBox.Show(errorMessage, "Kayıt Hatası", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Hata: {ex.Message}\n\nDetay: {ex.InnerException?.Message}", "Kiralama Hatası", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("İşlem iptal edildi!", "İptal!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private int GetSelectedAracId()
        {
            if (radioButton1.Checked) return 1;
            if (radioButton2.Checked) return 2;
            if (radioButton3.Checked) return 3;
            if (radioButton4.Checked) return 4;
            if (radioButton5.Checked) return 5;
            if (radioButton6.Checked) return 6;
            return 0;
        }

        private int GetGunlukFiyat(int aracId)
        {
            return aracId switch
            {
                1 => 2149,
                2 => 849,
                3 => 749,
                4 => 1699,
                5 => 899,
                6 => 1299,
                _ => 0
            };
        }

        private void yoneticiBtn_Click(object sender, EventArgs e)
        {
            Login login = new Login();
            login.Show();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
