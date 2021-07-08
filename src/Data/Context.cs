namespace Data
{
    using Microsoft.EntityFrameworkCore;

    public class Context : DbContext
    {
        public DbSet<EDetections> Detections { get; set; }

        public Context(DbContextOptions<Context> options) : base(options)
        {
        }
    }
}
