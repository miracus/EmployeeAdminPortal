using EmployeeAdminPortal.Models.Entities;

namespace EmployeeAdminPortal.Models.Inputs
{
    public class UpdateEmployeeInput
    {
        public Employee Employee { get; set; } = new Employee();
    }
}