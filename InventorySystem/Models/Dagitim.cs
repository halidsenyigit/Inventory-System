using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace InventorySystem.Models
{
    public class Dagitim
    {
        public int DagitimID { get; set; }

        public int Adet { get; set; }

        public string EvrakSayi { get; set; }

        [DataType(DataType.Date)]
        public DateTime Tarih { get; set; }

        public int BirimID { get; set; }


        public virtual Birim Birim { get; set; }
    }
}