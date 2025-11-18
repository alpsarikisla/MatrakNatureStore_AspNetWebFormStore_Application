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
            catch (Exception ex)
            {
                return null;
                // Hata yönetimi burada yapılabilir
                //throw new Exception("Kategori listeleme hatası: " + ex.Message);
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
            catch (Exception ex)
            {
                return null;
                // Hata yönetimi burada yapılabilir
                //throw new Exception("Kategori listeleme hatası: " + ex.Message);
            }
            finally
            {
                baglanti.Close();
            }
            return kategoriler;
        }
        //Eklememe

        //Güncelleme

        //Silme

        //Diğer İşlemler


        #endregion
    }
}
