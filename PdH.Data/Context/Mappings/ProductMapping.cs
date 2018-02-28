using PdH.Entities;
using System.Data.Entity.ModelConfiguration;

namespace PdH.Data.Context.Mappings
{
    public class ProductMapping : EntityTypeConfiguration<Product>
    {
        public ProductMapping()
        {
            ToTable("Product");
            HasKey(p => p.Id);

            Property(p => p.Id).HasColumnName(@"Id")
                .HasColumnType("bigint")
                .IsRequired()
                .HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);

            Property(p => p.Code).HasColumnName("Code").HasColumnType("varchar").IsOptional().HasMaxLength(15);
            Property(p => p.Name).HasColumnName("Name").HasColumnType("nvarchar").IsOptional().HasMaxLength(512);
            Property(p => p.Material).HasColumnName("material").HasColumnType("nvarchar").IsOptional().HasMaxLength(128);
            Property(p => p.Color).HasColumnName("Color").HasColumnType("nvarchar").IsOptional().HasMaxLength(128);
            Property(p => p.Size).HasColumnName("Size").HasColumnType("nvarchar").IsOptional().HasMaxLength(20);
            Property(p => p.Category).HasColumnName("Category").HasColumnType("nvarchar").IsOptional().HasMaxLength(128);

            Property(p => p.IsActive).HasColumnName("IsActive").HasColumnType("bit").IsOptional();
            Property(p => p.CreatedOn).HasColumnName("CreatedOn").IsRequired();
            Property(p => p.CreatedBy).HasColumnName("CreatedBy").IsRequired().HasMaxLength(128);
            Property(p => p.UpdatedOn).HasColumnName("UpdatedOn").IsRequired();
            Property(p => p.UpdatedBy).HasColumnName("UpdatedBy").IsRequired().HasMaxLength(128);

            HasMany(p => p.Sales).WithRequired(s => s.Product);
        }
    }
}
