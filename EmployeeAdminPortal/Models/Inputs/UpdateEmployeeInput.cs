using EmployeeAdminPortal.Models.Entities;

public class UpdateEmployeeInput
{
    public Guid EmployeeId { get; set; }
    public Employee Employee { get; set; } = null!;
}