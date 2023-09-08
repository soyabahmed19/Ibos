using IBOS4;
using Microsoft.EntityFrameworkCore;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IBOS4.Controllers
{
    public interface IBOSDbContext : DbContext
    {
        public IBOSDbContext(DbContextOptions<IBOSDbContext> options)
   : base(options)
        {
        }
        public DbSet<Employee> tblEmployee { get; set; }
    }
}



