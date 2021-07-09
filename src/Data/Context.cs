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
    }
}
