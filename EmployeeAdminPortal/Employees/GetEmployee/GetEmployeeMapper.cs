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
        [MapProperty(nameof(GetEmployeeOutput.Employee.Name), nameof(GetEmployeeResponse.Employee.Name))]
        [MapProperty(nameof(GetEmployeeOutput.Employee.Email), nameof(GetEmployeeResponse.Employee.Email))]
        public partial GetEmployeeResponse Map(GetEmployeeOutput output);
    }
}