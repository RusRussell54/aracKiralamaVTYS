using Npgsql;
using System;
using System.Data;
using System.Windows.Forms;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Car_Rental_Dbms_Project
{
    public partial class yonetici : Form
    {
        public yonetici()
        {
            InitializeComponent();
            LoadCalisanlar();
            LoadMusteriler();
            yonetici_Load(null, null);
        }

        private void LoadCalisanlar()
        {
            try
            {
                using (var context = new ApplicationDbContext())
                {
                    // Include ile ilişkili verileri eager-load et
                    var calisanlar = context.calisanlar
                        .Include(c => c.Adres)
                            .ThenInclude(a => a.Sehir)
                        .Include(c => c.Adres)
                            .ThenInclude(a => a.Ilce)
                        .Include(c => c.Adres)
                            .ThenInclude(a => a.Mahalle)
                        .Include(c => c.Adres)
                            .ThenInclude(a => a.Sokak)
                        .Include(c => c.Adres)
                            .ThenInclude(a => a.PostaKodu)
                        .ToList();

                    // DataTable kullanarak DataGridView'e bağla (düzenlenebilir)
                    var dataTable = new DataTable();
                    dataTable.Columns.Add("calisan_id", typeof(int));
                    dataTable.Columns.Add("Ad", typeof(string));
                    dataTable.Columns.Add("Soyad", typeof(string));
                    dataTable.Columns.Add("Email", typeof(string));
                    dataTable.Columns.Add("Telefon", typeof(string));
                    dataTable.Columns.Add("sehir", typeof(string));
                    dataTable.Columns.Add("ilce", typeof(string));
                    dataTable.Columns.Add("mahalle", typeof(string));
                    dataTable.Columns.Add("sokak", typeof(string));
                    dataTable.Columns.Add("postakodu", typeof(string));

                    foreach (var c in calisanlar)
                    {
                        dataTable.Rows.Add(
                            c.Id,
                            c.Ad,
                            c.Soyad,
                            c.Email,
                            c.Telefon,
                            c.Adres?.Sehir?.SehirAd ?? "N/A",
                            c.Adres?.Ilce?.IlceAd ?? "N/A",
                            c.Adres?.Mahalle?.MahalleAd ?? "N/A",
                            c.Adres?.Sokak?.SokakAd ?? "N/A",
                            c.Adres?.PostaKodu?.PostaKoduAd ?? "N/A"
                        );
                    }

                    dataGridView1.DataSource = dataTable;
                    dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                    
                    // Event handler'ları kaldır (eğer varsa)
                    dataGridView1.EditingControlShowing -= DataGridView1_EditingControlShowing;
                    dataGridView1.CellEndEdit -= DataGridView1_CellEndEdit;
                    dataGridView1.KeyDown -= DataGridView1_KeyDown;
                    
                    // Event handler'ları ekle
                    dataGridView1.EditingControlShowing += DataGridView1_EditingControlShowing;
                    dataGridView1.CellEndEdit += DataGridView1_CellEndEdit;
                    dataGridView1.KeyDown += DataGridView1_KeyDown;
                    
                    // DataGridView ayarları
                    dataGridView1.AllowUserToAddRows = false;
                    dataGridView1.AllowUserToDeleteRows = false;
                    dataGridView1.EditMode = DataGridViewEditMode.EditOnKeystrokeOrF2;
                    dataGridView1.ReadOnly = false;
                    
                    // Column'ları kontrol et
                    if (dataGridView1.Columns["calisan_id"] != null)
                    {
                        dataGridView1.Columns["calisan_id"].ReadOnly = true;
                    }
                    
                    // Adres sütunlarını readonly yap
                    foreach (var col in new[] { "sehir", "ilce", "mahalle", "sokak", "postakodu" })
                    {
                        if (dataGridView1.Columns[col] != null)
                            dataGridView1.Columns[col].ReadOnly = true;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Çalışanlar yüklenirken hata oluştu: {ex.Message}", "Hata", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DataGridView1_KeyDown(object sender, KeyEventArgs e)
        {
            // F2 tuşunda edit moduna gir
            if (e.KeyCode == Keys.F2 && dataGridView1.CurrentCell != null && !dataGridView1.CurrentCell.ReadOnly)
            {
                dataGridView1.BeginEdit(true);
                e.Handled = true;
            }
        }

        private void DataGridView1_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            // Hücre düzenleme modu başladığında yapılacak işlemler
            e.Control.BackColor = Color.LightYellow;
        }

        private void DataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            // Hücre editinin bittiğinde veritabanını güncelle
            if (e.RowIndex < 0 || e.ColumnIndex < 0) return;

            try
            {
                var row = dataGridView1.Rows[e.RowIndex];
                
                // ID kolonu değişirse işlem yapma
                if (dataGridView1.Columns[e.ColumnIndex].Name == "calisan_id")
                    return;

                object idObj = row.Cells["calisan_id"].Value;
                if (idObj == null) return;
                
                int calisanId = Convert.ToInt32(idObj);

                using (var context = new ApplicationDbContext())
                {
                    var calisan = context.calisanlar.FirstOrDefault(c => c.Id == calisanId);
                    if (calisan != null)
                    {
                        // Değişiklikleri al
                        string ad = row.Cells["Ad"].Value?.ToString();
                        string soyad = row.Cells["Soyad"].Value?.ToString();
                        string email = row.Cells["Email"].Value?.ToString();
                        string telefon = row.Cells["Telefon"].Value?.ToString();
                        
                        // Sadece değişen değerleri güncelle
                        bool isChanged = false;
                        if (ad != null && ad != calisan.Ad) { calisan.Ad = ad; isChanged = true; }
                        if (soyad != null && soyad != calisan.Soyad) { calisan.Soyad = soyad; isChanged = true; }
                        if (email != null && email != calisan.Email) { calisan.Email = email; isChanged = true; }
                        if (telefon != null && telefon != calisan.Telefon) { calisan.Telefon = telefon; isChanged = true; }

                        if (isChanged)
                        {
                            context.calisanlar.Update(calisan);
                            context.SaveChanges();
                            
                            // Debug log ekleyelim
                            System.Diagnostics.Debug.WriteLine($"Çalışan güncellendi: {calisanId}");
                            MessageBox.Show($"Çalışan güncellendi: {calisanId}", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Çalışan güncelleme hatası: {ex.Message}", "Hata", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                // Hata durumunda verileri yenile
                LoadCalisanlar();
            }
        }

        private void LoadMusteriler()
        {
            try
            {
                using (var context = new ApplicationDbContext())
                {
                    // Include ile ilişkili verileri eager-load et
                    var musteriler = context.musteriler
                        .Include(m => m.Adres)
                            .ThenInclude(a => a.Sehir)
                        .Include(m => m.Adres)
                            .ThenInclude(a => a.Ilce)
                        .Include(m => m.Adres)
                            .ThenInclude(a => a.Mahalle)
                        .Include(m => m.Adres)
                            .ThenInclude(a => a.Sokak)
                        .Include(m => m.Adres)
                            .ThenInclude(a => a.PostaKodu)
                        .ToList();

                    // DataTable kullanarak DataGridView'e bağla (düzenlenebilir)
                    var dataTable = new DataTable();
                    dataTable.Columns.Add("musteri_id", typeof(int));
                    dataTable.Columns.Add("Ad", typeof(string));
                    dataTable.Columns.Add("Soyad", typeof(string));
                    dataTable.Columns.Add("Email", typeof(string));
                    dataTable.Columns.Add("Telefon", typeof(string));
                    dataTable.Columns.Add("sehir", typeof(string));
                    dataTable.Columns.Add("ilce", typeof(string));
                    dataTable.Columns.Add("mahalle", typeof(string));
                    dataTable.Columns.Add("sokak", typeof(string));
                    dataTable.Columns.Add("postakodu", typeof(string));

                    foreach (var m in musteriler)
                    {
                        dataTable.Rows.Add(
                            m.Id,
                            m.Ad,
                            m.Soyad,
                            m.Email,
                            m.Telefon,
                            m.Adres?.Sehir?.SehirAd ?? "N/A",
                            m.Adres?.Ilce?.IlceAd ?? "N/A",
                            m.Adres?.Mahalle?.MahalleAd ?? "N/A",
                            m.Adres?.Sokak?.SokakAd ?? "N/A",
                            m.Adres?.PostaKodu?.PostaKoduAd ?? "N/A"
                        );
                    }

                    dataGridView2.DataSource = dataTable;
                    dataGridView2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                    
                    // Event handler'ları kaldır (eğer varsa)
                    dataGridView2.EditingControlShowing -= DataGridView2_EditingControlShowing;
                    dataGridView2.CellEndEdit -= DataGridView2_CellEndEdit;
                    dataGridView2.KeyDown -= DataGridView2_KeyDown;
                    
                    // Event handler'ları ekle
                    dataGridView2.EditingControlShowing += DataGridView2_EditingControlShowing;
                    dataGridView2.CellEndEdit += DataGridView2_CellEndEdit;
                    dataGridView2.KeyDown += DataGridView2_KeyDown;
                    
                    // DataGridView ayarları
                    dataGridView2.AllowUserToAddRows = false;
                    dataGridView2.AllowUserToDeleteRows = false;
                    dataGridView2.EditMode = DataGridViewEditMode.EditOnKeystrokeOrF2;
                    dataGridView2.ReadOnly = false;
                    
                    // Column'ları kontrol et
                    if (dataGridView2.Columns["musteri_id"] != null)
                    {
                        dataGridView2.Columns["musteri_id"].ReadOnly = true;
                    }
                    
                    // Adres sütunlarını readonly yap
                    foreach (var col in new[] { "sehir", "ilce", "mahalle", "sokak", "postakodu" })
                    {
                        if (dataGridView2.Columns[col] != null)
                            dataGridView2.Columns[col].ReadOnly = true;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Müşteriler yüklenirken hata oluştu: {ex.Message}", "Hata", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DataGridView2_KeyDown(object sender, KeyEventArgs e)
        {
            // F2 tuşunda edit moduna gir
            if (e.KeyCode == Keys.F2 && dataGridView2.CurrentCell != null && !dataGridView2.CurrentCell.ReadOnly)
            {
                dataGridView2.BeginEdit(true);
                e.Handled = true;
            }
        }

        private void DataGridView2_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            // Hücre düzenleme modu başladığında yapılacak işlemler
            e.Control.BackColor = Color.LightYellow;
        }

        private void DataGridView2_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            // Hücre editinin bittiğinde veritabanını güncelle
            if (e.RowIndex < 0 || e.ColumnIndex < 0) return;

            try
            {
                var row = dataGridView2.Rows[e.RowIndex];
                
                // ID kolonu değişirse işlem yapma
                if (dataGridView2.Columns[e.ColumnIndex].Name == "musteri_id")
                    return;

                object idObj = row.Cells["musteri_id"].Value;
                if (idObj == null) return;
                
                int musteriId = Convert.ToInt32(idObj);

                using (var context = new ApplicationDbContext())
                {
                    var musteri = context.musteriler.FirstOrDefault(m => m.Id == musteriId);
                    if (musteri != null)
                    {
                        // Değişiklikleri al
                        string ad = row.Cells["Ad"].Value?.ToString();
                        string soyad = row.Cells["Soyad"].Value?.ToString();
                        string email = row.Cells["Email"].Value?.ToString();
                        string telefon = row.Cells["Telefon"].Value?.ToString();
                        
                        // Sadece değişen değerleri güncelle
                        bool isChanged = false;
                        if (ad != null && ad != musteri.Ad) { musteri.Ad = ad; isChanged = true; }
                        if (soyad != null && soyad != musteri.Soyad) { musteri.Soyad = soyad; isChanged = true; }
                        if (email != null && email != musteri.Email) { musteri.Email = email; isChanged = true; }
                        if (telefon != null && telefon != musteri.Telefon) { musteri.Telefon = telefon; isChanged = true; }

                        if (isChanged)
                        {
                            context.musteriler.Update(musteri);
                            context.SaveChanges();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Müşteri güncelleme hatası: {ex.Message}", "Hata", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                // Hata durumunda verileri yenile
                LoadMusteriler();
            }
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            try
            {
                if (!ValidateInputs(txtAd.Text, txtSoyad.Text, txtEmail.Text, txtTelefon.Text))
                {
                    MessageBox.Show("Lütfen tüm alanları doldurun.");
                    return;
                }

                using (var context = new ApplicationDbContext())
                {
                    try
                    {
                        // Şehir kontrolü ve ekleme
                        var sehir = context.sehirler
                            .FirstOrDefault(s => s.SehirAd == txtSehir.Text);
                        if (sehir == null)
                        {
                            sehir = new Sehir { SehirAd = txtSehir.Text };
                            context.sehirler.Add(sehir);
                            context.SaveChanges();
                        }

                        // İlçe kontrolü ve ekleme
                        var ilce = context.ilceler
                            .FirstOrDefault(i => i.IlceAd == txtIlce.Text);
                        if (ilce == null)
                        {
                            ilce = new Ilce { IlceAd = txtIlce.Text };
                            context.ilceler.Add(ilce);
                            context.SaveChanges();
                        }

                        // Mahalle kontrolü ve ekleme
                        var mahalle = context.mahalleler
                            .FirstOrDefault(m => m.MahalleAd == txtMahalle.Text);
                        if (mahalle == null)
                        {
                            mahalle = new Mahalle { MahalleAd = txtMahalle.Text };
                            context.mahalleler.Add(mahalle);
                            context.SaveChanges();
                        }

                        // Sokak kontrolü ve ekleme
                        var sokak = context.sokaklar
                            .FirstOrDefault(s => s.SokakAd == txtSokak.Text);
                        if (sokak == null)
                        {
                            sokak = new Sokak { SokakAd = txtSokak.Text };
                            context.sokaklar.Add(sokak);
                            context.SaveChanges();
                        }

                        // Posta kodu kontrolü ve ekleme
                        var postaKodu = context.postaKodlari
                            .FirstOrDefault(p => p.PostaKoduAd == txtPostaKodu.Text);
                        if (postaKodu == null)
                        {
                            postaKodu = new PostaKodu { PostaKoduAd = txtPostaKodu.Text };
                            context.postaKodlari.Add(postaKodu);
                            context.SaveChanges();
                        }

                        // Adres oluştur
                        var adres = new Adres
                        {
                            SehirId = sehir.Id,
                            IlceId = ilce.Id,
                            MahalleId = mahalle.Id,
                            SokakId = sokak.Id,
                            PostaKoduId = postaKodu.Id
                        };
                        context.adresler.Add(adres);
                        context.SaveChanges();

                        // Çalışan oluştur
                        var calisan = new Calisan
                        {
                            Ad = txtAd.Text,
                            Soyad = txtSoyad.Text,
                            Email = txtEmail.Text,
                            Telefon = txtTelefon.Text,
                            AdresId = adres.Id
                        };
                        context.calisanlar.Add(calisan);
                        context.SaveChanges();

                        MessageBox.Show("Personel başarıyla eklendi.", "Başarılı", 
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        ClearInputs();
                        VerileriYenile();
                    }
                    catch (DbUpdateException dbEx)
                    {
                        string errorMessage = "Veritabanı hatası:\n\n";
                        if (dbEx.InnerException != null)
                        {
                            errorMessage += $"İç Hata: {dbEx.InnerException.Message}\n\n";
                        }
                        errorMessage += $"Ana Hata: {dbEx.Message}";
                        MessageBox.Show(errorMessage, "Kayıt Hatası", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Hata: {ex.Message}\n\nDetay: {ex.InnerException?.Message}", "Çalışan Ekleme Hatası", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // btnUpdate_Click ve btnUpdateM_Click artık gerekli değil
        // Doğrudan hücreler üzerinde düzenleme yapılıyor
        // Eski metodlar kaldırılabilir veya başka işlevler için kullanılabilir

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Çalışan bilgilerini değiştirmek için tabloda doğrudan hücreleri düzenleyin.\n" +
                           "Değişiklik yapıp hücrenin dışına çıktığında otomatik olarak kaydedilecektir.",
                           "Düzenleme Talimatı", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnUpdateM_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Müşteri bilgilerini değiştirmek için tabloda doğrudan hücreleri düzenleyin.\n" +
                           "Değişiklik yapıp hücrenin dışına çıktığında otomatik olarak kaydedilecektir.",
                           "Düzenleme Talimatı", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Lütfen silmek istediğiniz çalışanı seçin.");
                return;
            }

            try
            {
                int calisanId = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["calisan_id"].Value);

                using (var context = new ApplicationDbContext())
                {
                    var calisan = context.calisanlar.Include(c => c.Adres).FirstOrDefault(c => c.Id == calisanId);
                    if (calisan == null)
                    {
                        MessageBox.Show("Çalışan bulunamadı.");
                        return;
                    }

                    try
                    {
                        // Çalışanı sil
                        context.calisanlar.Remove(calisan);
                        context.SaveChanges();

                        MessageBox.Show("Çalışan başarıyla silindi.", "Başarılı", 
                            MessageBoxButtons.OK, MessageBoxIcon.Information);

                        // Debug log ekle
                        System.Diagnostics.Debug.WriteLine($"Çalışan silindi: {calisanId}");

                        VerileriYenile();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Silme sırasında hata oluştu: {ex.Message}", "Hata", 
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                        System.Diagnostics.Debug.WriteLine($"Silme hatası: {ex.Message}");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Hata: {ex.Message}", "Silme Hatası", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                System.Diagnostics.Debug.WriteLine($"Hata: {ex.Message}");
            }
        }

        private void VerileriYenile()
        {
            LoadCalisanlar();
        }

        private void btnDeleteM_Click(object sender, EventArgs e)
        {
            if (dataGridView2.SelectedRows.Count == 0)
            {
                MessageBox.Show("Lütfen silmek istediğiniz müşteriyi seçin.");
                return;
            }

            try
            {
                int musteriId = Convert.ToInt32(dataGridView2.SelectedRows[0].Cells["musteri_id"].Value);

                DialogResult result = MessageBox.Show(
                    "Müşteriyi silmek istediğinize emin misiniz?\nBu işlem geri alınamaz.",
                    "Müşteri Silme Onayı",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning);

                if (result == DialogResult.No)
                    return;

                using (var context = new ApplicationDbContext())
                {
                    var musteri = context.musteriler
                        .Include(m => m.Adres)
                        .FirstOrDefault(m => m.Id == musteriId);
                    
                    if (musteri == null)
                    {
                        MessageBox.Show("Müşteri bulunamadı.");
                        return;
                    }

                    try
                    {
                        // Müşteriyle ilişkili kiralamalar otomatik silinecek (CASCADE)
                        // Adres de CASCADE ile silinecek
                        context.musteriler.Remove(musteri);
                        context.SaveChanges();

                        MessageBox.Show("Müşteri başarıyla silindi.", "Başarılı", 
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadMusteriler();
                    }
                    catch (DbUpdateException dbEx)
                    {
                        string errorMessage = "Müşteri silinirken hata oluştu:\n\n";
                        if (dbEx.InnerException != null)
                        {
                            errorMessage += $"Detay: {dbEx.InnerException.Message}\n\n";
                        }
                        errorMessage += $"Ana Hata: {dbEx.Message}\n\n" +
                                      "Müşterinin ilişkili kayıtları olabilir.\n" +
                                      "Lütfen yöneticiye başvurun.";
                        MessageBox.Show(errorMessage, "Silme Hatası", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Hata: {ex.Message}\n\nDetay: {ex.InnerException?.Message}", 
                    "Müşteri Silme Hatası", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnToplamCiro_Click(object sender, EventArgs e)
        {
            try { 
            using (var context = new ApplicationDbContext())
                {
                    var toplamCiro = context.faturalar.Sum(f => f.Tutar);
                    MessageBox.Show($"Toplam Ciro: {toplamCiro} TL", "TOPLAM CİRO!", 
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Hata: {ex.Message}", "Ciro Hesaplama Hatası", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void yonetici_Load(object sender, EventArgs e)
        {
            // Notification listener'ları arka planda başlat (sonsuz döngü yerine event kullan)
            // Bu şekilde UI donmaz
            Task.Run(() => SetupNotificationListeners());
        }

        private void SetupNotificationListeners()
        {
            try
            {
                using (var connection = DatabaseHelper.GetConnection())
                {
                    connection.Open();
                    
                    connection.Notification += (o, e) =>
                    {
                        if (e.Channel == "new_calisan")
                        {
                            this.Invoke((MethodInvoker)(() =>
                            {
                                MessageBox.Show($"Yeni çalışan eklendi: {e.Payload}", "YENİ ÇALIŞAN!", 
                                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                                VerileriYenile();
                            }));
                        }
                        else if (e.Channel == "musteri_update")
                        {
                            this.Invoke((MethodInvoker)(() =>
                            {
                                MessageBox.Show($"Müşteri güncellendi: {e.Payload}", "MÜŞTERİ GÜNCELLENDİ!", 
                                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                                LoadMusteriler();
                            }));
                        }
                    };

                    using (var command = new NpgsqlCommand("LISTEN new_calisan; LISTEN musteri_update;", connection))
                    {
                        command.ExecuteNonQuery();
                    }

                    // Belirli süre dinle, sonra çık (sonsuz döngü yerine)
                    for (int i = 0; i < 60; i++)
                    {
                        if (connection.State == System.Data.ConnectionState.Open)
                        {
                            connection.Wait(TimeSpan.FromSeconds(1));
                        }
                        else
                        {
                            break;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Log error silently
                System.Diagnostics.Debug.WriteLine($"Notification listener error: {ex.Message}");
            }
        }

        private bool ValidateInputs(string ad, string soyad, string email, string telefon)
        {
            return !string.IsNullOrWhiteSpace(ad) && 
                   !string.IsNullOrWhiteSpace(soyad) && 
                   !string.IsNullOrWhiteSpace(email) && 
                   !string.IsNullOrWhiteSpace(telefon);
        }

        private void ClearInputs()
        {
            txtAd.Clear();
            txtSoyad.Clear();
            txtEmail.Clear();
            txtTelefon.Clear();
            txtSehir.Clear();
            txtIlce.Clear();
            txtMahalle.Clear();
            txtSokak.Clear();
            txtPostaKodu.Clear();
        }

        private void label1_Click(object sender, EventArgs e) { }
        private void textBox7_TextChanged(object sender, EventArgs e) { }
        private void label3_Click(object sender, EventArgs e) { }
    }
}
