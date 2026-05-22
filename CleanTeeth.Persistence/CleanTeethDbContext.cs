using CleanTeeth.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CleanTeeth.Persistence
{
    public class CleanTeethDbContext : DbContext
    {
        public CleanTeethDbContext(DbContextOptions<CleanTeethDbContext> options) : base(options)
        {
        }

        protected CleanTeethDbContext()
        {
        }
        public DbSet<DentalOffice> DentalOffices { get; set; }
    }
}
