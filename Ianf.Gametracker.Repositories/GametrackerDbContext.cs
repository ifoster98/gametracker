using Microsoft.EntityFrameworkCore;
using Ianf.Gametracker.Repositories.Entities;

#nullable disable

namespace Ianf.Gametracker.Repositories
{
    public partial class GametrackerDbContext : DbContext
    {
        public GametrackerDbContext()
        {
        }

        public GametrackerDbContext(DbContextOptions<GametrackerDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<MatchEvent> MatchEvents { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=192.168.1.73; Database=Gametracker; User Id=SA; Password=31Freeble$");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<MatchEvent>(entity =>
            {
                entity.ToTable("MatchEvent");

                entity.Property(e => e.EventTime).HasColumnType("datetime");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
