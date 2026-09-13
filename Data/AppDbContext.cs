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
        public DbSet<YearLevel> YearLevel { get; set; }
        public DbSet<MerchPrice> MerchPrices { get; set; }
        public DbSet<Vote> Votes { get; set; }
        public DbSet<SystemSettings> SystemSettings { get; set; }
        
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<UserEvent>()
                .Property(uv => uv.Id)
                .HasValueGenerator<SequentialGuidValueGenerator>();

            builder.Entity<Venue>()
                .Property(v => v.Id)
                .HasValueGenerator<SequentialGuidValueGenerator>();

            builder.Entity<Registered>()
                .Property(r => r.Id)
                .HasValueGenerator<SequentialGuidValueGenerator>();

            builder.Entity<TicketType>()
                .Property(tt => tt.Id)
                .HasValueGenerator<SequentialGuidValueGenerator>();

            builder.Entity<Vote>()
                .Property(v => v.Id)
                .HasValueGenerator<SequentialGuidValueGenerator>();

            builder.Entity<UserEvent>()
                .HasOne(e => e.Venue)
                .WithMany()
                .HasForeignKey(e => e.VenueId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Registered>()
                .HasOne(r => r.TicketType)
                .WithMany(t => t.Registrations)
                .HasForeignKey(r => r.TicketTypeId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Registered>()
                .HasIndex(r => new { r.EventId, r.StudentNumber })
                .IsUnique();

            builder.Entity<RegisterStatus>()
                .HasData(
                    new RegisterStatus { Id = 1, Name = "Pending"},
                    new RegisterStatus { Id = 2, Name = "Confirmed" },
                    new RegisterStatus { Id = 3, Name = "Cancelled"},
                    new RegisterStatus { Id = 4, Name = "Checked-in"}
                );

            builder.Entity<YearLevel>()
                .HasData(
                    new YearLevel { YearLevelId = 1, Level = "1st Year" },
                    new YearLevel { YearLevelId = 2, Level = "2nd Year" },
                    new YearLevel { YearLevelId = 3, Level = "3rd Year" },
                    new YearLevel { YearLevelId = 4, Level = "4th Year" }
                );

            builder.Entity<MerchPrice>()
                .HasData(
                    new MerchPrice { Id = 1, Item = "Membership Fee", Price = 20.00},
                    new MerchPrice { Id = 2, Item = "Wind Breaker", Price = 1200.00 },
                    new MerchPrice { Id = 3, Item = "Hoodie", Price = 290.00},
                    new MerchPrice { Id = 4, Item = "T-shirt", Price = 290.00},
                    new MerchPrice { Id = 5, Item = "Polo Shirt", Price = 290.00},
                    new MerchPrice { Id = 6, Item = "ID Non-Reversible", Price = 85.00},
                    new MerchPrice { Id = 7, Item = "ID Reversible", Price = 120.00},
                    new MerchPrice { Id = 8, Item = "Mouse Pad", Price = 120.00},
                    new MerchPrice { Id = 9, Item = "Cap", Price = 120.00}
                );

            builder.Entity<SystemSettings>()
                .HasData(
                    new SystemSettings { Id = 1, Key = "Voting", IsEnabled = false }
                );
        }
    }
}