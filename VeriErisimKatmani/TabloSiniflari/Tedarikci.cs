using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VeriErisimKatmani.TabloSiniflari
{
    public class Tedarikci
    {
        public int ID { get; set; }
        public int IlID { get; set; }
        public string Il { get; set; }
        public int IlceID { get; set; }
        public string Ilce { get; set; }
        public string FirmaIsim { get; set; }
        public string YetkiliIsim { get; set; }
        public string YetkiliUnvan { get; set; }
        public string TelefonNumarasi { get; set; }
        public string Adres { get; set; }
        public bool Durum { get; set; }
        public string DurumStr { get; set; }
        public bool Silinmis { get; set; }
    }
}
