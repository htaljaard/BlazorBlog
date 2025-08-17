using BlazorBlog.UI.Domain;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BlazorBlog.UI.Data;

public class BlogDBContext : IdentityDbContext<ApplicationUser>
{
    public DbSet<Blog> Blogs { get; set; }

    public BlogDBContext(DbContextOptions<BlogDBContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        
        modelBuilder.Entity<Blog>()
                    .ToTable("blogs");

        modelBuilder.Entity<Blog>()
                    .HasKey(b => b.Id);

        modelBuilder.Entity<Blog>()
                    .Property(b => b.Id)
                    .ValueGeneratedNever();
    }
}
