using EmployeeAdminPortal.Models.Entities;

namespace EmployeeAdminPortal.Models.Inputs
{
    public class UpdateEmployeeInput
    {
        public Guid EmployeeId { get; set; }
        public Employee Employee { get; set; } = null!;
    }
}