CREATE DATABASE MatrakNatural_DB
GO
USE MatrakNatural_DB
GO
CREATE TABLE Kategoriler
(
	ID int IDENTITY(1,1) PRIMARY KEY,
	Isim nvarchar(75) NOT NULL,
	YayinDurum bit,
	Silinmis bit
)
GO
CREATE TABLE Yoneticiler
(
	ID int IDENTITY(1,1) PRIMARY KEY,
	Isim nvarchar(75) NOT NULL,
	Soyisim nvarchar(75),
	KullaniciAdi nvarchar(75),
	Mail nvarchar(75),
	Sifre nvarchar(75),
	SonGirisTarihi nvarchar(75),
	Durum bit,
	Silinmis bit
)
GO
CREATE TABLE Musteriler
(
	ID int IDENTITY(1,1) PRIMARY KEY,
	Isim nvarchar(75) NOT NULL,
	Soyisim nvarchar(75),
	KullaniciAdi nvarchar(75),
	Mail nvarchar(75),
	Sifre nvarchar(75),
	TelefonNumarasý nvarchar(50),
	KayitTarihi datetime,
	SonGirisTarihi datetime,
	Durum bit,
	Silinmis bit
)
GO
CREATE TABLE Iller
(
	ID int IDENTITY(1,1) PRIMARY KEY,
	Isim nvarchar(75) NOT NULL
)
GO
CREATE TABLE Ilceler
(
	ID int IDENTITY(1,1) PRIMARY KEY,
	IlID int FOREIGN KEY REFERENCES Iller(ID) NOT NULL,
	Isim nvarchar(75) NOT NULL
)
GO
CREATE TABLE AdresKategorileri
(
	ID int IDENTITY(1,1) PRIMARY KEY,
	Isim nvarchar(75) NOT NULL
)
GO
CREATE TABLE MusteriAdresleri
(
	ID int IDENTITY(1,1) PRIMARY KEY,
	AdresKategoriID int FOREIGN KEY REFERENCES AdresKategorileri(ID),
	MusteriID int FOREIGN KEY REFERENCES Musteriler(ID) NOT NULL,
	IlID int FOREIGN KEY REFERENCES Iller(ID) NOT NULL,
	IlceID int FOREIGN KEY REFERENCES Ilceler(ID),
	AdresAdi nvarchar(20),
	Adres nvarchar(200) NOT NULL,
	PostaKodu nvarchar(5),
	AdresTanimi nvarchar(50)
)
GO
CREATE TABLE Tedarikciler
(
	ID int IDENTITY(1,1) PRIMARY KEY,
	IlID int FOREIGN KEY REFERENCES Iller(ID) NOT NULL,
	IlceID int FOREIGN KEY REFERENCES Ilceler(ID),
	FirmaIsim nvarchar(75) NOT NULL,
	YetkiliIsim nvarchar(75),
	YetkiliUnvan nvarchar(75),
	TelefonNumarasý nvarchar(50),
	Adres nvarchar(200),
	Durum bit,
	Silinmis bit
)
GO
CREATE TABLE Urunler
(
	ID int IDENTITY(1,1) PRIMARY KEY,
	KategoriID int FOREIGN KEY REFERENCES Kategoriler(ID) NOT NULL,
	TedarikciID int FOREIGN KEY REFERENCES Tedarikciler(ID),
	Isim nvarchar(75),
	Stok smallint,
	ListeFiyat decimal(18,2), 
	Durum bit,
	Silinmis bit
)
GO
CREATE TABLE MusteriSepet
(
	ID int IDENTITY(1,1) PRIMARY KEY,
	MusteriID int FOREIGN KEY REFERENCES Musteriler(ID) NOT NULL,
	UrunID int FOREIGN KEY REFERENCES Urunler(ID) NOT NULL,
	Adet int,
	EklemeTarihi datetime,
)