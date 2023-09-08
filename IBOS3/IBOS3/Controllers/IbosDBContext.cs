using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace IBOS3.Controllers
{
    public class IbosDBContext : DbContext
    {
        public IbosDBContext(DbContextOptions<IbosDBContext> options)
           : base(options)
        {
        }
        public DbSet<Employee> tblEmployee { get; set; }
    }
}

 


