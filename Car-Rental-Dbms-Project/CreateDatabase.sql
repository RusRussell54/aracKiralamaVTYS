-- PostgreSQL'de CarDb veritabanýný oluþturmak için bu SQL'i çalýþtýrýn
-- pgAdmin veya psql kullanarak aþaðýdaki komutu çalýþtýrýn:

CREATE DATABASE "CarDb" 
  WITH ENCODING 'UTF8' 
  TEMPLATE template0;

-- Hata alýrsanýz (örneðin veritabaný zaten varsa):
-- DROP DATABASE IF EXISTS "CarDb";
-- Sonra tekrar CREATE DATABASE komutunu çalýþtýrýn.
