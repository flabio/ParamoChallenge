using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ParamoChallenge.Core.Entities;

namespace ParamoChallenge.Infrastructure.Data.Configurations
{
    public class ArticleConfiguration : IEntityTypeConfiguration<Article>
    {
        public void Configure(EntityTypeBuilder<Article> builder)
        {
            builder.HasKey(e => e.IdArticle);

            builder.ToTable("Article");

            builder.Property(e => e.Name).HasMaxLength(250);
        }
    }
}
