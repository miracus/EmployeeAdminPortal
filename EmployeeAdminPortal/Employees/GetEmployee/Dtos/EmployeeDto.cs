namespace EmployeeAdminPortal.Employees.GetEmployee
{
    public class EmployeeDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = null!;
        public string Email { get; set; } = null!;
    }
}
