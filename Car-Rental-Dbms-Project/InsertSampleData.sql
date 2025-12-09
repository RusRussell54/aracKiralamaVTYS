-- Arac_Kategorileri verisi ekle
INSERT INTO "arac_kategorileri" ("KategoriAd") VALUES ('Kompakt') ON CONFLICT DO NOTHING;
INSERT INTO "arac_kategorileri" ("KategoriAd") VALUES ('Sedan') ON CONFLICT DO NOTHING;
INSERT INTO "arac_kategorileri" ("KategoriAd") VALUES ('SUV') ON CONFLICT DO NOTHING;
INSERT INTO "arac_kategorileri" ("KategoriAd") VALUES ('Kamyon') ON CONFLICT DO NOTHING;

-- Araclar tablosuna örnek araçlar ekle (ID 1-6)
INSERT INTO "araclar" ("Marka", "Model", "Yil", "KategoriId") VALUES 
  ('Toyota', 'Camry', 2023, 2),
  ('Honda', 'Civic', 2022, 1),
  ('Ford', 'Focus', 2021, 1),
  ('BMW', 'X5', 2023, 3),
  ('Nissan', 'Altima', 2022, 2),
  ('Chevrolet', 'Silverado', 2023, 4)
ON CONFLICT DO NOTHING;

-- Binek araçlar (bagaj hacmý)
INSERT INTO "binek_araclar" ("Id", "BagajHacmi") VALUES 
  (1, 450),
  (2, 340),
  (3, 380),
  (4, 645),
  (5, 420)
ON CONFLICT DO NOTHING;

-- Ticari araçlar (yük kapasitesi)
INSERT INTO "ticari_araclar" ("Id", "YukKapasitesi") VALUES 
  (6, 3500)
ON CONFLICT DO NOTHING;

-- Arac_Istatistikleri (beygir gücü, kilometre)
INSERT INTO "arac_istatistikleri" ("AracId", "BeygirGucu", "ToplamKilometre") VALUES 
  (1, 203, 5000),
  (2, 158, 3000),
  (3, 160, 4500),
  (4, 335, 8000),
  (5, 188, 2500),
  (6, 401, 12000)
ON CONFLICT DO NOTHING;

-- Arac_Tuketim_Bilgileri (yakýt türü, tüketimi)
INSERT INTO "arac_tuketim_bilgileri" ("AracId", "YakitTuru", "YakitTuketimi") VALUES 
  (1, 'Benzin', 6.5),
  (2, 'Benzin', 5.8),
  (3, 'Benzin', 6.2),
  (4, 'Dizel', 8.5),
  (5, 'Benzin', 6.0),
  (6, 'Dizel', 12.5)
ON CONFLICT DO NOTHING;
