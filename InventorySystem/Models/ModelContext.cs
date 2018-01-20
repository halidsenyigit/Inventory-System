using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace InventorySystem.Models {
    public class ModelContext : DbContext {
        public ModelContext() : base("conn") { }

        public DbSet<User> User { get; set; }

    }
}