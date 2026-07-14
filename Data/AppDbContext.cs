using EMSWebApp.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ValueGeneration;

namespace EMSWebApp.Data
{
    public class AppDbContext(DbContextOptions<AppDbContext> options) : IdentityDbContext<AppUser, IdentityRole<int>, int>(options)
    {
        public DbSet<UserEvent> UserEvents { get; set; }
        public DbSet<Venue> Venues { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<UserEvent>()
                .Property(uv => uv.Id)
                .HasValueGenerator<SequentialGuidValueGenerator>();

            builder.Entity<Venue>()
                .Property(v => v.Id)
                .HasValueGenerator<SequentialGuidValueGenerator>();
        }
    }
}