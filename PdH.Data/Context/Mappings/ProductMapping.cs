using PdH.Entities;
using System.Data.Entity.ModelConfiguration;

namespace PdH.Data.Context.Mappings
{
    public class ProductMapping : EntityTypeConfiguration<Product>
    {
        public ProductMapping()
        {
            ToTable("Product");
            HasKey(x => x.Id);

            Property(x => x.Id).HasColumnName(@"Id")
                .HasColumnType("bigint")
                .IsRequired()
                .HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);

            Property(x => x.Name).HasColumnName(@"Name").HasColumnType("nvarchar").IsOptional().HasMaxLength(512);
            Property(x => x.Color).HasColumnName(@"Color").HasColumnType("nvarchar").IsOptional().HasMaxLength(128);
            Property(x => x.Size).HasColumnName(@"Size").HasColumnType("nvarchar").IsOptional().HasMaxLength(20);

            Property(x => x.IsActive).HasColumnName(@"IsActive").HasColumnType("bit").IsOptional();
            Property(x => x.CreatedOn).HasColumnName(@"CreatedOn").IsRequired();
            Property(x => x.CreatedBy).HasColumnName(@"CreatedBy").IsRequired().HasMaxLength(128);
            Property(x => x.UpdatedOn).HasColumnName(@"UpdatedOn").IsRequired();
            Property(x => x.UpdatedBy).HasColumnName(@"UpdatedBy").IsRequired().HasMaxLength(128);

        }
    }
}
