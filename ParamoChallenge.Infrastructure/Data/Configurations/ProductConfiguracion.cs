using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ParamoChallenge.Core.Entities;
namespace ParamoChallenge.Infrastructure.Data.Configurations
{
    public class ProductConfiguracion : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(e => e.IdProduct);

            builder.ToTable("Product");

            builder.Property(e => e.Date).HasColumnType("date");
            builder.Property(e => e.Description).HasColumnType("text");
            builder.Property(e => e.Name).HasMaxLength(250);

            builder.HasOne(d => d.IdArticleNavigation).WithMany(p => p.Products)
                .HasForeignKey(d => d.IdArticle)
                .HasConstraintName("FK_Product_Article");
        }
    }
}
