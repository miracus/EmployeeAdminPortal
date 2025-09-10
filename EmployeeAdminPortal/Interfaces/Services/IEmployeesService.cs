using EmployeeAdminPortal.Models.Inputs;
using EmployeeAdminPortal.Models.Outputs;

namespace EmployeeAdminPortal.Interfaces.Services
{
    public interface IEmployeesService
    {
        AddEmployeeOutput AddEmployee(AddEmployeeInput input);
        GetEmployeeOutput GetEmployee(GetEmployeeInput input);
        DeleteEmployeeOutput DeleteEmployee(DeleteEmployeeInput input);
        UpdateEmployeeOutput UpdateEmployee(UpdateEmployeeInput input);
    }
}
