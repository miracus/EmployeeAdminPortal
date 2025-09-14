using EmployeeAdminPortal.Common;
using EmployeeAdminPortal.Models.Inputs;
using EmployeeAdminPortal.Models.Outputs;

namespace EmployeeAdminPortal.Interfaces.Services
{
    public interface IEmployeesService
    {
        Result<AddEmployeeOutput> AddEmployee(AddEmployeeInput input);
        Result<GetEmployeeOutput> GetEmployee(GetEmployeeInput input);
        Result<DeleteEmployeeOutput> DeleteEmployee(DeleteEmployeeInput input);
        Result<UpdateEmployeeOutput> UpdateEmployee(Guid id, UpdateEmployeeInput input);
    }
}