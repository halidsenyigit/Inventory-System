using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InventorySystem.Models
{
    public class KullaniciYetkiRel
    {
        public int KullaniciYetkiRelID { get; set; }

        public int KullaniciID { get; set; }
        public int YetkiID { get; set; }


        public virtual Kullanici Kullanici { get; set; }
        public virtual Yetki Yetki { get; set; }
    }
}