namespace Ibos.Models
{
    public class Employee
    {
        public int EmployeeId { get; set; }
        public string EmployeeName { get; set; }
        public string EmployeeCode { get; set; }
        public decimal EmployeeSalary { get; set; }
        public int SupervisorId { get; set; }

        // Navigation property for supervisor
        public Employee Supervisor { get; set; }
    }

}

