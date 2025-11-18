using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VeriErisimKatmani.TabloSiniflari
{
    public class Kategori
    {
        public int ID { get; set; }
        public string Isim { get; set; }
        public bool YayinDurum { get; set; }
        public bool Silinmis { get; set; }
    }
}
