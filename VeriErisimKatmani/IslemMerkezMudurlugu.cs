using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VeriErisimKatmani.TabloSiniflari;

namespace VeriErisimKatmani
{
    internal class IslemMerkezMudurlugu
    {
        SqlConnection baglanti;
        SqlCommand komut;
        public IslemMerkezMudurlugu()
        {
            baglanti = new SqlConnection(BaglantiYollari.SqlServerBaglantiYolu);
            komut = baglanti.CreateCommand();
        }



        #region Kategori Metotları

        //Listeleme
        public List<Kategori> KategoriListele()
        {
            List<Kategori> kategoriler = new List<Kategori>();
            try
            {
                komut.CommandText = "SELECT ID, Isim, YayinDurum, Silinmis FROM Kategoriler";
                baglanti.Open();
                SqlDataReader okuyucu = komut.ExecuteReader();
                while (okuyucu.Read())
                {
                    Kategori kategori = new Kategori
                    {
                        ID = okuyucu.GetInt32(0),
                        Isim = okuyucu.GetString(1),
                        YayinDurum = okuyucu.GetBoolean(2),
                        Silinmis = okuyucu.GetBoolean(3)
                    };
                    kategoriler.Add(kategori);
                }
                okuyucu.Close();
            }
            catch
            {
                return null;
            }
            finally
            {
                baglanti.Close();
            }
            return kategoriler;
        }

        public List<Kategori> KategoriListele(bool silinmis)
        {
            List<Kategori> kategoriler = new List<Kategori>();
            try
            {
                komut.CommandText = silinmis ? "SELECT ID, Isim, YayinDurum, Silinmis FROM Kategoriler WHERE Silinmis = 1": "SELECT ID, Isim, YayinDurum, Silinmis FROM Kategoriler WHERE Silinmis = 0";
                baglanti.Open();
                SqlDataReader okuyucu = komut.ExecuteReader();
                while (okuyucu.Read())
                {
                    Kategori kategori = new Kategori
                    {
                        ID = okuyucu.GetInt32(0),
                        Isim = okuyucu.GetString(1),
                        YayinDurum = okuyucu.GetBoolean(2),
                        Silinmis = okuyucu.GetBoolean(3)
                    };
                    kategoriler.Add(kategori);
                }
                okuyucu.Close();
            }
            catch
            {
                return null;
            }
            finally
            {
                baglanti.Close();
            }
            return kategoriler;
        }

        //Eklememe
        public bool KategoriEkle(Kategori kategori)
        {
            try
            {
                komut.CommandText = "INSERT INTO Kategoriler (Isim, YayinDurum, Silinmis) VALUES (@Isim, @YayinDurum, @Silinmis)";
                komut.Parameters.Clear();
                komut.Parameters.AddWithValue("@Isim", kategori.Isim);
                komut.Parameters.AddWithValue("@YayinDurum", kategori.YayinDurum);
                komut.Parameters.AddWithValue("@Silinmis", kategori.Silinmis);
                baglanti.Open();
                komut.ExecuteNonQuery();
                return true;
            }
            catch
            {
                return false;
            }
            finally
            {
                baglanti.Close();
            }
        }

        //Güncelleme
        public bool KategoriGuncelle(Kategori kategori)
        {
            try
            {
                komut.CommandText = "UPDATE Kategoriler SET Isim = @Isim, YayinDurum = @YayinDurum, Silinmis = @Silinmis WHERE ID = @ID";
                komut.Parameters.Clear();
                komut.Parameters.AddWithValue("@Isim", kategori.Isim);
                komut.Parameters.AddWithValue("@YayinDurum", kategori.YayinDurum);
                komut.Parameters.AddWithValue("@Silinmis", kategori.Silinmis);
                komut.Parameters.AddWithValue("@ID", kategori.ID);
                baglanti.Open();
                komut.ExecuteNonQuery();
                return true;
            }
            catch
            {
                return false;
            }
            finally
            {
                baglanti.Close();
            }
        }

        //Silme - SoftDelete
        public bool KategoriSil(int kategoriID)
        {
            try
            {
                komut.CommandText = "UPDATE Kategoriler SET Silinmis = 1 WHERE ID = @ID";
                komut.Parameters.Clear();
                komut.Parameters.AddWithValue("@ID", kategoriID);
                baglanti.Open();
                komut.ExecuteNonQuery();
                return true;
            }
            catch
            {
                return false;
            }
            finally
            {
                baglanti.Close();
            }
        }

        //Diğer İşlemler


        #endregion


        #region Yönetici Metotları

        //Yönetici Giriş
        public Yonetici YoneticiGiris(string mail, string sifre)
        {
            Yonetici y = null;
            try
            {
                komut.CommandText = "SELECT COUNT(*) FROM Yoneticiler WHERE Mail = @m AND Sifre=@s";
                komut.Parameters.Clear();
                komut.Parameters.AddWithValue("@m", mail);
                komut.Parameters.AddWithValue("@s", sifre);
                baglanti.Open();
                int sayi = Convert.ToInt32(komut.ExecuteScalar());
                if (sayi > 0)
                {
                    y = new Yonetici();
                    komut.CommandText = "SELECT ID, Isim, Soyisim, KullaniciAdi, Mail, Sifre, SonGirisTarihi, Durum, Silinmis WHERE Mail = @m AND Sifre=@s";
                    komut.Parameters.Clear();
                    komut.Parameters.AddWithValue("@m", mail);
                    komut.Parameters.AddWithValue("@s", sifre);
                    SqlDataReader okuyucu = komut.ExecuteReader();
                    while (okuyucu.Read())
                    {
                        y.ID = okuyucu.GetInt32(0);
                        y.Isim = okuyucu.GetString(1);
                        y.Soyisim = okuyucu.GetString(2);
                        y.KullaniciAdi = okuyucu.GetString(3);
                        y.Mail = okuyucu.GetString(4);
                        y.Sifre = okuyucu.GetString(5);
                        y.SonGirisTarihi = okuyucu.GetDateTime(6);
                        y.Durum = okuyucu.GetBoolean(7);
                        y.DurumStr = y.Durum ? "Aktif" : "Pasif";
                        y.Silinmis = okuyucu.GetBoolean(8);
                    }
                }
            }
            finally
            {
                baglanti.Close();
            }
            return y;
        }

        //Yonetici Kontrol
        public byte YoneticiKontrol(string KullaniciAdi, string Mail)
        {
            byte sonuc = 0;
            try
            {
                komut.CommandText = "SELECT COUNT(*) FROM Yoneticiler WHERE KullaniciAdi = @ka";
                komut.Parameters.Clear();
                komut.Parameters.AddWithValue("@ka", KullaniciAdi);
                baglanti.Open();
                int ka_sayi = Convert.ToInt32(komut.ExecuteScalar());
                if (ka_sayi > 0) { sonuc = 1; }
                komut.CommandText = "SELECT COUNT(*) FROM Yoneticiler WHERE Mail = @m";
                komut.Parameters.Clear();
                komut.Parameters.AddWithValue("@m", Mail);
                int m_sayi = Convert.ToInt32(komut.ExecuteScalar());
                if (m_sayi > 0) { sonuc = 2; }
                
            }
            finally{baglanti.Close();}
            return sonuc;
        }

        //Yönetici Ekle

        //Yönetici Listele

        //Yönetici Getir

        //Yönetici Güncelle

        //Yönetici Sil

        #endregion
    }
}
