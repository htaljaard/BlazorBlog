using BlazorBlog.UI.Domain;
using Microsoft.EntityFrameworkCore;

namespace BlazorBlog.UI.Data;

public class BlogDBContext : DbContext
{
    public DbSet<Blog> Blogs { get; set; }

    public BlogDBContext(DbContextOptions<BlogDBContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Blog>()
                    .ToTable("blogs");

        modelBuilder.Entity<Blog>()
                    .HasKey(b => b.Id);

        modelBuilder.Entity<Blog>()
                    .Property(b => b.Id)
                    .ValueGeneratedNever();
    }
}
