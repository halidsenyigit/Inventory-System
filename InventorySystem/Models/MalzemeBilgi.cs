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
        [Required(ErrorMessage = "Bu alan boş bırakılamaz")]
        public string MalzemeKodu { get; set; }

        [Display(Name = "Malzeme Adı")]
        [Required(ErrorMessage = "Bu alan boş bırakılamaz")]
        public string MalzemeAdi{ get; set; }

        [Display(Name = "Malzeme Tanımı")]
        [Required(ErrorMessage = "Bu alan boş bırakılamaz")]
        public string MalzemeTanimi { get; set; }

        [Display(Name = "Orijinal Stok Kodu")]
        [Required(ErrorMessage = "Bu alan boş bırakılamaz")]
        public string OrijinalStokKodu { get; set; }

        [Display(Name = "Teknik Bilgi")]
        public string TeknikBilgi { get; set; }

        [Display(Name = "Ambar Yazılım Kodu")]
        public string AmbarYazilimKodu { get; set; } // kurum yazılımına göre düzenlenecek

        [Display(Name = "Açıklama")]
        public string Aciklama { get; set; }

        public virtual ICollection<Stok> Stoklar { get; set; }

    }
}