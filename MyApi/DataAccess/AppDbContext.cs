using Microsoft.EntityFrameworkCore;
using MyApi.Models;

namespace MyApi.DataAccess
{
    public class AppDbContext : DbContext
    {
        public DbSet<Employee> Employee { get; set; }
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {

        }

    }
}
