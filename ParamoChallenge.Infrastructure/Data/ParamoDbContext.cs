using Microsoft.EntityFrameworkCore;
using ParamoChallenge.Core.Entities;
using ParamoChallenge.Infrastructure.Data.Configurations;

namespace ParamoChallenge.Infrastructure.Data;

public partial class ParamoDbContext : DbContext
{
    public ParamoDbContext()
    {
    }

    public ParamoDbContext(DbContextOptions<ParamoDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Article> Articles { get; set; }

    public virtual DbSet<Product> Products { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new ArticleConfiguration());

        modelBuilder.ApplyConfiguration(new ProductConfiguracion());


    }

}