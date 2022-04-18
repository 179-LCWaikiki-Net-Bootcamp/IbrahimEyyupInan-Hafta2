using IbrahimEyyupInan_Hafta2.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IbrahimEyyupInan_Hafta2.Data
{
        public class ProductConfiguration : IEntityTypeConfiguration<Product>
        {
            public void Configure(EntityTypeBuilder<Product> entity)
            {
                entity.HasKey(e => e.Id);
                entity.Property(p => p.sku).IsRequired();
                entity.HasOne(e=>e.category).WithMany(e=>e.products)
                .HasForeignKey(e=>e.categoryId);

               
            }
        }
    
}
