using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System;
using Ibos.Data;

namespace Ibos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        
            private readonly EmployeeDbContext _context;
            public EmployeeController(EmployeeDbContext context)
            {
                _context = context;
            }
            [HttpPost]
            public async Task<IActionResult> UpdateEmployee(int employeeId, string employeeName, string employeeCode)
            {
                // Check if the employee exists
                var employee = await _context.tblEmployee.FindAsync(employeeId);
                if (employee == null)
                {
                    return NotFound();
                }
                // Check if the employee code is unique
                var employeeWithSameCode = await _context.tblEmployee.FirstOrDefaultAsync(e => e.employeeCode == employeeCode && e.employeeId != employeeId);
                if (employeeWithSameCode != null)
                {
                    return BadRequest("Employee code must be unique");
                }
                // Update the employee's name and code
                employee.employeeName = employeeName;
                employee.employeeCode = employeeCode;
                // Save the changes
                await _context.SaveChangesAsync();
                // Return the updated employee
                return Ok(employee);
            }
        }
}

