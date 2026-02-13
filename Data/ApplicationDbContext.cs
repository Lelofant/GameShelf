using GameShelf.Models;
using Microsoft.EntityFrameworkCore;

namespace GameShelf.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {

        }

        public DbSet<Game> Games { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Platform> Platforms { get; set; }

        protected override void OnModelCreating(ModelBuilder entity)
        {
            base.OnModelCreating(entity);

            entity.Entity<Platform>(entity =>
            {
                entity.HasKey(p => p.Id);
                entity.HasIndex(p => p.Name).IsUnique();
                entity.Property(p => p.Name).IsRequired().HasMaxLength(100);
                entity.Property(p => p.Manufacturer).HasMaxLength(100).IsRequired();
                entity.Property(p => p.Description).HasMaxLength(500);
            });

            entity.Entity<Genre>(entity =>
            {
                entity.HasKey(g => g.Id);
                entity.HasIndex(g => g.Name).IsUnique();
                entity.Property(g => g.Name).IsRequired().HasMaxLength(100);
                entity.Property(g => g.Description).HasMaxLength(500);
            });

            entity.Entity<Game>(entity =>
            {
                entity.HasKey(g => g.Id);

                entity.Property(g => g.Title).IsRequired().HasMaxLength(200);

                entity.Property(g => g.Developer).IsRequired().HasMaxLength(100);

                entity.Property(g => g.Publisher).HasMaxLength(100);

                entity.Property(g => g.ReleaseDate).IsRequired();

                entity.Property(g => g.Price).HasColumnType("decimal(18, 2)").IsRequired();

                entity.Property(g => g.Rating).HasDefaultValue(1).HasColumnType("int");

                entity.Property(g => g.Description).HasMaxLength(1000);

                entity.Property(g => g.IsCompleted).HasDefaultValue(false);

                entity.Property(g => g.PurchaseDate).HasColumnType("date");

                entity.HasOne(g => g.Platform)
                    .WithMany(p => p.Games)
                    .HasForeignKey(g => g.PlatformId)
                    .OnDelete(DeleteBehavior.Cascade);

                entity.HasOne(g => g.Genre)
                    .WithMany(gen => gen.Games)
                    .HasForeignKey(g => g.GenreId)
                    .OnDelete(DeleteBehavior.Cascade);
            });
            SeedData(entity);
        }

        private void SeedData(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Platform>().HasData(
                new Platform { Id = 1, Name = "PC", Manufacturer = "Various", Description = "Personal Computer gaming platform" },
                new Platform { Id = 2, Name = "PlayStation 5", Manufacturer = "Sony", Description = "Sony's next-generation gaming console" },
                new Platform { Id = 3, Name = "Xbox Series X", Manufacturer = "Microsoft", Description = "Microsoft's powerful gaming console" },
                new Platform { Id = 4, Name = "Nintendo Switch", Manufacturer = "Nintendo", Description = "Hybrid home and portable console" }
            );

            modelBuilder.Entity<Genre>().HasData(
                new Genre { Id = 1, Name = "Action", Description = "Fast-paced games focusing on physical challenges" },
                new Genre { Id = 2, Name = "RPG", Description = "Role-playing games with character development" },
                new Genre { Id = 3, Name = "Strategy", Description = "Games requiring tactical thinking and planning" },
                new Genre { Id = 4, Name = "Sports", Description = "Sports simulation and competition games" },
                new Genre { Id = 5, Name = "Adventure", Description = "Story-driven exploration games" },
                new Genre { Id = 6, Name = "Simulation", Description = "Games simulating real-world activities" }
            );

            modelBuilder.Entity<Game>().HasData(
                new Game
                {
                    Id = 1,
                    Title = "The Witcher 3: Wild Hunt",
                    Developer = "CD Projekt Red",
                    Publisher = "CD Projekt",
                    ReleaseDate = new DateTime(2015, 5, 19),
                    Price = 39.99m,
                    Rating = 10,
                    Description = "An epic open-world RPG adventure in a dark fantasy universe",
                    IsCompleted = true,
                    PurchaseDate = new DateTime(2023, 6, 15),
                    PlatformId = 1,
                    GenreId = 2,
                },
                new Game
                {
                    Id = 2,
                    Title = "God of War",
                    Developer = "Santa Monica Studio",
                    Publisher = "Sony Interactive Entertainment",
                    ReleaseDate = new DateTime(2018, 4, 20),
                    Price = 49.99m,
                    Rating = 9,
                    Description = "Follow Kratos and Atreus in Norse mythology",
                    IsCompleted = false,
                    PurchaseDate = new DateTime(2023, 12, 25),
                    PlatformId = 2,
                    GenreId = 1,
                },
                new Game
                {
                    Id = 3,
                    Title = "Halo Infinite",
                    Developer = "343 Industries",
                    Publisher = "Xbox Game Studios",
                    ReleaseDate = new DateTime(2021, 12, 8),
                    Price = 59.99m,
                    Rating = 8,
                    Description = "Master Chief returns in this epic sci-fi shooter",
                    IsCompleted = false,
                    PlatformId = 3,
                    GenreId = 1,
                },
                new Game
                {
                    Id = 4,
                    Title = "The Legend of Zelda: Breath of the Wild",
                    Developer = "Nintendo EPD",
                    Publisher = "Nintendo",
                    ReleaseDate = new DateTime(2017, 3, 3),
                    Price = 59.99m,
                    Rating = 10,
                    Description = "Explore the vast kingdom of Hyrule in this open-world adventure",
                    IsCompleted = true,
                    PurchaseDate = new DateTime(2023, 8, 10),
                    PlatformId = 4,
                    GenreId = 5,
                }
            );
        }
    }

}