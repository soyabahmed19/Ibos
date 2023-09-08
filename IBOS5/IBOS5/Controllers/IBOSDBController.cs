using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace IBOS5.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IBOSDBController : ControllerBase
    {
        private readonly EmployeeDbContext _context;
        public IBOSDBController(EmployeeDbContext context)
        {
            _context = context;
        }
        // GET: api/Employee/502036
        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<Employee>>> GetEmployeeHierarchy(int id)
        {
            // Get the employee with the specified ID.
            var employee = await _context.Employee.FindAsync(id);
            // If the employee does not exist, return a 404 Not Found error.
            if (employee == null)
            {
                return NotFound();
            }
            // Get the employee's supervisor.
            var supervisor = await _context.Employee.FindAsync(employee.SupervisorId);
            // If the supervisor does not exist, return a 404 Not Found error.
            if (supervisor == null)
            {
                return NotFound();
            }
            // Create a list to store the employee's hierarchy.
            List<Employee> hierarchy = new List<Employee>();
            // Add the employee to the list.
            hierarchy.Add(employee);
            // Add the employee's supervisor to the list.
            hierarchy.Add(supervisor);
            // Get the employee's supervisor's supervisor.
            var supervisor2 = await _context.Employee.FindAsync(supervisor.SupervisorId);
            // If the supervisor's supervisor exists, add them to the list.
            if (supervisor2 != null)
            {
                hierarchy.Add(supervisor2);
            }
            // Return the employee's hierarchy.
            return hierarchy;
        }
    }
}
