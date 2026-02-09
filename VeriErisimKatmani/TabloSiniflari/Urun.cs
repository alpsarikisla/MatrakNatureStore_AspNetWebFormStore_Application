using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VeriErisimKatmani.TabloSiniflari
{
    public class Urun
    {
        public int ID { get; set; }
        public int KategoriID { get; set; }
        public int TedarikciID { get; set; }
        public string Isim { get; set; }
        public string Aciklama { get; set; }
        public short Stok { get; set; }
        public decimal ListeFiyat { get; set; }
        public string UrunResim { get; set; }
        public bool Durum { get; set; }
        public bool Silinmis { get; set; }

    }
}
