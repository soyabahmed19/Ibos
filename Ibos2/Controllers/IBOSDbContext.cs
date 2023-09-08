
using Microsoft.EntityFrameworkCore;

namespace Ibos2.Controllers { 

public class IBOSDBContext : DbContext
{
    public IBOSDBContext(DbContextOptions<IBOSDBContext> options)
        : base(options)
    {
    }
    public DbSet<Employee> tblEmployee { get; set; }
}

}