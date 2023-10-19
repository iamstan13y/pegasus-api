using Microsoft.EntityFrameworkCore;
using Pegasus.API.Models.Data;

namespace Pegasus.API.Models;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    public DbSet<CallLog>? CallLogs { get; set; }
}