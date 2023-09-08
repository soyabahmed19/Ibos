using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IBOS4.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AttendanceController : ControllerBase
    {
        private readonly IBOSDbContext _context;

        public AttendanceController(IBOSDbContext context)
        {
            _context = context;
        }

        [HttpGet("GetMonthlyAttendanceReport")]
        public async Task<ActionResult<IEnumerable<MonthlyAttendanceReport>>> GetMonthlyAttendanceReport()
        {
            var report = await _context.Employee
                .Select(e => new MonthlyAttendanceReport
                {
                    EmployeeName = e.EmployeeName,
                    MonthName = "June", // Replace with the actual month name
                    PayableSalary = e.EmployeeSalary,
                    TotalPresent = _context.EmployeeAttendance
                        .Where(a => a.EmployeeId == e.EmployeeId && a.IsPresent == true)
                        .Count(),
                    TotalAbsent = _context.EmployeeAttendance
                        .Where(a => a.EmployeeId == e.EmployeeId && a.IsAbsent == true)
                        .Count(),
                    TotalOffday = _context.EmployeeAttendance
                        .Where(a => a.EmployeeId == e.EmployeeId && a.IsOffday == true)
                        .Count()
                })
                .ToListAsync();

            return report;
        }
    }
}
