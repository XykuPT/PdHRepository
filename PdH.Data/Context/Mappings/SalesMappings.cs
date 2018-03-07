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

            Property(s => s.TotalAmount).HasColumnName("TotalAmount").HasColumnType("decimal").IsRequired().HasPrecision(15, 8);
            Property(s => s.TotalQuantity).HasColumnName("TotalQuantity").HasColumnType("bigint").IsRequired();
            Property(s => s.DeliveryAddress).HasColumnName("DeliveryAddress").HasColumnType("nvarchar").IsOptional().HasMaxLength(512);
            Property(s => s.DeliveryCod_Postal).HasColumnName("DeliveryCod_Postal").HasColumnType("nvarchar").IsOptional().HasMaxLength(8);
            Property(s => s.DeliveryLocation).HasColumnName("DeliveryLocation").HasColumnType("nvarchar").IsOptional().HasMaxLength(128);
            Property(s => s.DeliveryStatus).HasColumnName("DeliveryStatus").HasColumnType("nvarchar").IsOptional().HasMaxLength(128);
            Property(s => s.CustomerKey).HasColumnName("CustomerKey").HasColumnType("bigint").IsRequired();
            Property(s => s.SaleDate).HasColumnName("SaleDate").IsRequired();
            
            //HasRequired(s => s.Product).WithMany(p => p.Sales).HasForeignKey(s => s.ProductId); 
            //HasMany(s => s.SaleDetails).WithRequired(sd => sd.Sales);


        }
    }
}
