namespace Data
{
    using System;
    using Microsoft.EntityFrameworkCore;

    public class Context : DbContext
    {
        public DbSet<EDetection> Detections { get; set; }

        public Context(DbContextOptions<Context> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<EDetection>().HasData(new EDetection[]
            {
                new EDetection { Id = 1, Class = "pet", Score = 1, Timestamp = DateTime.UtcNow },
                new EDetection { Id = 2, Class = "pet", Score = 5, Timestamp = DateTime.UtcNow },
                new EDetection { Id = 3, Class = "pet", Score = 8, Timestamp = DateTime.UtcNow },
                new EDetection { Id = 4, Class = "pet", Score = 4, Timestamp = DateTime.UtcNow },
                new EDetection { Id = 5, Class = "pet", Score = 3, Timestamp = DateTime.UtcNow },
                new EDetection { Id = 6, Class = "pet", Score = 9, Timestamp = DateTime.UtcNow },
                new EDetection { Id = 7, Class = "pet", Score = 1, Timestamp = DateTime.UtcNow },
                new EDetection { Id = 8, Class = "pet", Score = 1, Timestamp = DateTime.UtcNow },
            });
        }
    }
}
