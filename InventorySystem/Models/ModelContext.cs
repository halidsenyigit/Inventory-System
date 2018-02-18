using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace InventorySystem.Models {
    public class ModelContext : DbContext {
        public ModelContext() : base("conn") { }

        public DbSet<Kullanici> Kullanici { get; set; }
        public DbSet<MalzemeBilgi> MalzemeBilgi { get; set; }
        public DbSet<Stok> Stok { get; set; }
        public DbSet<Dagitim> Dagitim { get; set; }
        public DbSet<Kurum> Kurum { get; set; }
        public DbSet<Birim> Birim { get; set; }
        public DbSet<Transfer> Transfer { get; set; }


    }
}