using EmployeeAdminPortal.Models.Entities;
using EmployeeAdminPortal.Models.Inputs;
using EmployeeAdminPortal.Models.Outputs;

namespace EmployeeAdminPortal.Employees.GetEmployee
{
    public static class GetEmployeeMapper
    {
        public static GetEmployeeInput Map(GetEmployeeRequest request)
        {
            return new GetEmployeeInput
            {
                EmployeeId = request.EmployeeId
            };
        }

        public static GetEmployeeResponse Map(GetEmployeeOutput output)
        {
            if (output.Employee == null)
                return new GetEmployeeResponse { Employee = null };

            return new GetEmployeeResponse
            {
                Employee = new EmployeeDto
                {
                    Id = output.Employee.EmployeeId,
                    Name = output.Employee.Name,
                    Email = output.Employee.Email
                }
            };
        }
    }
}
