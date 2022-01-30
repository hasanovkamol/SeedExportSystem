using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeedExportSystem.Model
{
    public class DbContextEntity:DbContext
    {
        public DbContextEntity():base("name=dbSeedExport")
        {
            
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
        public DbSet<Export> Exports { get; set; }
        public DbSet<KeyValue> KeyValues { get; set; }
        public DbSet<Predmet> Predmets { get; set; }
        public DbSet<Atribut> Atributs { get; set;}
        public DbSet<Qiymat>  Qiymats { get; set; }
    }
}
