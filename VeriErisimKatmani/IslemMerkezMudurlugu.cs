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
    }
}
