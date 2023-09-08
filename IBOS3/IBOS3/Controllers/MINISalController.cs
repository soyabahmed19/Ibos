using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace IBOS3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MINISalController : ControllerBase
    {
        private readonly IbosDBContext _context;
        public MINISalController(IbosDBContext context)
        {
            _context = context;
        }
        // GET: api/Employee/GetThirdHighestSalary
        [HttpGet("GetThirdHighestSalary")]
        public async Task<ActionResult<Employee>> GetThirdHighestSalary()
        {
            // Get the third highest salary from the database
            var thirdHighestSalary = await _context.tblEmployee
                .OrderByDescending(e => e.EmployeeSalary)
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
