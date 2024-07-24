using Microsoft.EntityFrameworkCore;
using Pegasus.API.Models.Data;

namespace Pegasus.API.Models;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    public DbSet<CallLog>? CallLogs { get; set; }
    public DbSet<Contact>? Contacts { get; set; }
    public DbSet<ContactPhoneNumber>? ContactPhoneNumbers { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Contact>()
        .HasMany(c => c.PhoneNumbers)
        .WithOne(pn => pn.Contact)
        .HasForeignKey(pn => pn.ContactId)
        .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<CallLog>()
            .HasOne(cl => cl.Contact)
            .WithMany()
            .HasForeignKey(cl => cl.ContactId)
            .OnDelete(DeleteBehavior.Cascade);

        base.OnModelCreating(modelBuilder);
    }
}