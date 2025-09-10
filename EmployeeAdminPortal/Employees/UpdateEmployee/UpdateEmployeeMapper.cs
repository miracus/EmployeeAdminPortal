using EmployeeAdminPortal.Models.Entities;
using EmployeeAdminPortal.Models.Inputs;
using EmployeeAdminPortal.Models.Outputs;

namespace EmployeeAdminPortal.Employees.UpdateEmployee
{
    public static class UpdateEmployeeMapper
    {
        public static UpdateEmployeeInput Map(UpdateEmployeeRequest request)
        {
            return new UpdateEmployeeInput
            {
                EmployeeId = request.EmployeeId,
                Employee = new Employee
                {
                    Name = request.Employee.Name,
                    Email = request.Employee.Email
                }
            };
        }

        public static UpdateEmployeeResponse Map(UpdateEmployeeOutput output)
        {
            return new UpdateEmployeeResponse
            {
                Success = output.Success
            };
        }
    }
}