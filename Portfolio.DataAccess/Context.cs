using Microsoft.EntityFrameworkCore;
using Portfolio.Entity;

namespace Portfolio.DataAccess;

public class Context : DbContext
{
    public Context(DbContextOptions options)
        :base(options)
    {
    }
    public DbSet<Request> Requests { get; set; }
}