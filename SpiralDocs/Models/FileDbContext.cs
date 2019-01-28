using SpiralDocs.Models; 
using Microsoft.EntityFrameworkCore; 

namespace SpiralDocs.Models
{
    public class FileDbContext : DbContext 
    {
        public FileDbContext(DbContextOptions<FileDbContext> options)
            : base(options)
        {
        }
            public DbSet<SpiralUser> SpiralUsers { get; set; }
            public DbSet<SpiralFile> SpiralFiles { get; set; }
    }
}
