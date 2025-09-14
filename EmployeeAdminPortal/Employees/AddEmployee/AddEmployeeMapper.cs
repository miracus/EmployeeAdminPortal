using EmployeeAdminPortal.Models.Entities;
using EmployeeAdminPortal.Models.Inputs;
using Riok.Mapperly.Abstractions;

namespace EmployeeAdminPortal.Employees.AddEmployee
{
    [Mapper]
    public partial class AddEmployeeMapper
    {
        public static AddEmployeeInput Map(AddEmployeeRequest request)
        {
            return new AddEmployeeInput
            {
                Employee = new Employee
                {
                    Name = request.Employee.FirstName + " " + request.Employee.LastName,
                    Email = request.Employee.Email,
                    IsDeleted = false
                }
            };
        }
    }
}