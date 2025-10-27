

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using xbiz_store.Models;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Security.Claims;

namespace xbiz_store.Context
{
    public class StoreContext: DbContext,IStoreContext
    {
        public StoreContext() { }
        public StoreContext(DbContextOptions<StoreContext> options) : base(options){
         
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // 🔹 Ejemplo: configuración de mapeo si los nombres no coinciden
           // modelBuilder.Entity<Product>(entity =>
           // {
             //  entity.ToTable("ivprd");
             //  entity.HasKey(e => e.Codigo);
                //entity.Property(e => e.Nombre).HasColumnName("ivprdnomb");
                //entity.Property(e => e.Descripcion).HasColumnName("ivprddesc");
                // etc...
          //  });
        }

        public DbContext Instance => this;
        public DbSet<Product> Product { get; set;  }

        // 🔹 Si tienes más entidades, agrégalas aquí
        // public DbSet<Category> Categories { get; set; }
        // public DbSet<Customer> Customers { get; set; }

     


       
    }
}
