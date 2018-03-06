using System.Data.Entity;
using System.Linq;

namespace PdH.Data.Context.Mappings
{
    public class PdHContext : DbContext
    {
        public PdHContext() : base("PdHContext")
        {
            Configuration.LazyLoadingEnabled = false;
            Configuration.AutoDetectChangesEnabled = false;
            Database.SetInitializer<PdHContext>(null);
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Configurations.Add(new ProductMapping());
            modelBuilder.Configurations.Add(new SalesMappings());
            modelBuilder.Configurations.Add(new SaleDetailsMappings());
        }
    }
}
