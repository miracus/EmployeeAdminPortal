using EmployeeAdminPortal.Models.Inputs;
using Riok.Mapperly.Abstractions;

namespace EmployeeAdminPortal.Employees.DeleteEmployee
{
    [Mapper]
    public partial class DeleteEmployeeMapper
    {
        public partial DeleteEmployeeInput Map(DeleteEmployeeRequest request);
    }
}