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
        public DbSet<Registered> Registered { get; set; }
        public DbSet<RegisterStatus> RegisterStatus { get; set; }
        public DbSet<TicketType> TicketType { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<UserEvent>()
                .Property(uv => uv.Id)
                .HasValueGenerator<SequentialGuidValueGenerator>();

            builder.Entity<UserEvent>()
                .HasOne(e => e.Venue)
                .WithMany()
                .HasForeignKey(e => e.VenueId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Venue>()
                .Property(v => v.Id)
                .HasValueGenerator<SequentialGuidValueGenerator>();

            builder.Entity<Registered>()
                .Property(r => r.Id)
                .HasValueGenerator<SequentialGuidValueGenerator>();

            builder.Entity<TicketType>()
                .Property(tt => tt.Id)
                .HasValueGenerator<SequentialGuidValueGenerator>();

            builder.Entity<Registered>()
                .HasOne(r => r.TicketType)
                .WithMany(t => t.Registrations)
                .HasForeignKey(r => r.TicketTypeId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<RegisterStatus>()
                .HasData(
                    new RegisterStatus { Id = 1, Name = "Pending"},
                    new RegisterStatus { Id = 2, Name = "Confirmed" },
                    new RegisterStatus { Id = 3, Name = "Cancelled"},
                    new RegisterStatus { Id = 4, Name = "Checked-in"}
                );
        }
    }
}