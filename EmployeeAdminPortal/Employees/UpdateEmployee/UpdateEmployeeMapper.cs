using EmployeeAdminPortal.Models.Entities;
using EmployeeAdminPortal.Models.Inputs;

namespace EmployeeAdminPortal.Employees.UpdateEmployee
{
    public static class UpdateEmployeeMapper
    {
        public static UpdateEmployeeInput? Map(UpdateEmployeeRequest request)
        {
            if (request == null || request.Employee == null)
            {
                return null;
            }

            return new UpdateEmployeeInput
            {
                Employee = new Employee
                {
                    EmployeeId = request.EmployeeId,
                    Name = request.Employee.Name,
                    Email = request.Employee.Email
                }
            };
        }
    }
}