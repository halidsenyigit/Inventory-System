using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InventorySystem.Models
{
    public class Yetki
    {
        public int YetkiID { get; set; }
        public string Adi { get; set; }

        

        public virtual ICollection<KullaniciYetkiRel> KullaniciYetkiRel { get; set; }

    }
}