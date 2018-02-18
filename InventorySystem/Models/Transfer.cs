using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InventorySystem.Models
{
    public class Transfer
    {
        public int TransferID { get; set; }

        public int BulunduguBirim { get; set; }
        public int TransferEdilenBirim { get; set; }
        public DateTime Tarih { get; set; }

        public int DagitimID { get; set; }


        public virtual Dagitim Dagitim { get; set; }
    }
}