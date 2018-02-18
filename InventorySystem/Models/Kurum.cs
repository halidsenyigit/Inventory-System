﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace InventorySystem.Models
{
    public class Kurum
    {

        [Key]
        public int KurumID { get; set; }

        public string Adi { get; set; }

        public virtual ICollection<Birim> Birimler { get; set; }
        public virtual ICollection<Stok> Stoklar { get; set; }
    }
}