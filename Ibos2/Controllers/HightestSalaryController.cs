using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;



namespace Ibos2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HightestSalaryController : ControllerBase
    {
        private readonly IBOSDBContext _context;
        public HightestSalaryController(IBOSDBContext context)
        {
            _context = context;
        }
        // GET: api/Employee/GetThirdHighestSalary
        [HttpGet("GetThirdHighestSalary")]
        public async Task<ActionResult<Employee>> GetThirdHighestSalary()
        {
            // Get the third highest salary from the database
            var thirdHighestSalary = await _context.tblEmployee
                .OrderByDescending(e => e.salary)
                .Skip(2)
                .Take(1)
                .FirstOrDefaultAsync();
            // Check if the employee exists
            if (thirdHighestSalary == null)
            {
                return NotFound();
            }
            // Return the employee
            return Ok(thirdHighestSalary);
        }
    }
}
   