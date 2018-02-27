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

            Property(sd => sd.SalesId).HasColumnName("SalesId").HasColumnType("bigint").IsRequired();

            Property(sd => sd.Units).HasColumnName("Units").HasColumnType("decimal").HasPrecision(6, 0).IsOptional();
            Property(sd => sd.UnitPrice).HasColumnName("UnitPrice").HasColumnType("decimal").HasPrecision(15, 8).IsOptional();
            Property(sd => sd.Amount).HasColumnName("Amount").HasColumnType("decimal").HasPrecision(15, 8).IsOptional();

            HasRequired(sd => sd.Sales).WithMany(s => s.SaleDetails);
        }
    }
}
