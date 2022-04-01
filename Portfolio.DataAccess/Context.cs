using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Portfolio.Entity;

namespace Portfolio.DataAccess;

public class Context : IdentityDbContext<ApplicationUser>
{
    public Context(DbContextOptions options)
        :base(options)
    {
    }
    public DbSet<Request> Requests { get; set; }
    public DbSet<Tag> Tags { get; set; }
    public DbSet<Post> Posts { get; set; }
}