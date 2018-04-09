using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace InventorySystem.Models
{
    public class Stok
    {
        public int StokID { get; set; }

        

        [Display(Name = "Seri Numarası")]
        [Required(ErrorMessage = "Bu alan boş bırakılamaz")]
        public string SeriNumarasi { get; set; }

        [Display(Name = "Garanti Başlangıç Tarihi")]
        [Required(ErrorMessage = "Bu alan boş bırakılamaz")]
        [DisplayFormat(ApplyFormatInEditMode = false, DataFormatString = "{0:dd.MM.yyyy}")]
        public DateTime GarantiTarihBaslangic { get; set; }

        [Display(Name = "Garanti Bitiş Tarihi")]
        [Required(ErrorMessage = "Bu alan boş bırakılamaz")]
        [DisplayFormat(ApplyFormatInEditMode = false, DataFormatString = "{0:dd.MM.yyyy}")]
        public DateTime GarantiTarihBitis { get; set; }

        [Display(Name = "Malzeme Birim Bedeli")]
        [Required(ErrorMessage = "Bu alan boş bırakılamaz")]
        public Double MalzemeBirimBedeli { get; set; }

        [Display(Name = "Adet")]
        [Required(ErrorMessage = "Bu alan boş bırakılamaz")]
        public int Adet { get; set; }

        [Display(Name = "Açıklama")]
        public string Aciklama { get; set; }

        [Display(Name = "Kurum")]
        public int KurumID { get; set; }

        [Display(Name = "Malzeme Bilgi")]
        public int MalzemeBilgiID { get; set; }


        public virtual Kurum Kurum { get; set; }
        public virtual MalzemeBilgi MalzemeBilgi { get; set; }
    }
}