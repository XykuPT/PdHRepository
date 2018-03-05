using PdH.Entities;
using System.Data.Entity.ModelConfiguration;

namespace PdH.Data.Context.Mappings
{
    public class SaleDetailsMappings : EntityTypeConfiguration<SaleDetails>
    {
        public SaleDetailsMappings()
        {
            ToTable("SaleDetails");
            HasKey(sd => sd.Id);

            Property(sd => sd.Id).HasColumnName(@"Id")
                .HasColumnType("bigint")
                .IsRequired()
                .HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);

            Property(sd => sd.ProductId).HasColumnName("ProductId").HasColumnType("bigint").IsRequired();
            Property(sd => sd.SaleId).HasColumnName("SaleId").HasColumnType("bigint").IsRequired();
            Property(sd => sd.ProductQuantity).HasColumnName("ProductQuantity").HasColumnType("bigint").IsRequired();
            Property(sd => sd.ProductAmount).HasColumnName("ProductAmount").HasColumnType("decimal").HasPrecision(15, 8).IsRequired();
            Property(sd => sd.SaleDate).HasColumnName("SaleDate").IsRequired();

            HasRequired(sd => sd.Product).WithMany(p => p.SaleDetails).HasForeignKey(sd => sd.ProductId);
            HasRequired(sd => sd.Sales).WithMany(s => s.SaleDetails).HasForeignKey(sd => sd.SaleId);
        }
    }
}
