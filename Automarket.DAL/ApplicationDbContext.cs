using Automarket.Domain.Entity;
using Automarket.Domain.Enum;
using Automarket.Domain.Helpers;
using Microsoft.EntityFrameworkCore;

namespace Automarket.DAL
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            Database.EnsureCreated();
        }
        
        public DbSet<Car> Cars { get; set; }
        
        public DbSet<User> Users { get; set; }
        
        public DbSet<Profile> Profiles { get; set; }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>(builder =>
            {
                builder.ToTable("Users").HasKey(x => x.Id);
                
                builder.HasData(new User
                {
                    Id = 1,
                    Name = "ITHomester",
                    Password = HashPasswordHelper.HashPassowrd("123456"),
                    Role = Role.Admin
                });

                builder.Property(x => x.Id).ValueGeneratedOnAdd();

                builder.Property(x => x.Password).IsRequired();
                builder.Property(x => x.Name).HasMaxLength(100).IsRequired();
                
                builder.HasOne(x => x.Profile)
                    .WithOne(x => x.User)
                    .HasPrincipalKey<User>(x => x.Id)
                    .OnDelete(DeleteBehavior.ClientCascade);
            });

            modelBuilder.Entity<Profile>(builder =>
            {
                builder.ToTable("Profiles").HasKey(x => x.Id);

                builder.Property(x => x.Id).ValueGeneratedOnAdd();
                
                builder.Property(x => x.Age);
                builder.Property(x => x.Address).HasMaxLength(250);
                builder.Property(x => x.UserId);
            });
        }
    }
}