using EmployeeAdminPortal.Models.Inputs;
using EmployeeAdminPortal.Models.Outputs;
using Riok.Mapperly.Abstractions;

namespace EmployeeAdminPortal.Employees.GetEmployee
{
    [Mapper]
    public partial class GetEmployeeMapper
    {
        public partial GetEmployeeInput Map(GetEmployeeRequest request);

        [MapProperty(nameof(GetEmployeeOutput.Employee.EmployeeId), nameof(GetEmployeeResponse.Employee.Id))]
        public partial GetEmployeeResponse Map(GetEmployeeOutput output);
    }
}