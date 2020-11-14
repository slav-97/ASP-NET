using Microsoft.EntityFrameworkCore;

namespace CoreLab.Models
{
    public class EFContext : DbContext
    {
        public EFContext(DbContextOptions<EFContext> options) : base(options)
        { 

        }
        public DbSet<Student> Students { get; set; }
    }
}
