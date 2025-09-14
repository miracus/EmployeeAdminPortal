namespace EmployeeAdminPortal.Employees.AddEmployee.Dtos
{
    public class EmployeeDto
    {
        public Guid EmployeeId { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string Email { get; set; } = null!;
    }
}
