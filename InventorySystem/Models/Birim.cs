using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace InventorySystem.Models
{
    public class Birim
    {
        public int BirimID { get; set; }

        [Display(Name = "Birim Adı")]
        [Required(ErrorMessage = "Bu alan boş bırakılamaz")]
        public string Adi { get; set; }

        [Display(Name = "Kurum")]
        public int KurumID { get; set; }


        public virtual Kurum Kurum { get; set; }
        public virtual ICollection<Dagitim> Dagitimlar { get; set; }
    }
}