using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace IBOS5.Controllers
{
    public class EmployeeDbContext
    {
        public object Employee { get; internal set; }

        public class IbosDBContext : DbContext
        {
            public IbosDBContext(DbContextOptions<IbosDBContext> options)
               : base(options)
            {
            }
            public DbSet<Employee> Employee { get; set; }
        }
    }
}
