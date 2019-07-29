using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Contratos_vers_beta.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext()
            : base("DefaultConnection")
        {
        }

        public DbSet<Contratos> Contratos { get; set; }
        public DbSet<PDFContratos> PDFContratos { get; set; }
        public DbSet<ManageAccount> ManageAccounts { get; set; }
        public DbSet<ModifiedContratos> ModifiedContratos { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PDFContratos>().HasRequired(x => x.Contratos);

            base.OnModelCreating(modelBuilder);
        }
    }
}