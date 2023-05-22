using BackEnd.Models;
using Microsoft.EntityFrameworkCore;

namespace BackEnd.Data
{
    public class ApDbContext : DbContext
    {
        public ApDbContext(DbContextOptions<ApDbContext> options) : base(options)
        {
        }

        public DbSet<Person> People { get; set; }
    }
}
