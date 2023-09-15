using Microsoft.EntityFrameworkCore;

namespace UnicornManager.DBLib;

public class UnicornDbContext : DbContext
{
    #region Properties

    public DbSet<Unicorn> Unicorns { get; set; }

    #endregion

    #region Methods

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);

        if (optionsBuilder.IsConfigured == false)
        {
            optionsBuilder.UseSqlite("Data Source=unciorn.db");
        }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Unicorn>(e =>
        {
            e.HasKey(e => e.Identifier);

            e.Property(e => e.Name)
                .HasMaxLength(256)
                .IsUnicode();

            e.Property(e => e.Birthdate)
                .HasColumnType("DATE");
        });
    }

    #endregion
}
