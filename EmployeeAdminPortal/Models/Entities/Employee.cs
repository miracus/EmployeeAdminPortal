using System.ComponentModel.DataAnnotations.Schema;

namespace EmployeeAdminPortal.Models.Entities
{
    public class Employee
    {
        [Column("Id")]
        public Guid EmployeeId { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }
        public int Salary { get; set; }
        public bool IsDeleted { get; set; } = false;
    }
}
