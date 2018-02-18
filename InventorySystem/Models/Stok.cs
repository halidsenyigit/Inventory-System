using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InventorySystem.Models
{
    public class Stok
    {
        public int StokID { get; set; }

        public int MalzemeBilgiID { get; set; }

        public string SeriNumarasi { get; set; }

        public DateTime GarantiTarihBaslangic { get; set; }

        public DateTime GarantiTarihBitis { get; set; }

        public Double MalzemeBirimBedeli { get; set; }

        public int Adet { get; set; }

        public int KurumID { get; set; }

        public string Aciklama { get; set; }



        public virtual Kurum Kurum { get; set; }
        public virtual MalzemeBilgi MalzemeBilgi { get; set; }
    }
}