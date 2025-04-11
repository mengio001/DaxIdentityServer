using QuizTower.IDP.Entities;
using Microsoft.EntityFrameworkCore;

namespace QuizTower.IDP.DbContexts
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<AspNetUser> AspNetUsers { get; set; }

        public DbSet<AspNetUserClaim> AspNetUserClaims { get; set; }

        public DbSet<AspNetUserLogin> AspNetUserLogins { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<AspNetUser>()
            .HasIndex(u => u.Subject)
            .IsUnique();

            modelBuilder.Entity<AspNetUser>()
            .HasIndex(u => u.UserName)
            .IsUnique();

            modelBuilder.Entity<AspNetUser>().HasData(
                new AspNetUser()
                {
                    Id = new Guid("13229d33-99e0-41b3-b18d-4f72127e3971"),
                    Subject = "d860efca-22d9-47fd-8249-791ba61b07c7",
                    UserName = "David",
                    Email = "david@someprovider.com",
                    Active = true
                },
                new AspNetUser()
                {
                    Id = new Guid("96053525-f4a5-47ee-855e-0ea77fa6c55a"),
                    Subject = "b7539694-97e7-4dfe-84da-b4256e1ff5c7",
                    UserName = "Emma",
                    Email = "emma@someprovider.com",
                    Active = true
                },
                new AspNetUser()
                {
                    Id = new Guid("A120FD96-1DEA-4922-8403-289E5F2DBB6A"),
                    Subject = "B8C91EF2-7C41-4561-A323-A73B8F25F686",
                    UserName = "Admin",
                    Email = "admin@admin.com",
                    Active = true
                });

            modelBuilder.Entity<AspNetUserClaim>().HasData(
                new AspNetUserClaim()
                {
                    Id = Guid.NewGuid(),
                    UserId = new Guid("13229d33-99e0-41b3-b18d-4f72127e3971"),
                    Type = "given_name",
                    Value = "David"
                },
                new AspNetUserClaim()
                {
                    Id = Guid.NewGuid(),
                    UserId = new Guid("13229d33-99e0-41b3-b18d-4f72127e3971"),
                    Type = "family_name",
                    Value = "Flagg"
                },
                new AspNetUserClaim()
                {
                    Id = Guid.NewGuid(),
                    UserId = new Guid("13229d33-99e0-41b3-b18d-4f72127e3971"),
                    Type = "country",
                    Value = "nl"
                },
                new AspNetUserClaim()
                {
                    Id = Guid.NewGuid(),
                    UserId = new Guid("13229d33-99e0-41b3-b18d-4f72127e3971"),
                    Type = "role",
                    Value = "FreeUser"
                },
                new AspNetUserClaim()
                {
                    Id = Guid.NewGuid(),
                    UserId = new Guid("13229d33-99e0-41b3-b18d-4f72127e3971"),
                    Type = "role",
                    Value = "Player"
                },
                new AspNetUserClaim()
                {
                    Id = Guid.NewGuid(),
                    UserId = new Guid("96053525-f4a5-47ee-855e-0ea77fa6c55a"),
                    Type = "given_name",
                    Value = "Emma"
                },
                new AspNetUserClaim()
                {
                    Id = Guid.NewGuid(),
                    UserId = new Guid("96053525-f4a5-47ee-855e-0ea77fa6c55a"),
                    Type = "family_name",
                    Value = "Flagg"
                },
                new AspNetUserClaim()
                {
                    Id = Guid.NewGuid(),
                    UserId = new Guid("96053525-f4a5-47ee-855e-0ea77fa6c55a"),
                    Type = "country",
                    Value = "be"
                },
                new AspNetUserClaim()
                {
                    Id = Guid.NewGuid(),
                    UserId = new Guid("96053525-f4a5-47ee-855e-0ea77fa6c55a"),
                    Type = "role",
                    Value = "PayingUser"
                },
                new AspNetUserClaim()
                {
                    Id = Guid.NewGuid(),
                    UserId = new Guid("96053525-f4a5-47ee-855e-0ea77fa6c55a"),
                    Type = "role",
                    Value = "QuizMaster"
                }, 
                new AspNetUserClaim()
                {
                    Id = Guid.NewGuid(),
                    UserId = new Guid("A120FD96-1DEA-4922-8403-289E5F2DBB6A"),
                    Type = "given_name",
                    Value = "Admin"
                },
                new AspNetUserClaim()
                {
                    Id = Guid.NewGuid(),
                    UserId = new Guid("A120FD96-1DEA-4922-8403-289E5F2DBB6A"),
                    Type = "family_name",
                    Value = "Flagg"
                },
                new AspNetUserClaim()
                {
                    Id = Guid.NewGuid(),
                    UserId = new Guid("A120FD96-1DEA-4922-8403-289E5F2DBB6A"),
                    Type = "country",
                    Value = "nl"
                },
                new AspNetUserClaim()
                {
                    Id = Guid.NewGuid(),
                    UserId = new Guid("A120FD96-1DEA-4922-8403-289E5F2DBB6A"),
                    Type = "role",
                    Value = "Owner"
                },
                new AspNetUserClaim()
                {
                    Id = Guid.NewGuid(),
                    UserId = new Guid("A120FD96-1DEA-4922-8403-289E5F2DBB6A"),
                    Type = "role",
                    Value = "SecurityAdmin"
                });
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            // get updated entries
            var updatedConcurrencyAwareEntries = ChangeTracker.Entries()
                    .Where(e => e.State == EntityState.Modified)
                    .OfType<IConcurrencyAware>();

            foreach (var entry in updatedConcurrencyAwareEntries)
            {
                entry.ConcurrencyStamp = Guid.NewGuid().ToString();
            }

            return base.SaveChangesAsync(cancellationToken);
        }
    }
}
