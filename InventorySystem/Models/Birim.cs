using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InventorySystem.Models
{
    public class Birim
    {
        public int BirimID { get; set; }

        public string Adi { get; set; }

        public int KurumID { get; set; }


        public virtual Kurum Kurum { get; set; }
        public virtual ICollection<Dagitim> Dagitimlar { get; set; }
    }
}