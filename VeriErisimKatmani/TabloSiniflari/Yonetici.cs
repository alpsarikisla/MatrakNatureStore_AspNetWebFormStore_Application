using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VeriErisimKatmani.TabloSiniflari
{
    internal class Yonetici
    {
        public int ID { get; set; }
        public string Isim { get; set; }
        public string Soyisim { get; set; }
        public string KullaniciAdi { get; set; }
        public string Mail { get; set; }
        public string Sifre { get; set; }
        public DateTime SonGirisTarihi { get; set; }
        public bool Durum { get; set; }
        public string DurumStr { get; set; }
        public bool Silinmis { get; set; }
        public string SilinmisStr { get; set; }
    }
}
