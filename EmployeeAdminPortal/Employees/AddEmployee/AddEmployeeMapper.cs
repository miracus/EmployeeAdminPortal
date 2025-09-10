using EmployeeAdminPortal.Models.Entities;
using EmployeeAdminPortal.Models.Inputs;
using EmployeeAdminPortal.Models.Outputs;

namespace EmployeeAdminPortal.Employees.AddEmployee
{
    public static class AddEmployeeMapper
    {
        public static AddEmployeeInput Map(AddEmployeeRequest request)
        {
            return new AddEmployeeInput
            {
                Employee = new Employee
                {
                    Name = request.Employee.FirstName + request.Employee.LastName,
                    Email = request.Employee.Email,
                    IsDeleted = false
                }
            };
        }

        public static AddEmployeeResponse Map(AddEmployeeOutput output)
        {
            return new AddEmployeeResponse
            {
                Success = output.Success
            };
        }
    }
}
