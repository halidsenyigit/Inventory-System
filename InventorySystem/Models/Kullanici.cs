using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InventorySystem.Models
{
    public class Kullanici
    {

        public int KullaniciID { get; set; }

        public string Isim { get; set; }
        public string Soyisim { get; set; }
        public string KullaniciAdi { get; set; }
        public string Sifre { get; set; }
        

        public int? BirimID { get; set; }


        public virtual Birim Birim { get; set; }

        public virtual ICollection<KullaniciYetkiRel> KullaniciYetkiRel { get; set; }
    }
}