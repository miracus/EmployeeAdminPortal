using EmployeeAdminPortal.Models.Entities;
using EmployeeAdminPortal.Models.Inputs;
using Riok.Mapperly.Abstractions;

namespace EmployeeAdminPortal.Employees.UpdateEmployee
{
    [Mapper]
    public partial class UpdateEmployeeMapper
    {
        [MapProperty(nameof(UpdateEmployeeRequest.EmployeeId), nameof(UpdateEmployeeInput.Employee.EmployeeId))]
        [MapProperty(nameof(UpdateEmployeeRequest.Employee.Name), nameof(UpdateEmployeeInput.Employee.Name))]
        [MapProperty(nameof(UpdateEmployeeRequest.Employee.Email), nameof(UpdateEmployeeInput.Employee.Email))]
        public partial UpdateEmployeeInput Map(UpdateEmployeeRequest request);
    }
}