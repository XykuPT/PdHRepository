using PdH.Entities;
using System.Data.Entity.ModelConfiguration;

namespace PdH.Data.Context.Mappings
{
    public class SalesMappings : EntityTypeConfiguration<Sales>
    {
        public SalesMappings() { 

            ToTable("Sales");
            HasKey(s => s.Id);

            Property(s => s.Id).HasColumnName(@"Id")
                .HasColumnType("bigint")
                .IsRequired()
                .HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);


            Property(s => s.ProductId).HasColumnName("ProductId").HasColumnType("bigint").IsRequired();
            Property(s => s.SaleId).HasColumnName("SaleId").HasColumnType("bigint").IsOptional();

            Property(s => s.CustomerKey).HasColumnName("CustomerKey").HasColumnType("bigint").IsOptional();
            Property(s => s.SaleDate).HasColumnName("SaleDate").IsOptional();

            //check this?
            //HasRequired(s => s.Product).WithMany(x => x.Sales).HasForeignKey(x => x.PharmacyId); 
            HasMany(s => s.SaleDetails).WithRequired(sd => sd.Sales);


        }
    }
}
