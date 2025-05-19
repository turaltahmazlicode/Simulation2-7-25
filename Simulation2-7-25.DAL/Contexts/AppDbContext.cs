
using Simulation2_7_25.DAL.Models;

namespace Simulation2_7_25.DAL.Contexts;
public class AppDbContext : IdentityDbContext<AppUser>
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    public DbSet<Doctor> Doctors { get; set; }
    public DbSet<Profession> Professions { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.Entity<Doctor>().HasMany(d => d.Professions)
                                .WithMany(p => p.Doctors);

        builder.Entity<Profession>().HasIndex(p => p.Title)
                                    .IsUnique();
    }
}
