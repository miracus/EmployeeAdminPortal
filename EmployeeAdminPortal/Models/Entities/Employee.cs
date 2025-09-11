namespace EmployeeAdminPortal.Models.Entities
{
    public class Employee
    {
        public Guid EmployeeId { get; set; }
        public required string Name { get; set; }
        public required string Email { get; set; }
        public string? Phone { get; set; }
        public int Salary { get; set; }
        public bool IsDeleted { get; set; }
    }
}
