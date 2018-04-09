using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace InventorySystem.Models
{
    public class Transfer
    {
        public int TransferID { get; set; }


        [Display(Name = "Transfer Eden Birim")]
        public int BulunduguBirim { get; set; } // bulunduğu kurum

        [Display(Name = "Transfer Edilen Birim")]
        public int TransferEdilenBirim { get; set; }

        [Display(Name = "Transfer Tarihi")]
        [DisplayFormat(ApplyFormatInEditMode = false, DataFormatString = "{0:dd.MM.yyyy}")]
        public DateTime Tarih { get; set; }

        public int DagitimID { get; set; }


        public virtual Dagitim Dagitim { get; set; }
    }
}