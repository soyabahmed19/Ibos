using Ibos.Models;
using Microsoft.EntityFrameworkCore;

namespace Ibos.Data
{
    public class EmployeeDbContext :DbContext
    {
        public EmployeeDbContext(DbContextOptions<EmployeeDbContext> options)
           : base(options)
        {

        }
        public DbSet<Employee> Employees { get; set; }
    }
}
