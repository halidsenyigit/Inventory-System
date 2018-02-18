using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace InventorySystem.Models
{
    public class MalzemeBilgi
    {
        public int MalzemeBilgiID { get; set; }

        [Display(Name = "Malzeme Kodu")]
        [MaxLength(10, ErrorMessage = "en fazla 10 karakter")]
        public string MalzemeKodu { get; set; }


        public string MalzemeAdi{ get; set; }

        public string MalzemeTanimi { get; set; }

        public string OrijinalStokKodu { get; set; }

        public string TeknikBilgi { get; set; }

        public string AmbarYazilimKodu { get; set; } // kurum yazılımına göre düzenlenecek

        public string Aciklama { get; set; }

        public virtual ICollection<Stok> Stoklar { get; set; }

    }
}